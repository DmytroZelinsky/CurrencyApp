using CurrencyApp.Domain.Entities;

using MediatR;

namespace CurrencyApp.Application.Queries.ExchangeRates.Snapshot;

public record GetExchangeRateSnapshotQuery(string BaseCurrency, string[] TargetedCurrency) : IRequest<ExchangeRateSnapshot>
{
}
