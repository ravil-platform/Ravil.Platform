using Application.Features.MainSlider.Queries.GetAllByFilter;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using FluentAssertions;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.MainSlider;

namespace Application.UnitTest.Features.MainSlider.Queries.GetAllByFilter;

[Collection(CollectionDefinition.SharedFixture)]
public class GetAllMainSlidersByFilterQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetAllMainSlidersByFilterQueryHandler _handler;

    public GetAllMainSlidersByFilterQueryHandlerTests(SharedFixture fixture)
    {
        _sharedFixture = fixture;
        _handler = new GetAllMainSlidersByFilterQueryHandler(_sharedFixture.Mapper, _sharedFixture.UnitOfWork);

        _sharedFixture.UnitOfWork.ClearReceivedCalls();
        _sharedFixture.Mapper.ClearReceivedCalls();
    }

    [Fact]
    public async Task Should_ReturnMappedResult_WhenBranchIdIsProvided()
    {
        //// Arrange
        //var branchId = Guid.NewGuid().ToString();
        //var sliders = new List<Domain.Entities.MainSlider.MainSlider>
        //{
        //    new() { Id = 1, Title = "Slider 1" },
        //    new() { Id = 2, Title = "Slider 2" }
        //};

        //var expectedViewModels = new List<MainSliderViewModel>
        //{
        //    new() { Title = "Slider 1" },
        //    new() { Title = "Slider 2" }
        //};

        ////_sharedFixture.UnitOfWork.MainSliderRepository
        ////    .GetAllByJobBranchId(branchId, 10)
        ////    .Returns(Task.FromResult((IEnumerable<Domain.Entities.MainSlider.MainSlider>)sliders));

        //_sharedFixture.Mapper
        //    .Map<List<MainSliderViewModel>>(sliders)
        //    .Returns(expectedViewModels);

        //var query = new GetAllMainSlidersByFilterQuery
        //{
        //    BranchId = branchId,
        //    Take = 10
        //};

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.Should().BeEquivalentTo(expectedViewModels);

        //await _sharedFixture.UnitOfWork.MainSliderRepository.Received(1).GetAllByJobBranchId(branchId, 10);
        //_sharedFixture.Mapper.Received(1).Map<List<MainSliderViewModel>>(sliders);
    }
}