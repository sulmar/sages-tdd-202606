using System.Text.Json;

namespace CurrencyRateService;

public class CurrencyConverter
{
    private readonly HttpClient _httpClient;

    public CurrencyConverter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetRateAsync(string fromCurrency, string toCurrency)
    {        
        var response = await _httpClient.GetStringAsync(
            $"https://api.exchangerate.example/rates?from={fromCurrency}&to={toCurrency}");

        using var document = JsonDocument.Parse(response);
        return document.RootElement.GetProperty("rate").GetDecimal();
    }

    public async Task<decimal> ConvertAsync(decimal amount, string fromCurrency, string toCurrency)
    {
        var rate = await GetRateAsync(fromCurrency, toCurrency);
        return amount * rate;
    }
}
