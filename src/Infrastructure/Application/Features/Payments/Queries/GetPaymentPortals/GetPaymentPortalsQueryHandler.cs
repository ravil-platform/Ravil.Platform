using AutoMapper.QueryableExtensions;
using ViewModels.QueriesResponseViewModel.Payments;

namespace Application.Features.Payments.Queries.GetPaymentPortals;

public class GetPaymentPortalsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
    : IRequestHandler<GetPaymentPortalsQuery, List<PaymentPortalViewModel>>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;

    #endregion

    public async Task<Result<List<PaymentPortalViewModel>>> Handle(GetPaymentPortalsQuery request, CancellationToken cancellationToken)
    {
        var paymentPortals = await UnitOfWork.PaymentPortalRepository.TableNoTracking
            .Where(a => a.IsActive)
            .ProjectTo<PaymentPortalViewModel>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);

        if (paymentPortals == null) throw new NotFoundException();

        return paymentPortals;
    }
}