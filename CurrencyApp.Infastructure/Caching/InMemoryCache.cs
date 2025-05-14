using System.Runtime.Caching;

using CurrencyApp.Application.Caching;

namespace CurrencyApp.Infrastructure.Caching
{
	public class InMemoryCache : ICache
	{
		public void PutItem(string key, object value)
		{
			var cache = GetCache();

			cache.Set(key, value, new CacheItemPolicy { Priority = CacheItemPriority.NotRemovable });
		}

		public void PutItem(string key, object value, double timeoutInMinutes)
		{
			var cache = GetCache();

			if (timeoutInMinutes > 0)
			{
				cache.Set(key, value, DateTimeOffset.UtcNow.AddMinutes(timeoutInMinutes));
			}
			else
			{
				cache.Set(key, value, new CacheItemPolicy { Priority = CacheItemPriority.NotRemovable });
			}
		}

		public Task PutItemAsync(string key, object value)
		{
			PutItem(key, value);

			return Task.CompletedTask;
		}

		public Task PutItemAsync(string key, object value, double timeoutInMinutes)
		{
			PutItem(key, value, timeoutInMinutes);

			return Task.CompletedTask;
		}

		public T GetItem<T>(string key)
		{
			var cache = GetCache();
			var data = cache.Get(key);

			return data != null ? (T)data : default;
		}

		public Task<T> GetItemAsync<T>(string key) => Task.FromResult(GetItem<T>(key));

		private static MemoryCache GetCache() => MemoryCache.Default;
	}
}
