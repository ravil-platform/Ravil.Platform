using Application.UnitTest.Constans;

namespace Application.UnitTest.Fixtures.Shared.Collections;

[CollectionDefinition(CollectionDefinition.SharedDistributedCacheFixture)]
public class DistributedCacheFixtureCollection : ICollectionFixture<SharedFixture>, ICollectionFixture<DistributedCacheFixture>
{
    //Just for definition collection
}