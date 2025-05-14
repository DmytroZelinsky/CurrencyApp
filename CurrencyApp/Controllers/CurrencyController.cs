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
	[HttpGet("ConvertCurrency")]
	public async Task<IActionResult> ConvertCurrency(string baseCurrency, decimal baseAmount, [FromQuery] string[]? targetedCurrency = null)
	{
		return Ok(await mediator.Send(new ConvertCurrencyQuery(baseCurrency, baseAmount, targetedCurrency)));
	}

	[HttpGet("GetExchangeRateHistory")]
	public async Task<IActionResult> GetExchangeRateHistory(
		int? skip, 
		int? take, 
		string baseCurrency, 
		DateTime startDate, 
		DateTime? endDate = null, 
		[FromQuery] string[]? targetedCurrency = null)
	{
		return Ok(await mediator.Send(new GetExchangeRateHistoryQuery(skip, take, baseCurrency, targetedCurrency, startDate, endDate)));
	}

	[HttpGet("GetExchangeRateSnapshot")]
	public async Task<IActionResult> GetExchangeRateSnapshot(string baseCurrency, [FromQuery] string[]? targetedCurrency = null)
	{
		return Ok(await mediator.Send(new GetExchangeRateSnapshotQuery(baseCurrency, targetedCurrency)));
	}
}
