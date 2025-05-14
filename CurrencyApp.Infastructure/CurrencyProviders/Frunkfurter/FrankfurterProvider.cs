using System.Collections.Specialized;
using System.Text.Json;
using System.Web;

using CurrencyApp.Application.Abstraction;
using CurrencyApp.Domain.Entities;
using CurrencyApp.Infrastructure.CurrencyProviders.Frunkfurter.Entities;

namespace CurrencyApp.Infrastructure.CurrencyProviders.Frunkfurter;

public class FrankfurterProvider(HttpClient httpClient, ICustomMapper mapper) : ICurrencyProvider
{
	private const string _baseUrl = "https://api.frankfurter.dev";

	private const string _version = "v1";

	public async Task<ExchangeRateHistory> GetExchangeRateHistory(string baseCurrency, string[]? targetedCurrency, DateTime fromDate, DateTime? toDate)
	{
		var uriBuilder = new UriBuilder($"{_baseUrl}/{_version}/{fromDate:yyyy-MM-dd}..{toDate?.ToString("yyyy-MM-dd") ?? string.Empty}");

		var query = HttpUtility.ParseQueryString(string.Empty);

		query["base"] = baseCurrency;

		if (targetedCurrency is not null)
		{
			query["symbols"] = string.Join(',', targetedCurrency);
		}

		uriBuilder.Query = query.ToString();

		var response = await httpClient.GetAsync(uriBuilder.Uri);

		var jsonResponse = await response.Content.ReadAsStringAsync();

		var parsedResponse = JsonSerializer.Deserialize<FrunkfurterRateHistory>(jsonResponse);

		return mapper.Map<FrunkfurterRateHistory, ExchangeRateHistory>(parsedResponse);
	}

	public async Task<ExchangeRateSnapshot> GetExchangeRateSnapshot(string baseCurrency, string[]? targetedCurrency)
	{
		var uriBuilder = new UriBuilder($"{_baseUrl}/{_version}/latest");

		var query = HttpUtility.ParseQueryString(string.Empty);

		query["base"] = baseCurrency;

		if (targetedCurrency is not null)
		{
			query["symbols"] = string.Join(',', targetedCurrency);
		}

		uriBuilder.Query = query.ToString();

		var response = await httpClient.GetAsync(uriBuilder.Uri);

		var jsonResponse = await response.Content.ReadAsStringAsync();

		var parsedResponse = JsonSerializer.Deserialize<FrunkfurterRateSnapshot>(jsonResponse);

		return mapper.Map<FrunkfurterRateSnapshot, ExchangeRateSnapshot>(parsedResponse);
	}
}
