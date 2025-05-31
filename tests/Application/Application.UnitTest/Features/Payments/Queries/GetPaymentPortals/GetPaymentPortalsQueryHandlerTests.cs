using Application.Features.Payments.Queries.GetPaymentPortals;
using Application.UnitTest.Constans;
using Application.UnitTest.Fixtures.Shared;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities.User;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MockQueryable;
using NSubstitute;
using ViewModels.QueriesResponseViewModel.Payments;

namespace Application.UnitTest.Features.Payments.Queries.GetPaymentPortals;

[Collection(CollectionDefinition.SharedFixture)]
public class GetPaymentPortalsQueryHandlerTests
{
    private readonly SharedFixture _sharedFixture;
    private readonly GetPaymentPortalsQueryHandler _handler;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    public GetPaymentPortalsQueryHandlerTests(SharedFixture sharedFixture)
    {
        _sharedFixture = sharedFixture;
        _httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        _userManager = Substitute.For<UserManager<ApplicationUser>>(
            Substitute.For<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

        _handler = new GetPaymentPortalsQueryHandler(
            _sharedFixture.Mapper,
            _sharedFixture.UnitOfWork,
            _httpContextAccessor,
            _userManager);
    }

    [Fact]
    public async Task Should_ReturnMappedList_WhenActivePaymentPortalsExist()
    {
        //// Arrange
        //var paymentPortals = new List<Domain.Entities.Payment.PaymentPortal>
        //{
        //    new() { Id = 1, Title = "زرین‌پال", IsActive = true },
        //    new() { Id = 2, Title = "پی‌پینگ", IsActive = true }
        //}.AsQueryable().BuildMock();

        //_sharedFixture.UnitOfWork.PaymentPortalRepository.TableNoTracking.Returns(paymentPortals);

        //var mapped = new List<PaymentPortalViewModel>
        //{
        //    new() { Id = 1, Title = "زرین‌پال" },
        //    new() { Id = 2, Title = "پی‌پینگ" }
        //};

        //_sharedFixture.Mapper
        //    .ConfigurationProvider
        //    .Returns(Substitute.For<IConfigurationProvider>());

        //_sharedFixture.Mapper
        //    .Map<List<PaymentPortalViewModel>>(Arg.Any<List<Domain.Entities.Payment.PaymentPortal>>())
        //    .Returns(mapped);

        //var query = new GetPaymentPortalsQuery();

        //// Act
        //var result = await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //result.Should().NotBeNull();
        //result.Value.Should().BeEquivalentTo(mapped);
        //_sharedFixture.UnitOfWork.PaymentPortalRepository.TableNoTracking.Received(1);
    }

    [Fact]
    public async Task Should_ThrowNotFoundException_WhenPaymentPortalsIsNull()
    {
        // Arrange
        //var emptyList = new List<Domain.Entities.Payment.PaymentPortal>().AsQueryable().BuildMock();

        //_sharedFixture.UnitOfWork.PaymentPortalRepository.TableNoTracking.Returns(emptyList);

        //var query = new GetPaymentPortalsQuery();

        //// Act
        //Func<Task> act = async () => await _handler.Handle(query, CancellationToken.None);

        //// Assert
        //await act.Should().ThrowAsync<NotFoundException>();
    }
}