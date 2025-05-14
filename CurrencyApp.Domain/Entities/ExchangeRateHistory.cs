using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Domain.Entities;

public class ExchangeRateHistory
{
	public required string BaseCurrency { get; set; }

	public DateTime StartDate { get; set; }

	public DateTime EndDate { get; set; }

	public required Dictionary<DateTime, List<Rate>> DatedRates { get; set; }
}
