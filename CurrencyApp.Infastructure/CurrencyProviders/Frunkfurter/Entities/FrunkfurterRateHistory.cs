using System.Text.Json.Serialization;

namespace CurrencyApp.Infrastructure.CurrencyProviders.Frunkfurter.Entities;

public class FrunkfurterRateHistory
{
	[JsonPropertyName("base")]
	public required string Base { get; set; }

	[JsonPropertyName("start_date")]
	public DateTime StartDate { get; set; }

	[JsonPropertyName("end_date")]
	public DateTime EndDate { get; set; }

	[JsonPropertyName("rates")]
	public required Dictionary<DateTime, Dictionary<string, decimal>> DatedRates { get; set; }
}
