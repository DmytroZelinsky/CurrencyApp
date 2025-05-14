using AutoMapper;

using CurrencyApp.Application.Abstraction;
using CurrencyApp.Infrastructure.CurrencyProviders.Frunkfurter;
using CurrencyApp.Infrastructure.Mapping.AutoMapper;
using CurrencyApp.Infrastructure.Mapping.AutoMapper.Profilers.Frunkfurter;

using Microsoft.Extensions.DependencyInjection;

namespace CurrencyApp.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddTransient<ICurrencyProvider, FrankfurterProvider>();
		//services.AddSingleton<ICacheService, MemoryCacheService>();

		services.AddHttpClient();

		var autoMapper = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(typeof(FrankfurterProfile));

		}).CreateMapper();

		services.AddSingleton(autoMapper);

		services.AddSingleton<ICustomMapper, AutoMapperAdapter>();

		return services;
	}
}