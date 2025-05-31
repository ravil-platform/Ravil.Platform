using Application.Features.FeedbackSlider.Queries.GetAllByFilter;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using Domain.Entities.FeedbackSlider;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.FeedbackSlider;

namespace Application.UnitTest.Features.Faq.Queries.GetAllFaqCategories;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllFeedbackSliderByFilterQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllFeedbackSliderByFilterQueryHandler _handler;

    public GetAllFeedbackSliderByFilterQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;

        _handler = new GetAllFeedbackSliderByFilterQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork
        );
    }

    [Fact]
    public async Task Handle_Should_Return_Filtered_FeedbackSliders()
    {
        // Arrange
        var request = new GetAllFeedbackSliderByFilterQuery
        {
            CategoryId = 2,
            Take = 5
        };

        var entities = new List<FeedbackSlider>
        {
            new() {
                Id = 1,
                CategoryId = 2,
                UserName = "مهدی رضایی",
                UserRole = "مدیر فروش",
                Description = "واقعا راضی بودم",
                Sort = 1,
                Picture = "slider1.jpg"
            },
            new() {
                Id = 2,
                CategoryId = 2,
                UserName = "الهام جوادی",
                UserRole = "مشتری قدیمی",
                Description = "خدمات خیلی خوب بود",
                Sort = 2,
                Picture = "slider2.jpg"
            }
        };

        var viewModels = new List<FeedbackSliderViewModel>
        {
            new() { UserName = "مهدی رضایی", Description = "واقعا راضی بودم" },
            new() { UserName = "الهام جوادی", Description = "خدمات خیلی خوب بود" }
        };

        _sharedFixture.UnitOfWork.FeedbackSliderRepository
            .GetAllByFilter(request.Take, request.CategoryId)
            .Returns(entities);

        _sharedFixture.Mapper.Map<List<FeedbackSliderViewModel>>(entities)
            .Returns(viewModels);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value[0].UserName.Should().Be("مهدی رضایی");
        result.Value[1].Description.Should().Contain("خدمات");
    }
}