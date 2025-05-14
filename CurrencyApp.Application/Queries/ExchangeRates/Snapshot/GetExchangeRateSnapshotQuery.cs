using CurrencyApp.Application.Caching;
using CurrencyApp.Domain.Entities;

using MediatR;

namespace CurrencyApp.Application.Queries.ExchangeRates.Snapshot;

public record GetExchangeRateSnapshotQuery(string BaseCurrency, string[]? TargetedCurrency) : IRequest<ExchangeRateSnapshot>, ICacheable
{
	public string CacheKey
	{
		get
		{
			var key = $"snapshot_{BaseCurrency}";

			if (TargetedCurrency is not null)
			{
				key += "_" + string.Join(',', TargetedCurrency);
			}

			return key;
		}
	}

	public double TimeoutInMinutes => 1;
}
