using Application.Features.Faq.Queries.GetAllByCategoryId;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.Faq;
using FluentAssertions;
using MockQueryable.NSubstitute;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Faq;

namespace Application.UnitTest.Features.Faq.Queries.GetAllByCategoryId;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllFaqsByCategoryIdQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllFaqsByCategoryIdQueryHandler _handler;

    public GetAllFaqsByCategoryIdQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;

        _handler = new GetAllFaqsByCategoryIdQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Should_Return_Faqs_For_Given_CategoryId()
    {
        // Arrange
        var request = new GetAllFaqsByCategoryIdQuery { CategoryId = 5 };

        var faq1 = new Domain.Entities.Faq.Faq { Id = 1, Question = "سوال ۱", Answer = "پاسخ ۱" };
        var faq2 = new Domain.Entities.Faq.Faq { Id = 2, Question = "سوال ۲", Answer = "پاسخ ۲" };

        var faqJobCategories = new List<FaqJobCategory>
        {
            new() { Faq = faq1, JobCategoryId = 5 },
            new() { Faq = faq2, JobCategoryId = 5 }
        };

        var expectedViewModels = new List<FaqViewModel>
        {
            new() { Id = 1, Question = "سوال ۱", Answer = "پاسخ ۱" },
            new() { Id = 2, Question = "سوال ۲", Answer = "پاسخ ۲" }
        };

        // شبیه‌سازی IQueryable برای TableNoTracking
        var queryable = faqJobCategories.AsQueryable().BuildMockDbSet();
        _sharedFixture.UnitOfWork.FaqJobCategoryRepository.TableNoTracking.Returns(queryable);

        _sharedFixture.Mapper.Map<List<FaqViewModel>>(Arg.Any<List<Domain.Entities.Faq.Faq>>())
            .Returns(expectedViewModels);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value.First().Question.Should().Be("سوال ۱");
    }
}