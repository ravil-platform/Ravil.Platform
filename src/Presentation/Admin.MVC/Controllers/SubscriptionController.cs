

namespace Admin.MVC.Controllers;

public class SubscriptionController(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IFtpService ftpService)
: BaseController
{
    #region ( DI )
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;
    protected IFtpService FtpService { get; } = ftpService;
    #endregion

    #region ( Subscription )

    #region ( Index )
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await UnitOfWork.SubscriptionRepository.GetAllAsync();

        return View(model.ToList());
    }
    #endregion

    #region ( Create )
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewData["features"] = await UnitOfWork.FeatureRepository.GetAllAsync();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSubscriptionViewModel createSubscriptionViewModel)
    {
        if (!ModelState.IsValid)
        {
            #region ( Client Side Error )
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
            #endregion

            #region ( Fill View Datas )
            ViewData["features"] = await UnitOfWork.FeatureRepository.GetAllAsync();
            #endregion

            return View(createSubscriptionViewModel);
        }

        var subscription = Mapper.Map<Subscription>(createSubscriptionViewModel);

        #region ( Icon )
        var iconName = await FtpService.UploadFileToFtpServer(createSubscriptionViewModel.Icon, TypeFile.Image, Paths.Subscription, createSubscriptionViewModel.Icon.FileName);

        subscription.Icon = iconName;
        #endregion

        #region ( Discount )

        if (subscription.Discount is > 0)
        {
            subscription.DiscountAmount = subscription.Price * (subscription.Discount.Value / 100);
        }

        #endregion

        await UnitOfWork.SubscriptionRepository.InsertAsync(subscription);

        try
        {
            await UnitOfWork.SaveAsync();

            #region ( Subscription Features )
            if (createSubscriptionViewModel.Features != null)
            {
                foreach (var featureId in createSubscriptionViewModel.Features)
                {
                    var feature = new SubscriptionFeature()
                    {
                        FeatureId = featureId,
                        SubscriptionId = subscription.Id
                    };

                    await UnitOfWork.SubscriptionFeatureRepository.InsertAsync(feature);
                }
            }
            #endregion

            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception e)
        {
            ErrorAlert(e.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion

    #region ( Update )
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        ViewData["features"] = await UnitOfWork.FeatureRepository.GetAllAsync();

        var subscription = await UnitOfWork.SubscriptionRepository.GetByIdAsync(id);

        if (subscription == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        #region ( Subscription Feature )
        var subscriptionFeature = await UnitOfWork.SubscriptionFeatureRepository
            .GetAllAsync(s => s.SubscriptionId == subscription.Id);
        ViewData["subscriptionFeature"] = subscriptionFeature;
        #endregion

        var model = Mapper.Map<UpdateSubscriptionViewModel>(subscription);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateSubscriptionViewModel updateSubscriptionViewModel)
    {
        var subscription = await UnitOfWork.SubscriptionRepository.GetByIdAsync(updateSubscriptionViewModel.Id);

        if (subscription == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        #region ( Discount )

        if (updateSubscriptionViewModel.Discount is > 0 && subscription.Discount != updateSubscriptionViewModel.Discount)
        {
            subscription.DiscountAmount = subscription.Price * (updateSubscriptionViewModel.Discount.Value / 100);
        }

        #endregion

        subscription = Mapper.Map(updateSubscriptionViewModel, subscription);

        if (!ModelState.IsValid)
        {
            #region ( Client Side Error )
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور :\n {errors[0]}");
            #endregion

            ViewData["Features"] = await UnitOfWork.FeatureRepository.GetAllAsync();

            return View(updateSubscriptionViewModel);
        }

        #region ( Icon )
        if (updateSubscriptionViewModel.IconFile != null)
        {
            var deletedFile = "";

            if (subscription.Icon != null)
            {
                deletedFile = subscription.Icon;
            }

            #region ( Icon )
            var iconName = await FtpService.UploadFileToFtpServer(updateSubscriptionViewModel.IconFile, TypeFile.Image, Paths.Subscription, updateSubscriptionViewModel.IconFile.FileName, 777, null, null, null, deletedFile);

            subscription.Icon = iconName;
            #endregion
        }
        #endregion

        await UnitOfWork.SubscriptionRepository.UpdateAsync(subscription);

        try
        {
            await UnitOfWork.SaveAsync();

            #region ( Subscription Features )
            if (updateSubscriptionViewModel.Features != null)
            {
                var features = await UnitOfWork.SubscriptionFeatureRepository
                    .GetAllAsync(s => s.SubscriptionId == subscription.Id);

                if (features.Any())
                {
                    UnitOfWork.SubscriptionFeatureRepository.RemoveRange(features);

                    await UnitOfWork.SaveAsync();
                }

                foreach (var featureId in updateSubscriptionViewModel.Features)
                {
                    var feature = new SubscriptionFeature()
                    {
                        FeatureId = featureId,
                        SubscriptionId = subscription.Id
                    };

                    await UnitOfWork.SubscriptionFeatureRepository.InsertAsync(feature);
                }
            }
            #endregion

            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception ex)
        {
            ErrorAlert(ex.ToString());
        }

        return RedirectToAction("Index");
    }
    #endregion

    #region ( Soft Delete )
    [HttpGet]
    public async Task<IActionResult> SetIsDelete(int id, [FromQuery] bool delete)
    {
        await UnitOfWork.SubscriptionRepository.SetIsDelete(id, delete);

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert("عملیات انجام شد");
        }
        catch (Exception ex)
        {
            ErrorAlert(ex.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion

    #region ( Hard Delete )
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var subscription = await UnitOfWork.SubscriptionRepository.GetByIdAsync(id);

        if (subscription == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        var iconFilename = subscription.Icon;

        await UnitOfWork.SubscriptionRepository.DeleteAsync(subscription);

        try
        {
            await UnitOfWork.SaveAsync();

            #region ( Delete File )

            if (!string.IsNullOrWhiteSpace(iconFilename))
            {
                await FtpService.DeleteFileToFtpServer(Paths.Subscription, iconFilename);
            }

            #endregion

            SuccessAlert();
        }
        catch (Exception ex)
        {
            ErrorAlert(ex.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion

    #endregion

    #region ( Features )

    #region ( Index )
    [HttpGet]
    public async Task<IActionResult> IndexFeature()
    {
        var model = await UnitOfWork.FeatureRepository.GetAllAsync();

        return View(model.ToList());
    }
    #endregion

    #region ( Create )
    [HttpGet]
    public IActionResult CreateFeature()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureViewModel createFeatureViewModel)
    {
        if (!ModelState.IsValid)
        {
            #region ( Client Side Error )
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
            #endregion

            return View(createFeatureViewModel);
        }

        var feature = Mapper.Map<Feature>(createFeatureViewModel);

        #region ( Icon )

        if (createFeatureViewModel.Icon != null)
        {
            var iconName = await FtpService.UploadFileToFtpServer(createFeatureViewModel.Icon, TypeFile.Image, Paths.SubscriptionFeature, createFeatureViewModel.Icon.FileName);

            feature.Icon = iconName;
        }

        #endregion

        await UnitOfWork.FeatureRepository.InsertAsync(feature);

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception e)
        {
            ErrorAlert(e.Message);
        }

        return RedirectToAction("IndexFeature");
    }
    #endregion

    #region ( Update )
    [HttpGet]
    public async Task<IActionResult> UpdateFeature(int id)
    {
        var feature = await UnitOfWork.FeatureRepository.GetByIdAsync(id);

        if (feature == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        var model = Mapper.Map<UpdateFeatureViewModel>(feature);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureViewModel updateFeatureViewModel)
    {
        if (!ModelState.IsValid)
        {
            #region ( Client Side Error )
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور :\n {errors[0]}");
            #endregion

            return View(updateFeatureViewModel);
        }

        var feature = await UnitOfWork.FeatureRepository.GetByIdAsync(updateFeatureViewModel.Id);
        if (feature == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        feature = Mapper.Map(updateFeatureViewModel, feature);

        #region ( Icon )
        if (updateFeatureViewModel.IconFile != null)
        {
            var deletedFile = "";

            if (feature.Icon != null)
            {
                deletedFile = feature.Icon;
            }

            var iconName = await FtpService.UploadFileToFtpServer(updateFeatureViewModel.IconFile, TypeFile.Image, Paths.SubscriptionFeature, updateFeatureViewModel.IconFile.FileName, 777, null, null, null, deletedFile);
            if (!string.IsNullOrWhiteSpace(iconName))
            {
                feature.Icon = iconName;
            }
        }
        #endregion

        await UnitOfWork.FeatureRepository.UpdateAsync(feature);

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception ex)
        {
            ErrorAlert(ex.ToString());
        }

        return RedirectToAction("Index");
    }
    #endregion

    #region ( Hard Delete )
    [HttpGet]
    public async Task<IActionResult> DeleteFeature(int id)
    {
        var feature = await UnitOfWork.FeatureRepository.GetByIdAsync(id);

        if (feature == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        var iconFilename = feature.Icon;

        await UnitOfWork.FeatureRepository.DeleteAsync(feature);

        try
        {
            await UnitOfWork.SaveAsync();

            #region ( Delete File )

            if (!string.IsNullOrWhiteSpace(iconFilename))
            {
                await FtpService.DeleteFileToFtpServer(Paths.Subscription, iconFilename);
            }

            #endregion

            SuccessAlert();
        }
        catch (Exception ex)
        {
            ErrorAlert(ex.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion

    #endregion

    #region ( User Subscription )

    #region ( Sell Subscription To User )
    [HttpGet]
    public async Task<IActionResult> SellSubscriptionToUser()
    {
        var subscription = await UnitOfWork.SubscriptionRepository.GetAllAsync();

        var users =
            await UnitOfWork.ApplicationUserRepository.GetAllAsync();

        ViewData["users"] = users;
        ViewData["subscription"] = subscription;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SellSubscriptionToUser(SellSubscriptionViewModel sellSubscriptionViewModel)
    {
        if (!ModelState.IsValid)
        {
            #region ( Client Side Error )
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
            #endregion

            return View(sellSubscriptionViewModel);
        }

        var user = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(sellSubscriptionViewModel.UserId);
        var subscription =
            await UnitOfWork.SubscriptionRepository.GetByIdAsync(sellSubscriptionViewModel.SubscriptionId);

        if (user == null || subscription == null)
        {
            ErrorAlert("مشکلی رخ داده است ، دوباره امتحان کنید");

            return View(sellSubscriptionViewModel);
        }

        try
        {
            #region ( User Subscription )
            var userSubscription = new UserSubscription()
            {
                SubscriptionId = subscription.Id,
                UserId = user.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(subscription.DurationTime),
                IsActive = true,
            };

            var existUserSubscription =
                await UnitOfWork.UserSubscriptionRepository
                    .TableNoTracking.FirstOrDefaultAsync(u => u.UserId == user.Id && u.SubscriptionId == u.SubscriptionId);

            if (existUserSubscription == null)
            {
                userSubscription.BuyCount = 1;
            }
            else
            {
                userSubscription.BuyCount += 1;
            }

            await UnitOfWork.UserSubscriptionRepository.InsertAsync(userSubscription);
            await UnitOfWork.SaveAsync();
            #endregion

            #region ( Payment And Transaction )

            int paymentPortalId =
                await UnitOfWork.PaymentPortalRepository.TableNoTracking.Select(p => p.Id).FirstOrDefaultAsync();

            var payment = new Payment()
            {
                PaymentDate = DateTime.Now,
                Amount = subscription.Price,
                PaymentMethod = PaymentMethod.FromAdmin,
                PaymentPortalId = paymentPortalId,
                UserSubscriptionId = userSubscription.SubscriptionId,
            };

            await UnitOfWork.PaymentRepository.InsertAsync(payment);
            await UnitOfWork.SaveAsync();

            var transaction = new Transaction()
            {
                TransactionDate = DateTime.Now,
                Status = TransactionStatus.Success,
                PaymentId = payment.Id,
            };

            await UnitOfWork.TransactionRepository.InsertAsync(transaction);
            await UnitOfWork.SaveAsync();
            #endregion

            SuccessAlert();
        }
        catch (Exception exception)
        {
            ErrorAlert(exception.Message);
        }

        return RedirectToAction("IndexUserSubscription");
    }
    #endregion

    #region ( Index User Subscription )
    [HttpGet]
    public async Task<IActionResult> IndexUserSubscription(UserSubscriptionFilterViewModel filter)
    {
        var subscription = await UnitOfWork.SubscriptionRepository.GetAllAsync();

        ViewData["subscription"] = subscription;

        return View(UnitOfWork.UserSubscriptionRepository.GetByFilter(filter));
    }
    #endregion

    #endregion
}