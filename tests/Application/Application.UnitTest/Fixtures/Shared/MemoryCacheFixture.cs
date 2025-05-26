using Microsoft.Extensions.Caching.Memory;

namespace Application.UnitTest.Fixtures.Shared;

public class MemoryCacheFixture : IDisposable
{
    public IMemoryCache MemoryCache { get; }

    public MemoryCacheFixture()
    {
        MemoryCache = new MemoryCache(new MemoryCacheOptions());
    }

    public void Dispose()
    {
        MemoryCache.Dispose();
    }
}