using CurrencyApp.Domain.Entities;
using MediatR;

namespace CurrencyApp.Application.Queries.ExchangeRates.History;

public record GetExchangeRateHistoryQuery(string BaseCurrency, string[] TargetedCurrency, DateTime StartDate, DateTime EndDate)
	: IRequest<ExchangeRateHistory>
{
}
