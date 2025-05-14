using CurrencyApp.Domain.Entities;
namespace CurrencyApp.Application.Abstraction;

public interface ICurrencyProvider
{
	public Task<ExchangeRateSnapshot> GetExchangeRateSnapshot(string baseCurrency, string[]? targetedCurrency);

	public Task<ExchangeRateHistory> GetExchangeRateHistory(string baseCurrency, string[]? targetedCurrency, DateTime fromDate, DateTime? toDate);
}
