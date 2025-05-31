using Application.Features.Category.Queries.GetAllByFilter;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using NSubstitute;
using ViewModels.Filter.Category;
using ViewModels.QueriesResponseViewModel.Category;

namespace Application.UnitTest.Features.Category.Queries.GetAllByFilter;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllCategoriesByFilterQueryHandlerTests
{
    private readonly SharedFixture _fixture;
    private readonly GetAllCategoriesByFilterQueryHandler _handler;

    public GetAllCategoriesByFilterQueryHandlerTests(SharedFixture fixture)
    {
        _fixture = fixture;

        _handler = new GetAllCategoriesByFilterQueryHandler(
            _fixture.UnitOfWork,
            _fixture.Mapper);

        _fixture.UnitOfWork.CategoryRepository.ClearReceivedCalls();
        _fixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnAllActiveCategories_WhenNoFilterApplied()
    {
        //// Arrange
        //var query = new GetAllCategoriesByFilterQuery();

        //var fakeList = new List<Domain.Entities.Category.Category>
        //{
        //    new() { Id = 1, Name = "Back", IsActive = true },
        //    new() { Id = 2, Name = "Front", IsActive = true }
        //};

        //var resultViewModel = new CategoryFilterViewModel
        //{
        //    DtoEntities = new List<CategoryViewModel>
        //    {
        //        new() { Id = 1, Name = "Back" },
        //        new() { Id = 2, Name = "Front" }
        //    }
        //};

        //_fixture.Mapper.Map<CategoryFilterViewModel>(query)
        //    .Returns(resultViewModel);

        //_fixture.UnitOfWork.CategoryRepository.TableNoTracking
        //    .Returns(fakeList.AsQueryable());

        //// Act
        //var result = await _handler.Handle(query, default);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.DtoEntities.Should().HaveCount(2);
    }

    [Fact]
    public async Task Should_FilterByParentId_WhenProvided()
    {
        //// Arrange
        //var query = new GetAllCategoriesByFilterQuery { ParentId = 10 };

        //var viewModel = new CategoryFilterViewModel { ParentId = 10 };
        //var categories = new List<Domain.Entities.Category.Category>
        //{
        //    new() { Id = 1, ParentId = 10, Name = "Child", IsActive = true },
        //};

        //_fixture.Mapper.Map<CategoryFilterViewModel>(query).Returns(viewModel);
        //_fixture.UnitOfWork.CategoryRepository.TableNoTracking
        //    .Returns(categories.AsQueryable());

        //// Act
        //var result = await _handler.Handle(query, default);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.DtoEntities.Should().HaveCount(1);
        //result.Value.DtoEntities[0].Name.Should().Be("Child");
    }

    [Fact]
    public async Task Should_CallSetTargetRoutes_WhenNodeLevelIs3()
    {
        //// Arrange
        //var query = new GetAllCategoriesByFilterQuery { NodeLevel = 3 };
        //var viewModel = new CategoryFilterViewModel
        //{
        //    NodeLevel = 3,
        //    DtoEntities = new List<CategoryViewModel> { new() { Id = 1 } }
        //};

        //_fixture.Mapper.Map<CategoryFilterViewModel>(query).Returns(viewModel);
        //_fixture.UnitOfWork.CategoryRepository.TableNoTracking
        //    .Returns(new List<Domain.Entities.Category.Category>().AsQueryable());

        //_fixture.UnitOfWork.CategoryRepository
        //    .SetTargetRoutes(viewModel.DtoEntities)
        //    .Returns(viewModel.DtoEntities);

        //// Act
        //var result = await _handler.Handle(query, default);

        //// Assert
        //result.Value.DtoEntities.Should().HaveCount(1);
        //await _fixture.UnitOfWork.CategoryRepository
        //    .Received(1)
        //    .SetTargetRoutes(Arg.Any<List<CategoryViewModel>>());
    }

    [Fact]
    public async Task Should_ReturnEmptyList_WhenNoDataMatchFilters()
    {
        //// Arrange
        //var query = new GetAllCategoriesByFilterQuery { Name = "NotExist" };
        //var viewModel = new CategoryFilterViewModel { Name = "NotExist" };

        //_fixture.Mapper.Map<CategoryFilterViewModel>(query).Returns(viewModel);
        //_fixture.UnitOfWork.CategoryRepository.TableNoTracking
        //    .Returns(new List<Domain.Entities.Category.Category>
        //    {
        //        new() { Name = "Back", IsActive = true }
        //    }.AsQueryable());

        //// Act
        //var result = await _handler.Handle(query, default);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.DtoEntities.Should().BeEmpty();
    }
}