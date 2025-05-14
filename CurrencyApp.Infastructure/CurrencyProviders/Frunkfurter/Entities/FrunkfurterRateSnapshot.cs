using System.Text.Json.Serialization;

namespace CurrencyApp.Infrastructure.CurrencyProviders.Frunkfurter.Entities;

public class FrunkfurterRateSnapshot
{
	[JsonPropertyName("base")]
	public required string Base { get; set; }

	[JsonPropertyName("date")]
	public DateTime Date { get; set; }

	[JsonPropertyName("rates")]
	public required Dictionary<string, decimal> Rates { get; set; }
}
