using AutoMapper;
using Domain.Entities.Faq;
using ViewModels.Faq;

namespace Admin.MVC.Controllers
{
    public class FaqController : BaseController
    {
        #region ( DI )
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
        public FaqController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        #endregion

        #region ( Index )
        public async Task<IActionResult> Index()
        {
            var model = await UnitOfWork.FaqRepository.GetAllAsync(CancellationToken.None);

            return View(model);
        }
        #endregion

        #region ( Create )
        [HttpPost]
        public async Task<IActionResult> Create(CreateFaqViewModel createFaqViewModel)
        {
            if (!ModelState.IsValid)
            {
                ErrorAlert();

                return RedirectToAction();
            }

            var faq = Mapper.Map<Faq>(createFaqViewModel);

            await UnitOfWork.FaqRepository.InsertAsync(faq, CancellationToken.None);

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
        public async Task<IActionResult> Update(Guid id)
        {
            var faq = await UnitOfWork.FaqRepository.GetByIdAsync(id, CancellationToken.None);

            var model = Mapper.Map<UpdateFaqViewModel>(faq);

            return PartialView("_Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFaqViewModel updateFaqViewModel)
        {
            var faq = await UnitOfWork.FaqRepository.GetByIdAsync(updateFaqViewModel.Id, CancellationToken.None);

            faq = Mapper.Map(updateFaqViewModel, faq);

            await UnitOfWork.FaqRepository.UpdateAsync(faq, CancellationToken.None);

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

        #region ( Detail )
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await UnitOfWork.FaqRepository.GetByIdAsync(id, CancellationToken.None);

            return View(model);
        }
        #endregion

        #region ( Delete )
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await UnitOfWork.FaqRepository.DeleteAsync(id, CancellationToken.None);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion
    }
}
