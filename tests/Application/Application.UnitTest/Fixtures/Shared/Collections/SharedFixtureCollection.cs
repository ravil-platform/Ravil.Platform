using Application.UnitTest.Constans;

namespace Application.UnitTest.Fixtures.Shared.Collections;

[CollectionDefinition(CollectionDefinition.SharedFixture)]
public class SharedFixtureCollection : ICollectionFixture<SharedFixture>
{
    //Just for definition collection
}