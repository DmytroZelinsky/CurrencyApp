using CurrencyApp.Application.Abstraction;
using CurrencyApp.Domain.Entities;

namespace CurrencyApp.Infrastructure.CurrencyProviders;

public class FrankfurterProvider : ICurrencyProvider
{
	public Task<ExchangeRateHistory> GetExchangeRateHistory(string baseCurrency, string[] targetedCurrency, DateTime fromDate, DateTime toDate)
	{
		throw new NotImplementedException();
	}

	public Task<ExchangeRateSnapshot> GetExchangeRateSnapshot(string baseCurrency, string[] targetedCurrency)
	{
		throw new NotImplementedException();
	}
}
