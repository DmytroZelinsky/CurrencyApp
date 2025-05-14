using CurrencyApp.Application.Queries.ExchangeRates.Conversion;
using CurrencyApp.Application.Queries.ExchangeRates.History;
using CurrencyApp.Application.Queries.ExchangeRates.Snapshot;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CurrencyApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrencyController(IMediator mediator) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> ConvertCurrency(string baseCurrency, string baseAmount, string[] targetedCurrency)
	{
		return Ok(await mediator.Send(new ConvertCurrencyQuery(baseCurrency, baseAmount, targetedCurrency)));
	}

	[HttpGet]
	public async Task<IActionResult> GetExchangeRateHistory(string baseCurrency, string[] targetedCurrency, DateTime startDate, DateTime endDate)
	{
		return Ok(await mediator.Send(new GetExchangeRateHistoryQuery(baseCurrency, targetedCurrency, startDate, endDate)));
	}

	[HttpGet]
	public async Task<IActionResult> GetExchangeRateSnapshot(string baseCurrency, string[] targetedCurrency)
	{
		return Ok(await mediator.Send(new GetExchangeRateSnapshotQuery(baseCurrency, targetedCurrency)));
	}
}
