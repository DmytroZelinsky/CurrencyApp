
using CurrencyApp.Application.Abstraction;
using CurrencyApp.Application.Queries.ExchangeRates.Conversion;
using CurrencyApp.Domain.Entities;

using MediatR;

namespace CurrencyApp.Application.Queries.ExchangeRates.History;

public class GetExchangeRateHistoryQueryHandler(ICurrencyProvider currencyRateService) : IRequestHandler<GetExchangeRateHistoryQuery, ExchangeRateHistory>
{
	public Task<ExchangeRateHistory> Handle(GetExchangeRateHistoryQuery request, CancellationToken cancellationToken)
	{
		return currencyRateService.GetExchangeRateHistory(request.BaseCurrency, request.TargetedCurrency, request.StartDate, request.EndDate);
	}
}
