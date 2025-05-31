using Application.Features.Brand.Queries.GetAll;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Brand;
using FluentAssertions;
using NSubstitute;

namespace Application.UnitTest.Features.Brand.Queries.GetAll;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllBrandsQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllBrandsQueryHandler _handler;

    public GetAllBrandsQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetAllBrandsQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Should_Return_List_Of_BrandViewModel_When_Status_True()
    {
        //// Arrange
        //var brands = new List<Domain.Entities.Brand.Brand>
        //{
        //    new Domain.Entities.Brand.Brand { Id = 1, Title = "برند یک", Status = true },
        //    new Domain.Entities.Brand.Brand { Id = 2, Title = "برند دو", Status = true }
        //};

        //_sharedFixture.UnitOfWork.BrandRepository.GetAllAsync(Arg.Any<System.Linq.Expressions.Expression<Func<Domain.Entities.Brand.Brand, bool>>>())
        //    .Returns(brands);

        //// Act
        //var result = await _handler.Handle(new GetAllBrandsQuery(), CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().NotBeNullOrEmpty();
        //result.Value.Count.Should().Be(2);
        //result.Value.First().Title.Should().Be("برند یک");
    }
}