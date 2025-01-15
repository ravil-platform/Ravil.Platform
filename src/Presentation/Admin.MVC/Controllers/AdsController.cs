using Domain.Entities.Job;
using Enums;
using Microsoft.EntityFrameworkCore;
using ViewModels.AdminPanel.Filter;

namespace Admin.MVC.Controllers
{
    public class AdsController : BaseController
    {
        #region ( DI )
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
        public AdsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        #endregion

        #region ( Job Branch Ads )
        [HttpGet]
        public IActionResult IndexJobBranchAds(JobBranchAdsFilterViewModel filter)
        {
            return View(UnitOfWork.JobBranchAdsRepository.GetByFilterAdmin(filter));
        }

        [HttpGet]
        public async Task<IActionResult> CreateJobBranchAds()
        {
            #region ( Fill View Data ) 
            var categories = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.ParentId != 0 && c.NodeLevel == 3);
            ViewData["categories"] = categories;

            var jobBranches = await UnitOfWork.JobBranchRepository.TableNoTracking
                .Where(j => j.Status == JobBranchStatus.Accepted)
                .Include(j => j.Job).ToListAsync();

            ViewData["jobBranches"] = jobBranches;
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobBranchAds(int[] categoryIds, string JobBranchId, JobBranchAds jobBranchAds)
        {
            if (JobBranchId == null)
            {
                ErrorAlert("مقادیر نباید خالی باشد");

                return RedirectToAction("IndexJobBranchAds");
            }

            try
            {
                var currentJobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(JobBranchId);
                if (currentJobBranch == null)
                {
                    ErrorAlert("شغل یافت نشد");

                    return RedirectToAction("IndexJobBranchAds");
                }

                if (categoryIds.Length != 0)
                {
                    foreach (var categoryId in categoryIds)
                    {
                        var currentCategory = await UnitOfWork.CategoryRepository.GetByIdAsync(categoryId);

                        var newJobBranchAds = new JobBranchAds()
                        {
                            JobBranchId = currentJobBranch.Id,
                            JobBranchName = currentJobBranch.Title!,

                            CategoryName = currentCategory.Name,
                            CategoryId = currentCategory.Id,

                            Pinned = jobBranchAds.Pinned,
                            Sort = jobBranchAds.Sort
                        };

                        await UnitOfWork.JobBranchAdsRepository.InsertAsync(newJobBranchAds);
                    }
                }
                else
                {
                    var newJobBranchAds = new JobBranchAds()
                    {
                        JobBranchId = currentJobBranch.Id,
                        JobBranchName = currentJobBranch.Title,

                        CategoryName = null,
                        CategoryId = 0,

                        Pinned = true,
                        Sort = jobBranchAds.Sort
                    };

                    await UnitOfWork.JobBranchAdsRepository.InsertAsync(newJobBranchAds);

                }

                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexJobBranchAds");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteJobBranchAds(int id)
        {
            var jobBranchAds = await UnitOfWork.JobBranchAdsRepository.GetByIdAsync(id);

            if (jobBranchAds != null)
            {
                await UnitOfWork.JobBranchAdsRepository.DeleteAsync(jobBranchAds);
            }

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch
            {
                ErrorAlert();
            }

            return RedirectToAction("IndexJobBranchAds");
        }
        #endregion

        // todo : move to job branch controller
        #region ( Job Branch Related Job )
        //[HttpGet]
        //public async Task<IActionResult> IndexJobBranchRelatedJob(int? pageNumber)
        //{
        //    var pageNum = pageNumber ?? 1;
        //    var onePageOfData = await db.JobBranchRelatedJobs.AsNoTracking().ToPagedListAsync(pageNum, 15);
        //    ViewBag.data = onePageOfData;
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> CreateJobBranchRelatedJob()
        //{
        //    var cities = await db.City.AsNoTracking().ToListAsync();
        //    ViewData["cities"] = cities;

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateJobBranchRelatedJob(int currentCityId, string hiddenDisplayedCityIds, JobBranchRelatedJob jobBranchRelatedJob)
        //{
        //    string[] hiddenDisplayedCityIdsArray = hiddenDisplayedCityIds.Split(',');

        //    if (currentCityId == null || hiddenDisplayedCityIdsArray.Length == 0)
        //    {
        //        TempData["msg"] = "مقادیر نباید خالی باشند. |danger";

        //        return RedirectToAction("IndexJobBranchRelatedJob");
        //    }

        //    try
        //    {
        //        var currentCity = await db.City.SingleOrDefaultAsync(c => c.Id == currentCityId);
        //        if (currentCity == null)
        //        {
        //            TempData["msg"] = "شهر یافت نشد. |danger";

        //            return RedirectToAction("IndexJobBranchRelatedJob");
        //        }

        //        int sort = jobBranchRelatedJob.Sort;

        //        foreach (var displayedCityId in hiddenDisplayedCityIdsArray)
        //        {
        //            var displayedCity = await db.City.SingleOrDefaultAsync(c => c.Id == Convert.ToInt32(displayedCityId));

        //            var newJobBranchRelatedJob = new JobBranchRelatedJob()
        //            {
        //                CurrentCityId = currentCity.Id,
        //                CurrentCityName = currentCity.Subtitle,

        //                DisplayedCityId = displayedCity.CityBaseId,
        //                DisplayedCityName = displayedCity.Subtitle,

        //                Sort = sort,
        //            };

        //            await db.JobBranchRelatedJobs.AddAsync(newJobBranchRelatedJob);

        //            sort++;
        //        }

        //        await db.SaveChangesAsync();

        //        TempData["msg"] = "عملیات موفقیت آمیز بود. |success";
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.InnerException?.Message ?? e.Message);
        //        TempData["msg"] = "عملیات با خطا مواجه شد. |danger";
        //    }

        //    return RedirectToAction("IndexJobBranchRelatedJob");
        //}

        //[HttpGet]
        //public async Task<IActionResult> DeleteJobRelatedJob(int jobRelatedId)
        //{
        //    var jobBranchRelatedJob = await db.JobBranchRelatedJobs.SingleOrDefaultAsync(t => t.Id == jobRelatedId);

        //    if (jobBranchRelatedJob != null)
        //    {
        //        db.JobBranchRelatedJobs.Remove(jobBranchRelatedJob);
        //    }

        //    try
        //    {
        //        await db.SaveChangesAsync();

        //        TempData["msg"] = "عملیات موفقیت آمیز بود. |success";
        //    }
        //    catch
        //    {
        //        TempData["msg"] = "عملیات با خطا مواجه شد. |danger";
        //    }

        //    return RedirectToAction("IndexJobBranchRelatedJob");
        //}
        #endregion
    }
}
