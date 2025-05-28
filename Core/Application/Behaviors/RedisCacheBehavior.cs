using Application.Interfaces.RedisCache;
using MediatR;

namespace Application.Behaviors
{
    public class RedisCacheBehavior<TRequest,TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;
        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is ICacheableQuery query)
            {
                var cacheKey = query.CacheKey;
                var cacheTime = query.CacheTime;

                var cachedData =await redisCacheService.GetAsync<TResponse>(cacheKey);
                if (cachedData is not null)
                    return cachedData;  
                
                var response =await next();
                if (response is not null)
                {
                    var expirationTime = DateTime.UtcNow.AddSeconds(cacheTime);
                    await redisCacheService.SetAsync(cacheKey, response, expirationTime);
                }
                return response;
            }
            return await next();
        }

        
    }
}
