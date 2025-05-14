using MediatR;

namespace CurrencyApp.Application.Caching
{
	public class CachingBehavior<TRequest, TResponse>(ICache cache)
		: IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		public async Task<TResponse> Handle(
			TRequest request,
			RequestHandlerDelegate<TResponse> next,
			CancellationToken cancellationToken)
		{
			if (request is not ICacheable cacheableRequest)
			{
				return await next(cancellationToken);
			}

			var cacheKey = cacheableRequest.CacheKey;

			var item = await cache.GetItemAsync<TResponse>(cacheKey);

			if (item is not null)
			{
				return item;
			}

			item = await next(cancellationToken);

			await cache.PutItemAsync(cacheKey, item!, cacheableRequest.TimeoutInMinutes);

			return item;
		}
	}
}
