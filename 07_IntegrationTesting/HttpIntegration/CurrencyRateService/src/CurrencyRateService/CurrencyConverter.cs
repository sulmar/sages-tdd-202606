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
        throw new NotImplementedException();
    }

    public async Task<decimal> ConvertAsync(decimal amount, string fromCurrency, string toCurrency)
    {
        throw new NotImplementedException();
    }
}
