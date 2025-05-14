using CurrencyApp.Domain.Entities;

namespace CurrencyApp.Application.Models;

public class CurrencyConversionResponse
{
	public decimal Amount { get; set; }

	public required ExchangeRateSnapshot ExchangeRateSnapshot { get; set; }
}
