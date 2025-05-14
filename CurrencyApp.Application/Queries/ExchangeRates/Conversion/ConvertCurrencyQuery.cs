using CurrencyApp.Application.Models;

using MediatR;

namespace CurrencyApp.Application.Queries.ExchangeRates.Conversion;

public record ConvertCurrencyQuery(string BaseCurrency, string BaseAmount, string[] TargetedCurrency) : IRequest<CurrencyConversionResponse>
{
}
