using CurrencyApp.Application.Abstraction;
using CurrencyApp.Domain.Entities;

using MediatR;

namespace CurrencyApp.Application.Queries.ExchangeRates.Snapshot;

public class GetExchangeRateSnapshotQueryHandler(ICurrencyProvider currencyRateService) : IRequestHandler<GetExchangeRateSnapshotQuery, ExchangeRateSnapshot>
{
	public async Task<ExchangeRateSnapshot> Handle(GetExchangeRateSnapshotQuery request, CancellationToken cancellationToken)
	{
		return await currencyRateService.GetExchangeRateSnapshot(request.BaseCurrency, request.TargetedCurrency);
	}
}
