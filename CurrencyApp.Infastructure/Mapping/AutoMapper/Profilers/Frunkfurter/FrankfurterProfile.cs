using AutoMapper;

using CurrencyApp.Domain.Entities;
using CurrencyApp.Infrastructure.CurrencyProviders.Frunkfurter.Entities;

namespace CurrencyApp.Infrastructure.Mapping.AutoMapper.Profilers.Frunkfurter;

internal class FrankfurterProfile : Profile
{
	public FrankfurterProfile()
	{
		CreateMap<FrunkfurterRateSnapshot, ExchangeRateSnapshot>()
			.ForMember(dest => dest.Rates, source => source.MapFrom(x => x.Rates.Select(kvp => new Rate() { Currency = kvp.Key, Value = kvp.Value })))
			.ForMember(dest => dest.BaseCurrency, source => source.MapFrom(x => x.Base));

	}
}
