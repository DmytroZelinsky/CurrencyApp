using CurrencyApp.Application.Caching;
using CurrencyApp.Domain.Entities;

using MediatR;

namespace CurrencyApp.Application.Queries.ExchangeRates.History;

public record GetExchangeRateHistoryQuery(int? Skip, int? Take, string BaseCurrency, string[]? TargetedCurrency, DateTime StartDate, DateTime? EndDate)
	: IRequest<ExchangeRateHistory>, ICacheable
{
	public string CacheKey
	{
		get
		{
			var key = $"history_{Skip}-{Take}_{BaseCurrency}_{StartDate}";

			if (EndDate is not null)
			{
				key += "-" + EndDate;
			}

			if (TargetedCurrency is not null)
			{
				key += "_" + string.Join(',', TargetedCurrency);
			}

			return key;
		}
	}

	public double TimeoutInMinutes => 1;
}
