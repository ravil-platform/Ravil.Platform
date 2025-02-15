using System.Globalization;
using Domain.Entities.Order;
using ViewModels.AdminPanel.Filter;
using ViewModels.Discounts;

namespace Admin.MVC.Controllers
{
    public class DiscountsController : BaseController
    {
        #region ( DI )
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
        public DiscountsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        #endregion

        #region ( Index )
        [HttpGet]
        public IActionResult Index(PromotionCodeFilterViewModel filter)
        {
            return View(UnitOfWork.PromotionCodeRepository.GetByFilter(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountViewModel createDiscountViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Side Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                return View(createDiscountViewModel);
                #endregion
            }

            var promotionCode = Mapper.Map<PromotionCode>(createDiscountViewModel);

            if (createDiscountViewModel.ExpireDate != null)
            {
                PersianCalendar persianCalendar = new PersianCalendar();

                int Year = createDiscountViewModel.ExpireDate.Value.Year;
                int Month = createDiscountViewModel.ExpireDate.Value.Month;
                int Day = createDiscountViewModel.ExpireDate.Value.Day;

                DateTime expireDateTime = persianCalendar.ToDateTime(Year, Month, Day, 00, 00, 00, 00);

                promotionCode.ExpireDate = expireDateTime;
            }
            else if (createDiscountViewModel.ExpireDateString != null)
            {
                #region (Fix Bug In Shmasi Calendar)
                if (createDiscountViewModel.ExpireDateString.ShamsiDateToDateTime() != null)
                {
                    DateTime expireDateTime = (DateTime)createDiscountViewModel.ExpireDateString.ShamsiDateToDateTime();

                    promotionCode.ExpireDate = expireDateTime;
                }
                #endregion
            }

            promotionCode.CreateDate = DateTime.Now;

            await UnitOfWork.PromotionCodeRepository.InsertAsync(promotionCode);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch
            {
                ErrorAlert();
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var promotionCode = await UnitOfWork.PromotionCodeRepository.GetByIdAsync(id);

            if (promotionCode == null)
            {
                return RedirectToAction("Index");
            }

            if (promotionCode.ExpireDate != null)
            {
                ViewData["ExpireDate"] = promotionCode.ExpireDate.ToShamsiDate();
            }


            var model = Mapper.Map<UpdateDiscountViewModel>(promotionCode);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDiscountViewModel updateDiscountViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Side Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                return View(updateDiscountViewModel);
                #endregion
            }

            #region ( Get Current )
            var promotionCode = await UnitOfWork.PromotionCodeRepository.GetByIdAsync(updateDiscountViewModel.Id);

            if (promotionCode == null)
            {
                ErrorAlert("اطلاعات یافت نشد!");

                return RedirectToAction("Index");
            }
            #endregion

            var model = Mapper.Map(updateDiscountViewModel, promotionCode);

            if (updateDiscountViewModel.ExpireDate != null)
            {
                PersianCalendar PersianCalendar = new PersianCalendar();

                int Year = updateDiscountViewModel.ExpireDate.Value.Year;
                int Month = updateDiscountViewModel.ExpireDate.Value.Month;
                int Day = updateDiscountViewModel.ExpireDate.Value.Day;

                DateTime expireDateTime = PersianCalendar.ToDateTime(Year, Month, Day, 00, 00, 00, 00);

                model.ExpireDate = expireDateTime;
            }
            else if (updateDiscountViewModel.ExpireDateString != null)
            {
                #region (Fix Bug In Shmasi Calendar)
                if (updateDiscountViewModel.ExpireDateString.ShamsiDateToDateTime() != null)
                {
                    DateTime expireDateTime = (DateTime)updateDiscountViewModel.ExpireDateString.ShamsiDateToDateTime();

                    model.ExpireDate = expireDateTime;
                }
                #endregion
            }

            await UnitOfWork.PromotionCodeRepository.UpdateAsync(model);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region ( Delete )
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var promotionCode = await UnitOfWork.PromotionCodeRepository.GetByIdAsync(id);

            if (promotionCode == null)
            {
                ErrorAlert("اطلاعات یافت نشد!");
                return RedirectToAction("Index");
            }

            return PartialView("_Delete", promotionCode);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var promotionCode = await UnitOfWork.PromotionCodeRepository.GetByIdAsync(id);

                await UnitOfWork.PromotionCodeRepository.DeleteAsync(promotionCode);

                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region ( Set Activation )
        [HttpGet]
        public async Task<IActionResult> SetActivation(int id, bool status)
        {
            var discount = await UnitOfWork.PromotionCodeRepository.GetByPredicate(d => d.Id == id);

            if (discount == null)
            {
                ErrorAlert();
                return RedirectToAction("Index");
            }

            discount.IsActiveForDiscounts = status;

            try
            {
                await UnitOfWork.PromotionCodeRepository.UpdateAsync(discount);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region ( Set Use Limit )
        [HttpGet]
        public async Task<IActionResult> SetUseLimit(int id, bool status)
        {
            var discount = await UnitOfWork.PromotionCodeRepository.GetByPredicate(d => d.Id == id);

            if (discount == null)
            {
                ErrorAlert();
                return RedirectToAction("Index");
            }

            discount.IsUseLimit = status;

            try
            {
                await UnitOfWork.PromotionCodeRepository.UpdateAsync(discount);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region ( Set Activation For Discount )
        [HttpGet]
        public async Task<IActionResult> SetIsActiveForDiscounts(int id, bool status)
        {
            var discount = await UnitOfWork.PromotionCodeRepository.GetByPredicate(d => d.Id == id);

            if (discount == null)
            {
                ErrorAlert();
                return RedirectToAction("Index");
            }

            discount.IsActiveForDiscounts = status;

            try
            {
                await UnitOfWork.PromotionCodeRepository.UpdateAsync(discount);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}
