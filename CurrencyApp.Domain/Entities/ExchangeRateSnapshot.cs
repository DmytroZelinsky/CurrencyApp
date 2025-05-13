using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Domain.Entities;

public class ExchangeRateSnapshot
{
	public required string BaseCurrency { get; set; }

	public DateTime Date { get; set; }

	public required Rate Rate { get; set; }
}
