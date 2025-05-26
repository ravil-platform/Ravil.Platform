using Application.UnitTest.Constans;

namespace Application.UnitTest.Fixtures.Shared.Collections;

[CollectionDefinition(CollectionDefinition.SharedMemoryCacheFixture)]
public class SharedMemoryCacheFixtureCollection : ICollectionFixture<SharedFixture>, ICollectionFixture<MemoryCacheFixture>
{
    //Just for definition collection
}