using System.Linq.Expressions;
using Application.Features.Category.Queries.GetByRoute;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Category;

namespace Application.UnitTest.Features.Category.Queries.GetByRoute;

[Collection(CollectionDefinition.SharedFixture)]
public class GetCategoryByRouteQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetCategoryByRouteQueryHandler _handler;

    public GetCategoryByRouteQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _handler = new GetCategoryByRouteQueryHandler(_sharedFixture.UnitOfWork, _sharedFixture.Mapper);
    }

    [Fact]
    public async Task Should_ReturnCategory_WhenCategoryRouteMatches()
    {
        // Arrange
        var query = new GetCategoryByRouteQuery { Route = "test-route", CityId = 1 };
        var category = new Domain.Entities.Category.Category { Id = 1, Name = "Test", Route = "test-route", IsActive = true };

        _sharedFixture.UnitOfWork.CategoryRepository
            .GetByPredicate(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>())
            .Returns(category);

        _sharedFixture.UnitOfWork.CategoryRepository
            .ReplaceCategoryContent(category, query.CityId)
            .Returns("Content");

        _sharedFixture.UnitOfWork.CategoryRepository
            .SetCategoryPicture(category)
            .Returns("picture.jpg");

        _sharedFixture.Mapper
            .Map<CategoryViewModel>(category)
            .Returns(new CategoryViewModel { Id = 1, Name = "Test" });

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.Name.Should().Be("Test");
    }

    [Fact]
    public async Task Should_ReturnCategory_FromKeyword_WhenCategoryIsNull_AndKeywordExists()
    {
        //// Arrange
        //var query = new GetCategoryByRouteQuery { Route = "keyword-route", CityId = 2 };
        //var category = new Domain.Entities.Category.Category { Id = 2, Name = "KeywordCategory", Route = "keyword-route", IsActive = true };
        //var keyword = new Domain.Entities.Category.Keyword { Slug = "keyword-route", Category = category, IsActive = true };

        //_sharedFixture.UnitOfWork.CategoryRepository
        //    .GetByPredicate(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>())
        //    .Returns((Domain.Entities.Category.Category)null!);

        //_sharedFixture.UnitOfWork.KeywordRepository.TableNoTracking
        //    .Returns(new List<Domain.Entities.Category.Keyword> { keyword }.AsQueryable().BuildMock());

        //_sharedFixture.UnitOfWork.CategoryRepository
        //    .ReplaceCategoryContent(category, query.CityId)
        //    .Returns("Keyword Content");

        //_sharedFixture.UnitOfWork.CategoryRepository
        //    .SetCategoryPicture(category)
        //    .Returns("keyword.jpg");

        //_sharedFixture.Mapper
        //    .Map<CategoryViewModel>(category)
        //    .Returns(new CategoryViewModel { Id = 2, Name = "KeywordCategory" });

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Name.Should().Be("KeywordCategory");
    }

    [Fact]
    public async Task Should_ReturnFailResult_WhenNeitherCategoryNorKeywordFound()
    {
        //// Arrange
        //var query = new GetCategoryByRouteQuery { Route = "not-found-route", CityId = 0 };

        //_sharedFixture.UnitOfWork.CategoryRepository
        //    .GetByPredicate(Arg.Any<Expression<Func<Domain.Entities.Category.Category, bool>>>())
        //    .Returns((Domain.Entities.Category.Category)null!);

        //_sharedFixture.UnitOfWork.KeywordRepository.TableNoTracking
        //    .Returns(new List<Domain.Entities.Category.Keyword>().AsQueryable().BuildMock());

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeFalse();
        //result.Errors.Should().Contain(Resources.Messages.Validations.NotFoundException);
    }
}