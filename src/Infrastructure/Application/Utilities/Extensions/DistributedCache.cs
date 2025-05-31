using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Application.Utilities.Extensions;

public static class DistributedCache
{
    public static async Task<T?> GetOrSet<T>(this IDistributedCache cache, string key, Func<Task<T>> func, CacheOptions options)
    {
        var val = await cache.GetAsync(key);
        if (val == null)
        {
            var res = await func();
            if (res == null)
                return default;

            await SetCache(cache, key, res, options);
            return res;
        }

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        var data = JsonSerializer.Deserialize<T>(val, jsonSerializerOptions);
        return data;
    }

    public static async Task<T?> GetOrSet<T>(this IDistributedCache cache, string key, Func<Task<T>> func)
    {
        var val = await cache.GetAsync(key);
        if (val == null)
        {
            var res = await func();
            if (res == null)
                return default;

            await SetCache(cache, key, res);
            return res;
        }

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        var data = JsonSerializer.Deserialize<T>(val, jsonSerializerOptions);
        return data;
    }

    public static Task SetCache<T>(this IDistributedCache cache, string key, T value)
    {
        return SetCache(cache, key, value, new CacheOptions());
    }

    public static async Task SetCache<T>(this IDistributedCache cache, string key, T value, CacheOptions options)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(value, jsonSerializerOptions);
        var bytes = Encoding.UTF8.GetBytes(json);

        await cache.SetAsync(key, bytes, new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(options.AbsoluteExpirationCacheFromMinutes),
            SlidingExpiration = TimeSpan.FromMinutes(options.ExpireSlidingCacheFromMinutes),
        });
    }

    public static async Task<T?> GetAsync<T>(this IDistributedCache cache, string key)
    {
        var val = await cache.GetAsync(key);
        if (val == null)
            return default;

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        var value = JsonSerializer.Deserialize<T>(val, jsonSerializerOptions);
        return value;
    }

    public class CacheOptions
    {
        public int ExpireSlidingCacheFromMinutes { get; set; } = 4 * 60;
        public int AbsoluteExpirationCacheFromMinutes { get; set; } = 48 * 60;
    }
}