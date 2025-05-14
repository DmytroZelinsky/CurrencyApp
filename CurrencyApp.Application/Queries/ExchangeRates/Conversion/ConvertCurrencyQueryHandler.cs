using CurrencyApp.Application.Abstraction;
using CurrencyApp.Application.Models;

using MediatR;

namespace CurrencyApp.Application.Queries.ExchangeRates.Conversion;

public class ConvertCurrencyQueryHandler(ICurrencyProvider currencyRateService) : IRequestHandler<ConvertCurrencyQuery, CurrencyConversionResponse>
{
	public async Task<CurrencyConversionResponse> Handle(ConvertCurrencyQuery request, CancellationToken cancellationToken)
	{
		var snapshot = await currencyRateService.GetExchangeRateSnapshot(request.BaseCurrency, request.TargetedCurrency);

		return new CurrencyConversionResponse();
	}
}
