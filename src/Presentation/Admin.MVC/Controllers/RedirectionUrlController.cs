

namespace Admin.MVC.Controllers
{
    public class RedirectionUrlController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController
    {
        #region ( DI )
        public IUnitOfWork UnitOfWork { get; } = unitOfWork;
        public IMapper Mapper { get; } = mapper;

        #endregion

        #region ( Index )
        public IActionResult Index(RedirectionUrlFilterViewModel filter)
        {
            var model = UnitOfWork.RedirectionUrlRepository.GetByFilterAdmin(filter);

            return View(model);
        }
        #endregion

        #region ( Create )
        [HttpPost]
        public async Task<IActionResult> Create(CreateRedirectionUrlViewModel createRedirectionUrlViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                return RedirectToAction("Index");
                #endregion
            }

            var redirectionUrl = Mapper.Map<RedirectionUrl>(createRedirectionUrlViewModel);

            await UnitOfWork.RedirectionUrlRepository.InsertAsync(redirectionUrl);

            try
            {
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
            var redirectionUrl = await UnitOfWork.RedirectionUrlRepository.GetByIdAsync(id);

            var model = Mapper.Map<UpdateRedirectionUrlViewModel>(redirectionUrl);

            return PartialView("_Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRedirectionUrlViewModel updateRedirectionUrlViewModel)
        {
            var redirectionUrl = await UnitOfWork.RedirectionUrlRepository.GetByIdAsync(updateRedirectionUrlViewModel.Id);

            redirectionUrl = Mapper.Map(updateRedirectionUrlViewModel, redirectionUrl);

            await UnitOfWork.RedirectionUrlRepository.UpdateAsync(redirectionUrl);

            try
            {
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

        #region ( Delete )
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var redirectionUrl = await UnitOfWork.RedirectionUrlRepository.GetByIdAsync(id);

            if (redirectionUrl != null)
            {
                await UnitOfWork.RedirectionUrlRepository.DeleteAsync(redirectionUrl);
            }

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
    }
}
