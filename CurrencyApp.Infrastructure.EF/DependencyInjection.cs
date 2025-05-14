using CurrencyApp.Infrastructure.EF.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyApp.Infrastructure.EF;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructureEF(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("MSSQLConnectionString")));

		return services;
	}
}