using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace MVCLABSITI.Filters
{
    public class ResourceFilter : Attribute, IResourceFilter
    {
        private readonly string _cacheKey;
        private readonly int _cacheDurationSeconds;

        public ResourceFilter(string cacheKey = "default", int cacheDurationSeconds = 60)
        {
            _cacheKey = cacheKey;
            _cacheDurationSeconds = cacheDurationSeconds;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();

            if (cache == null)
                return;

            var cacheKey = $"{_cacheKey}{context.HttpContext.Request.Path}";

            if (cache.TryGetValue(cacheKey, out IActionResult cachedResult))
            {
                Console.WriteLine($" Returning cached response for: {cacheKey}");

                context.Result = cachedResult;
            }
            else
            {
                Console.WriteLine($" Cache miss for: {cacheKey}");
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();

            if (cache == null || context.Result == null)
                return;

            var cacheKey = $"{_cacheKey}{context.HttpContext.Request.Path}";

            cache.Set(cacheKey, context.Result, TimeSpan.FromSeconds(_cacheDurationSeconds));

            Console.WriteLine($"Cached response for: {cacheKey} (expires in {_cacheDurationSeconds}s)");
        }
    }

}
