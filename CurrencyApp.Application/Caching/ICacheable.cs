namespace CurrencyApp.Application.Caching;

public interface ICacheable
{
	string CacheKey { get; }

	double TimeoutInMinutes { get; }
}
