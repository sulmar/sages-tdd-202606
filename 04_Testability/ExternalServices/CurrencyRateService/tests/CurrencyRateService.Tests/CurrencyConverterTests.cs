using System.Text.Json;

namespace CurrencyRateService.Tests;

public class FakeRateHttpMessageHandler(decimal rate) : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // nic nie rob

        var data = new { rate }; // Zwracamy stałą wartość kursu wymiany

        var json = JsonSerializer.Serialize(data);

        return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            Content = new StringContent(json, encoding: System.Text.Encoding.UTF8, mediaType: "application/json")
        });
    }    
}

public sealed class FakeHttpMessageHandler : HttpMessageHandler
{
    private readonly Func<HttpRequestMessage, HttpResponseMessage> _handler;

    public FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handler)
    {
        _handler = handler;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_handler(request));
    }
}

public class CurrencyConverterTests
{   
    [Fact]
    public async Task Convert_UsesRateFromApi()
    {
        // Arrange
        var converter = new CurrencyConverter(new HttpClient(new FakeRateHttpMessageHandler(4.1m)));

        // Act
        decimal result = await converter.ConvertAsync(100, "EUR", "PLN"); // EUR -> PLN : 4.1

        // Assert
        Assert.Equal(410m, result);
    }

    [Fact]
    public async Task Convert_UsesRateFromApi2()
    {
        // Arrange
        var handler = new FakeHttpMessageHandler(request =>
        {
            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Contains("from=EUR", request.RequestUri?.Query);
            Assert.Contains("to=PLN", request.RequestUri?.Query);

            // Możesz sprawdzić request.RequestUri, jeśli chcesz zwrócić różne odpowiedzi w zależności od żądania
            var data = new { rate = 4.1m }; // Zwracamy stałą wartość kursu wymiany
            var json = JsonSerializer.Serialize(data);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(json, encoding: System.Text.Encoding.UTF8, mediaType: "application/json")
            };
        });

        var converter = new CurrencyConverter(new HttpClient(handler));

        // Act
        decimal result = await converter.ConvertAsync(100, "EUR", "PLN"); // EUR -> PLN : 4.1

        // Assert
        Assert.Equal(410m, result);
    }
}
