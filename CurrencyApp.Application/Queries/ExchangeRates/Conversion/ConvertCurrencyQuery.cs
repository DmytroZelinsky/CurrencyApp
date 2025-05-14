
using CurrencyApp.Application.Caching;
using CurrencyApp.Application.Models;

using MediatR;

namespace CurrencyApp.Application.Queries.ExchangeRates.Conversion;

public record ConvertCurrencyQuery(string BaseCurrency, decimal BaseAmount, string[]? TargetedCurrency) : IRequest<CurrencyConversionResponse>, ICacheable
{
	public string CacheKey 
	{ 
		get
		{
			var key = $"convert_{BaseCurrency}-{BaseAmount}";

			if (TargetedCurrency is not null)
			{
				key += string.Join(',', TargetedCurrency);
			}

			return key ;
		}
	}
	
	public double TimeoutInMinutes => 1;
}
