using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CurrencyApp.Application.Models;
using CurrencyApp.Domain.Entities;

namespace CurrencyApp.Application.Abstraction
{
	public interface ICurrencyProvider
	{
		public Task<ExchangeRateSnapshot> GetExchangeRateSnapshot(string baseCurrency, string[] targetedCurrency);

		public Task<ExchangeRateHistory> GetExchangeRateHistory(string baseCurrency, string[] targetedCurrency, DateTime fromDate, DateTime toDate);
	}
}
