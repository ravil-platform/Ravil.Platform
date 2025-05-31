using Application.Features.Faq.Queries.GetAllFaqCategories;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Faq;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Faq;

namespace Application.UnitTest.Features.Faq.Queries.GetAllFaqCategories;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllFaqCategoriesQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllFaqCategoriesQueryHandler _handler;

    public GetAllFaqCategoriesQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;

        _handler = new GetAllFaqCategoriesQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Should_Return_All_FaqCategories()
    {
        // Arrange
        var request = new GetAllFaqCategoriesQuery();

        var data = new List<FaqCategory>
        {
            new() { Id = 1, Title = "عمومی" },
            new() { Id = 2, Title = "سفارش و پرداخت" }
        };

        var viewModels = new List<FaqCategoryViewModel>
        {
            new() { Id = 1, Title = "عمومی" },
            new() { Id = 2, Title = "سفارش و پرداخت" }
        };

        _sharedFixture.UnitOfWork.FaqCategoryRepository.GetAllAsync()
            .Returns(Task.FromResult((IList<FaqCategory>)data));

        _sharedFixture.Mapper.Map<List<FaqCategoryViewModel>>(data)
            .Returns(viewModels);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.Should().HaveCount(2);
        result.Value[0].Title.Should().Be("عمومی");
    }
}