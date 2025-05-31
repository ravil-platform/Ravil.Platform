using Microsoft.Extensions.Caching.Distributed;
using NSubstitute;

namespace Application.UnitTest.Fixtures.Shared;

public class DistributedCacheFixture : IDisposable
{
    public IDistributedCache DistributedCache { get; }

    public DistributedCacheFixture()
    {
        DistributedCache = Substitute.For<IDistributedCache>();
    }

    public void Dispose()
    {
       
    }
}