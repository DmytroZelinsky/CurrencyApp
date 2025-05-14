using System.Reflection;

using CurrencyApp.Application.Caching;
using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace CurrencyApp.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});

		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));

		return services;
	}
}