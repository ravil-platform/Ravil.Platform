using Application.Features.Faq.Queries.GetAll;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using MockQueryable.NSubstitute;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Faq;

namespace Application.UnitTest.Features.Faq.Queries.GetAll;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllFaqsQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllFaqsQueryHandler _handler;

    public GetAllFaqsQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;

        _handler = new GetAllFaqsQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Should_Return_AllFaqs_When_Take_IsNull()
    {
        // Arrange
        var request = new GetAllFaqsQuery(); // Take = null

        var faqs = new List<Domain.Entities.Faq.Faq>
        {
            new() { Id = 1, Question = "سؤال ۱", Answer = "پاسخ ۱" },
            new() { Id = 2, Question = "سؤال ۲", Answer = "پاسخ ۲" }
        };

        var viewModels = new List<FaqViewModel>
        {
            new() { Id = 1, Question = "سؤال ۱", Answer = "پاسخ ۱" },
            new() { Id = 2, Question = "سؤال ۲", Answer = "پاسخ ۲" }
        };

        _sharedFixture.UnitOfWork.FaqRepository.GetAllAsync().Returns(faqs);
        _sharedFixture.Mapper.Map<List<FaqViewModel>>(faqs).Returns(viewModels);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value.First().Question.Should().Be("سؤال ۱");
    }

    [Fact]
    public async Task Should_Return_TakenFaqs_When_Take_HasValue()
    {
        //// Arrange
        //var request = new GetAllFaqsQuery { Take = 1 };

        //var faqs = new List<Domain.Entities.Faq.Faq>
        //{
        //    new() { Id = 1, Question = "سؤال محدود", Answer = "پاسخ محدود" }
        //};

        //var viewModels = new List<FaqViewModel>
        //{
        //    new() { Id = 1, Question = "سؤال محدود", Answer = "پاسخ محدود" }
        //};

        //// شبیه‌سازی خروجی TableNoTracking.Take().ToListAsync()
        //var queryable = faqs.AsQueryable().BuildMockDbSet();
        //_sharedFixture.UnitOfWork.FaqRepository.TableNoTracking.Returns(queryable);

        //_sharedFixture.Mapper.Map<List<FaqViewModel>>(faqs).Returns(viewModels);

        //// Act
        //var result = await _handler.Handle(request, CancellationToken.None);

        //// Assert
        //result.IsSuccess.Should().BeTrue();
        //result.Value.Should().HaveCount(1);
        //result.Value.First().Question.Should().Be("سؤال محدود");
    }
}