using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApp.Domain.Entities;

public class Rate
{
	public required string Currency { get; set; }

	public required decimal Value { get; set; }
}
