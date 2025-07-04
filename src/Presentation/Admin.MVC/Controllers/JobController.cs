﻿using Constants;
using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Persistence.Context;
using CreateJobBranchViewModel = ViewModels.AdminPanel.Job.CreateJobBranchViewModel;
using JsonSerializer = System.Text.Json.JsonSerializer;
using PhoneNumberInfosViewModel = ViewModels.AdminPanel.Job.PhoneNumberInfosViewModel;
using SocialMediaInfosViewModel = ViewModels.AdminPanel.Job.SocialMediaInfosViewModel;
using UpdateJobBranchViewModel = ViewModels.AdminPanel.Job.UpdateJobBranchViewModel;

namespace Admin.MVC.Controllers
{
    public class JobController(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IFtpService ftpService,
        ISmsSender smsSender,
        UserManager<ApplicationUser> userManager,
        NeshanApiService neshanApiService,
        Logging.Base.ILogger<JobController> logger,
        IDistributedCache distributedCache)
    : BaseController
    {
        #region ( DI )
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IMapper Mapper { get; } = mapper;
        protected IFtpService FtpService { get; } = ftpService;
        protected ISmsSender SmsSender { get; } = smsSender;
        protected IDistributedCache DistributedCache { get; } = distributedCache;
        protected UserManager<ApplicationUser> UserManager { get; } = userManager;
        protected NeshanApiService NeshanApiService { get; } = neshanApiService;
        protected Logging.Base.ILogger<JobController> Logger { get; } = logger;
        #endregion

        #region ( Job )
        #region ( Index )
        [HttpGet]
        public async Task<IActionResult> IndexJob(JobFilterViewModel filter)
        {
            var users = await UnitOfWork.ApplicationUserRepository.GetAllAsync();

            ViewData["users"] = users;

            return View(UnitOfWork.JobRepository.GetByAdminFilter(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> CreateJob()
        {
            #region ( Fill View Datas )
            ViewData["brands"] = await UnitOfWork.BrandRepository.TableNoTracking.ToListAsync();
            ViewData["categories"] = await UnitOfWork.CategoryRepository.TableNoTracking.ToListAsync();
            ViewData["tags"] = await UnitOfWork.TagRepository.Table.Where(a => a.Type.Equals(TagType.JobBranch)).AsNoTracking().ToListAsync();
            ViewData["usersPhoneNumbers"] = await UnitOfWork.ApplicationUserRepository.Table.AsNoTracking().Select(u => new UserPhoneNumberViewModel()
            {
                PhoneNumber = u.PhoneNumber,
                Id = u.Id
            }).Distinct().ToListAsync();
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(ViewModels.AdminPanel.Job.CreateJobViewModel createJobViewModel)
        {
            var job = Mapper.Map<Job>(createJobViewModel);

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                #region ( Fill View Datas )
                ViewData["brands"] = await UnitOfWork.BrandRepository.TableNoTracking.ToListAsync();
                ViewData["categories"] = await UnitOfWork.CategoryRepository.TableNoTracking.ToListAsync();
                ViewData["tags"] = await UnitOfWork.TagRepository.Table.Where(a => a.Type.Equals(TagType.JobBranch)).AsNoTracking().ToListAsync();
                ViewData["usersPhoneNumbers"] = await UnitOfWork.ApplicationUserRepository.Table.AsNoTracking().Select(u => new UserPhoneNumberViewModel()
                {
                    PhoneNumber = u.PhoneNumber,
                    Id = u.Id
                }).Distinct().ToListAsync();
                #endregion

                return View(createJobViewModel);
            }

            #region ( Check route is duplicated or not )
            bool jobResult = await UnitOfWork.JobRepository.JobRouteExist(createJobViewModel.Route);
            bool jobBranchResult = await UnitOfWork.JobRepository.JobBranchRouteExist(createJobViewModel.Route);

            if (jobResult || jobBranchResult)
            {
                ErrorAlert(Errors.RouteDuplicate);

                #region ( Fill View Datas )
                ViewData["brands"] = await UnitOfWork.BrandRepository.TableNoTracking.ToListAsync();
                ViewData["categories"] = await UnitOfWork.CategoryRepository.TableNoTracking.ToListAsync();
                ViewData["tags"] = await UnitOfWork.TagRepository.Table.Where(a => a.Type.Equals(TagType.JobBranch)).AsNoTracking().ToListAsync();
                ViewData["usersPhoneNumbers"] = await UnitOfWork.ApplicationUserRepository.Table.AsNoTracking().Select(u => new UserPhoneNumberViewModel()
                {
                    PhoneNumber = u.PhoneNumber,
                    Id = u.Id
                }).Distinct().ToListAsync();
                #endregion

                return View(createJobViewModel);
            }
            #endregion

            #region ( Job )
            var largePictureName = await FtpService.UploadFileToFtpServer(createJobViewModel.LargePictureFile, TypeFile.Image, Paths.Job, createJobViewModel.LargePictureFile.FileName);
            var smallPictureName = await FtpService.UploadFileToFtpServer(createJobViewModel.SmallPictureFile, TypeFile.Image, Paths.Job, createJobViewModel.SmallPictureFile.FileName);

            job.LargePicture = largePictureName;
            job.SmallPicture = smallPictureName;

            job.SocialMediaInfos = createJobViewModel.SocialMediaInfos != null ? JsonSerializer.Serialize(createJobViewModel.SocialMediaInfos) : string.Empty;
            job.PhoneNumberInfos = createJobViewModel.PhoneNumberInfos != null ? JsonSerializer.Serialize(createJobViewModel.PhoneNumberInfos) : string.Empty;

            job.Route = job.Route.ToSlug();
            job.CreateDate = DateTime.Now;
            job.Status = JobBranchStatus.Accepted;

            //Todo : set adminId
            // check if user id is null set admin id
            job.AdminId = createJobViewModel.UserOwnerId ?? "";
            // job.AdminId = Guid.Parse(User.Identity.GetUserId());

            await UnitOfWork.JobRepository.InsertAsync(job);
            #endregion

            try
            {
                await UnitOfWork.SaveAsync();

                #region ( Tags )
                if (createJobViewModel.Tags != null)
                {
                    foreach (var tagId in createJobViewModel.Tags)
                    {
                        var jobTag = new JobTag()
                        {
                            JobId = job.Id,
                            TagId = tagId
                        };

                        await UnitOfWork.JobTagRepository.InsertAsync(jobTag);
                    }
                }
                #endregion

                #region ( Categories )
                if (createJobViewModel.Categories.Length > 0)
                {
                    foreach (var categoryId in createJobViewModel.Categories)
                    {
                        var jobCategory = new JobCategory()
                        {
                            JobId = job.Id,
                            CategoryId = categoryId
                        };

                        await UnitOfWork.JobCategoryRepository.InsertAsync(jobCategory);
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

            return RedirectToAction("IndexJob");
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> UpdateJob(int id)
        {
            #region ( Fill View Datas )
            ViewData["brands"] = await UnitOfWork.BrandRepository.TableNoTracking.ToListAsync();
            ViewData["categories"] = await UnitOfWork.CategoryRepository.TableNoTracking.ToListAsync();
            ViewData["tags"] = await UnitOfWork.TagRepository.Table.Where(a => a.Type.Equals(TagType.JobBranch)).AsNoTracking().ToListAsync();
            ViewData["usersPhoneNumbers"] = await UnitOfWork.ApplicationUserRepository.Table.AsNoTracking().Select(u => new UserPhoneNumberViewModel()
            {
                PhoneNumber = u.PhoneNumber,
                Id = u.Id
            }).Distinct().ToListAsync();
            #endregion

            var job = await UnitOfWork.JobRepository.Table.Include(j => j.JobCategories).SingleOrDefaultAsync(j => j.Id == id);

            var jobBranch = await UnitOfWork.JobBranchRepository.Table.Where(j => j.JobId == job.Id)
                .FirstOrDefaultAsync();

            if (jobBranch == null)
            {
                ErrorAlert("برای این کسب و کار شعبه ای ثبت نشده است");

                return RedirectToAction("IndexJob");
            }

            var model = Mapper.Map<UpdateJobViewModel>(job);

            model.CurrentLargePicture = job.LargePicture;
            model.CurrentSmallPictureFile = job.SmallPicture;
            model.CurrentSocialMediaInfos = job.SocialMediaInfos;
            model.CurrentPhoneNumberInfos = job.PhoneNumberInfos;
            model.Categories = job.JobCategories.Select(j => j.CategoryId).ToArray();
            model.UserOwnerId = jobBranch.UserId;

            #region ( previous Page )
            string previousPage = Request.Headers["Referer"].ToString();
            ViewData["previousPage"] = previousPage;
            #endregion

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJob(UpdateJobViewModel updateJobViewModel, string? previousPage)
        {
            var job = await UnitOfWork.JobRepository.GetByIdAsync(updateJobViewModel.Id);

            #region ( Job is null )
            if (job == null)
            {
                ErrorAlert("چیزی یافت نشد!");

                return RedirectToAction("IndexJob");
            }
            #endregion

            #region ( Update Job )
            job = Mapper.Map(updateJobViewModel, job);

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور :\n {errors[0]}");

                #region ( Fill View Datas )
                ViewData["brands"] = await UnitOfWork.BrandRepository.TableNoTracking.ToListAsync();
                ViewData["categories"] = await UnitOfWork.CategoryRepository.TableNoTracking.ToListAsync();
                ViewData["tags"] = await UnitOfWork.TagRepository.Table.Where(a => a.Type.Equals(TagType.JobBranch)).AsNoTracking().ToListAsync();
                ViewData["usersPhoneNumbers"] = await UnitOfWork.ApplicationUserRepository.Table.AsNoTracking().Select(u => new UserPhoneNumberViewModel()
                {
                    PhoneNumber = u.PhoneNumber,
                    Id = u.Id
                }).Distinct().ToListAsync();
                #endregion

                return View(updateJobViewModel);
            }

            #region ( Picture )
            #region ( Descktop )
            if (updateJobViewModel.LargePictureFile != null)
            {
                var deletedFile = "";

                if (!string.IsNullOrWhiteSpace(job.LargePicture))
                {
                    deletedFile = job.LargePicture;
                }

                var pictureName = await FtpService.UploadFileToFtpServer(updateJobViewModel.LargePictureFile, TypeFile.Image, Paths.Job, updateJobViewModel.LargePictureFile.FileName, 777, null, null, null, deletedFile);

                job.LargePicture = pictureName;
            }
            #endregion

            #region ( Mobile )
            if (updateJobViewModel.SmallPictureFile != null)
            {
                var deletedFile = "";

                if (!string.IsNullOrWhiteSpace(job.SmallPicture))
                {
                    deletedFile = job.SmallPicture;
                }

                var mobilePictureName = await FtpService.UploadFileToFtpServer(updateJobViewModel.SmallPictureFile, TypeFile.Image, Paths.Job, updateJobViewModel.SmallPictureFile.FileName, 777, null, null, null, deletedFile);

                job.SmallPicture = mobilePictureName;
            }
            #endregion
            #endregion

            if (updateJobViewModel.SocialMediaInfosViewModel != null)
            {
                job.SocialMediaInfos = JsonSerializer.Serialize(updateJobViewModel.SocialMediaInfosViewModel);
            }

            if (updateJobViewModel.PhoneNumberInfosViewModel != null)
            {
                job.PhoneNumberInfos = JsonSerializer.Serialize(updateJobViewModel.PhoneNumberInfosViewModel);
            }

            job.Route = job.Route.ToSlug();
            job.LastUpdateDate = DateTime.Now;

            await UnitOfWork.JobRepository.UpdateAsync(job!);
            #endregion

            #region ( Change Status And Send Sms )
            var sendSms = "";
            var phoneNumber = "";
            var userId = updateJobViewModel.UserOwnerId;

            if (job.Status == JobBranchStatus.Rejected)
            {
                if (userId != null)
                {
                    phoneNumber = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                        .Where(d => d.Id == userId)
                        .Select(u => u.PhoneNumber).SingleOrDefaultAsync();

                    if (phoneNumber != null)
                    {
                        sendSms = "rejectedJob";
                    }
                }


                //Message Box 
                await UnitOfWork.MessageBoxRepository.SendMessage(job.Id, MessageBoxType.Info,
                     MessageBoxDefault.RejectJob);

            }

            if (job.Status == JobBranchStatus.Accepted)
            {
                if (userId != null)
                {
                    phoneNumber = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                        .Where(d => d.Id == userId)
                        .Select(u => u.PhoneNumber)
                        .SingleOrDefaultAsync();

                    if (phoneNumber != null)
                    {
                        sendSms = "acceptedJob";
                    }
                }

                //Message Box 
                await UnitOfWork.MessageBoxRepository.SendMessage(job.Id, MessageBoxType.Info,
                    MessageBoxDefault.AcceptJob);
            }

            #endregion

            #region ( Update Branches )
            var jobBranches = await UnitOfWork.JobBranchRepository.GetAllAsync(j => j.JobId == job.Id);

            if (jobBranches.Any())
            {
                foreach (var currentJobBranch in jobBranches)
                {
                    currentJobBranch.Status = job.Status;
                    currentJobBranch.RejectedReason = job.RejectedReason;
                    currentJobBranch.Route = job.Route;
                    currentJobBranch.AdminId = userId;

                    await UnitOfWork.JobBranchRepository.UpdateAsync(currentJobBranch);
                }
            }
            #endregion

            try
            {
                await UnitOfWork.SaveAsync();

                #region ( Tags )
                if (updateJobViewModel.Tags != null)
                {
                    var tags = await UnitOfWork.JobTagRepository.GetAllAsync(t => t.JobId == updateJobViewModel.Id);
                    UnitOfWork.JobTagRepository.RemoveRange(tags);
                    await UnitOfWork.SaveAsync();


                    foreach (var tagId in updateJobViewModel.Tags)
                    {
                        var jobTag = new JobTag()
                        {
                            JobId = job.Id,
                            TagId = tagId
                        };

                        await UnitOfWork.JobTagRepository.InsertAsync(jobTag);
                    }
                }
                #endregion

                #region ( Categories )
                if (updateJobViewModel.Categories.Length > 0)
                {
                    var categories = await UnitOfWork.JobCategoryRepository.GetAllAsync(t => t.JobId == updateJobViewModel.Id);
                    UnitOfWork.JobCategoryRepository.RemoveRange(categories);
                    await UnitOfWork.SaveAsync();


                    foreach (var categoryId in updateJobViewModel.Categories)
                    {
                        var jobCategory = new JobCategory()
                        {
                            JobId = job.Id,
                            CategoryId = categoryId
                        };

                        await UnitOfWork.JobCategoryRepository.InsertAsync(jobCategory);
                    }
                }
                #endregion

                await UnitOfWork.SaveAsync();

                #region ( Remove Cache Data )

                foreach (var jobBranch in jobBranches)
                {
                    await DistributedCache.RemoveAsync(key: CacheKeys.GetJobBranchByIdQuery(jobBranch.Id));
                    await DistributedCache.RemoveAsync(key: CacheKeys.GetJobBranchByRouteQuery(updateJobViewModel.Route!));
                }

                #endregion

                SuccessAlert();

                if (updateJobViewModel.SendSms)
                {
                    if (sendSms == "acceptedJob")
                    {
                        await SmsSender.SendPattern(phoneNumber, null, "acceptedJob");
                    }

                    if (sendSms == "rejectedJob")
                    {
                        await SmsSender.SendPattern(phoneNumber, null, "rejectedJob");
                    }
                }

            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            if (previousPage != null)
            {
                return Redirect(previousPage);
            }

            return RedirectToAction("IndexJob");
        }
        #endregion

        #region ( Soft Delete )
        [HttpGet]
        public async Task<IActionResult> SetIsDelete(int id, [FromQuery] bool delete)
        {
            await UnitOfWork.JobRepository.SetIsDelete(id, delete);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert("حذف سیستمی انجام شد");
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("IndexJob");
        }
        #endregion

        #region ( Hard Delete )
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await UnitOfWork.JobRepository.BeginTransactionAsync();

                #region ( Entities )
                //Todo : Remove photos
                var job = await UnitOfWork.JobRepository.Table.Where(j => j.Id == id).SingleOrDefaultAsync();

                if (job == null)
                {
                    ErrorAlert("شغل یافت نشد!");

                    return RedirectToAction("IndexJob");
                }

                var jobBranches = await UnitOfWork.JobBranchRepository.Table.Where(j => j.JobId == id).ToListAsync();

                foreach (var branch in jobBranches)
                {
                    var banners = await UnitOfWork.BannerRepository.GetAllAsync(b => b.JobBranchId == branch.Id);
                    UnitOfWork.BannerRepository.RemoveRange(banners);

                    foreach (var banner in banners)
                    {
                        await FtpService.DeleteFileToFtpServer(Paths.Banner, banner.LargePicture);
                        await FtpService.DeleteFileToFtpServer(Paths.Banner, banner.SmallPicture);
                    }

                    // Save Start
                    await UnitOfWork.SaveAsync();
                    // Save Finish

                    var comments = await UnitOfWork.CommentRepository.GetAllAsync(c => c.JobBranchId == branch.Id);

                    foreach (var comment in comments)
                    {
                        var answerComments =
                            await UnitOfWork.AnswerCommentRepository.GetAllAsync(c => c.CommentId == comment.Id);
                        UnitOfWork.AnswerCommentRepository.RemoveRange(answerComments);

                        // Save Start
                        await UnitOfWork.SaveAsync();
                        // Save Finish
                    }

                    UnitOfWork.CommentRepository.RemoveRange(comments);

                    var mainSliders = await UnitOfWork.MainSliderRepository.GetAllAsync(c => c.JobBranchId == branch.Id);
                    UnitOfWork.MainSliderRepository.RemoveRange(mainSliders);

                    var jobServices = await UnitOfWork.JobServiceRepository.GetAllAsync(c => c.JobBranchId == branch.Id);
                    UnitOfWork.JobServiceRepository.RemoveRange(jobServices);

                    var jobBranchShortLinks = await UnitOfWork.JobBranchShortLinkRepository.GetAllAsync(c => c.JobBranchId == branch.Id);
                    UnitOfWork.JobBranchShortLinkRepository.RemoveRange(jobBranchShortLinks);

                    var jobBranchTags = await UnitOfWork.JobBranchTagRepository.GetAllAsync(c => c.JobBranchId == branch.Id);
                    UnitOfWork.JobBranchTagRepository.RemoveRange(jobBranchTags);

                    var jobTimeWorks = await UnitOfWork.JobTimeWorkRepository.GetAllAsync(c => c.JobBranchId == branch.Id);
                    UnitOfWork.JobTimeWorkRepository.RemoveRange(jobTimeWorks);

                    // Save Start
                    await UnitOfWork.SaveAsync();
                    // Save Finish

                }

                var jobTags = await UnitOfWork.JobTagRepository.Table.Where(j => j.JobId == job.Id).ToListAsync();
                UnitOfWork.JobTagRepository.RemoveRange(jobTags);

                //var jobBranches = await UnitOfWork.JobBranchRepository.Table.Where(j => j.JobId == job.Id).ToListAsync();



                foreach (var jobBranch in jobBranches)
                {
                    var addresses = await UnitOfWork.AddressRepository.GetAllAsync(a => a.JobBranchId == jobBranch.Id);
                    UnitOfWork.AddressRepository.RemoveRange(addresses);

                    // Save Start
                    await UnitOfWork.SaveAsync();
                    // Save Finish

                    if (jobBranch.LargePicture != null)
                    {
                        await FtpService.DeleteFileToFtpServer($"{Paths.JobBranch}/{jobBranch.Id}", jobBranch.LargePicture);
                    }

                    if (jobBranch.SmallPicture != null)
                    {
                        await FtpService.DeleteFileToFtpServer($"{Paths.JobBranch}/{jobBranch.Id}", jobBranch.SmallPicture);
                    }
                }

                UnitOfWork.JobBranchRepository.RemoveRange(jobBranches);

                var jobCategories = await UnitOfWork.JobCategoryRepository.Table.Where(j => j.JobId == job.Id).ToListAsync();
                UnitOfWork.JobCategoryRepository.RemoveRange(jobCategories);

                // Save Start
                await UnitOfWork.SaveAsync();
                // Save Finish

                if (!string.IsNullOrEmpty(job.LargePicture))
                {
                    await FtpService.DeleteFileToFtpServer(Paths.Job, job.LargePicture);
                }

                if (!string.IsNullOrEmpty(job.SmallPicture))
                {
                    await FtpService.DeleteFileToFtpServer(Paths.Job, job.SmallPicture);
                }

                await UnitOfWork.JobRepository.DeleteAsync(job);

                // Save Start
                await UnitOfWork.SaveAsync();
                // Save Finish
                #endregion

                await UnitOfWork.JobRepository.CommitTransactionAsync();

                #region ( Remove Cache Data )

                await DistributedCache.RemoveAsync(key: CacheKeys.JobReportQuery(id));
                await DistributedCache.RemoveAsync(key: CacheKeys.GetJobViewsQuery(id));
                await DistributedCache.RemoveAsync(key: CacheKeys.JobOverViewQuery(id));
                await DistributedCache.RemoveAsync(key: CacheKeys.GetRelatedJobsQuery(id));
                await DistributedCache.RemoveAsync(key: CacheKeys.GetTagsPotentialQuery(id));
                await DistributedCache.RemoveAsync(key: CacheKeys.GetContactRequestsQuery(id));
                await DistributedCache.RemoveAsync(key: CacheKeys.GetJobRankingsByFilterQuery(id));
                await DistributedCache.RemoveAsync(key: CacheKeys.GetJobStatisticsByFilterQuery(id));

                foreach (var jobBranch in jobBranches)
                {
                    await DistributedCache.RemoveAsync(key: CacheKeys.GetJobBranchByIdQuery(jobBranch.Id));
                    await DistributedCache.RemoveAsync(key: CacheKeys.GetReviewsSummeryQuery(jobBranch.Id));
                    await DistributedCache.RemoveAsync(key: CacheKeys.GetJobBranchByRouteQuery(jobBranch.Route!));
                }

                #endregion

                SuccessAlert("حذف فیزیکی به طور کامل انجام شد");
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            #region ( previous Page )
            if (Request.Headers["Referer"].ToString() != null)
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }
            #endregion

            return RedirectToAction("IndexJob", new { IsDeleted = true });
        }
        #endregion

        #region ( SlugExist )
        [HttpPost]
        public async Task<IActionResult> SlugExist([FromBody] string route)
        {
            if (string.IsNullOrEmpty(route))
            {
                return BadRequest("مقدار وارد شده معتبر نیست.");
            }

            bool exists = await UnitOfWork.JobRepository.JobRouteExist(route);

            return Json(new { exists = exists });
        }
        #endregion

        #region ( Fix Address With Api Neshan )
        [HttpGet]
        public async Task<IActionResult> FixAddress(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("مقدار وارد شده معتبر نیست.");
            }

            var address = await UnitOfWork.AddressRepository.Table.Where(a => a.JobBranchId == id)
                .Include(a => a.Location).FirstOrDefaultAsync();

            try
            {
                #region ( Implement Location (Address) )

                string latitude = address.Location.Lat.ToString();
                string longitude = address.Location.Long.ToString();

                if (longitude == "0" || latitude == "0")
                {
                    InfoAlert("امکان تغییر این آدرس وجود ندارد به علت نبود مختصات جغرافیایی ، دستی تغییر دهید");

                    return Redirect(Request.Headers["Referer"].ToString());
                }

                LocationDataViewModel? locationDataViewModel = await NeshanApiService.GetReverseGeocodeAsync(latitude, longitude);

                #region ( Update Address )
                if (locationDataViewModel != null)
                {
                    #region ( Neshan Reurned Data )
                    address.OtherAddress = locationDataViewModel.FormattedAddress;
                    address.PostalAddress = locationDataViewModel.FormattedAddress;
                    address.Neighbourhood = locationDataViewModel.Neighbourhood;

                    var currentCity = await NeshanApiService.GetCityState
                    (locationDataViewModel.City,
                        locationDataViewModel.State,
                        locationDataViewModel.Neighbourhood,
                        UnitOfWork);

                    if (currentCity != null)
                    {
                        address.CityId = currentCity.Id;
                        address.StateId = currentCity.StateId;
                    }
                    #endregion
                }

                await UnitOfWork.AddressRepository.UpdateAsync(address);

                await UnitOfWork.SaveAsync();
                #endregion
                #endregion

                SuccessAlert("آدرس با موفقیت تغییر کرد");

                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch (Exception exception)
            {
                ErrorAlert("در حال حاضر  api  نشان پاسخگو نیست!");
                return Redirect(Request.Headers["Referer"].ToString());
            }
        }
        #endregion

        #region ( Fix Address For All Jobs )
        /// <summary>
        /// تمامی آدرس های انگلیسی فارسی میشود با استفاده از نشان
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FixAddressForAllJobs()
        {
            var results = await UnitOfWork.AddressRepository.Table.Include(a => a.Location).ToListAsync();

            var enAddresses = results
                .Where(j => !string.IsNullOrWhiteSpace(j.OtherAddress) && Regex.IsMatch(j.OtherAddress, @"[a-zA-Z]"))
                .ToList();

            var ids = enAddresses.Select(e => e.JobBranchId).ToList();

            //var jobs = await UnitOfWork.JobBranchRepository.Table.Where(j => ids.Contains(j.Id)).ToListAsync();

            //var names = jobs.Select(j => j.Route).ToList();

            //SuccessAlert(names.ToString());
            //return Redirect(Request.Headers["Referer"].ToString());

            int failed = 0;
            int success = 0;
            int neshanNotReturned = 0;

            foreach (var address in enAddresses)
            {
                #region ( Implement Location (Address) )
                string latitude = address.Location.Lat.ToString();
                string longitude = address.Location.Long.ToString();

                if (longitude == "0" || latitude == "0")
                {
                    failed++;

                    continue;
                }

                LocationDataViewModel? locationDataViewModel = await NeshanApiService.GetReverseGeocodeAsync(latitude, longitude);

                #region ( Update Address )
                if (locationDataViewModel != null)
                {
                    #region ( Neshan Reurned Data )
                    address.OtherAddress = locationDataViewModel.FormattedAddress;
                    address.PostalAddress = locationDataViewModel.FormattedAddress;
                    address.Neighbourhood = locationDataViewModel.Neighbourhood;

                    var currentCity = await NeshanApiService.GetCityState
                    (locationDataViewModel.City,
                        locationDataViewModel.State,
                        locationDataViewModel.Neighbourhood,
                        UnitOfWork);

                    if (currentCity != null)
                    {
                        address.CityId = currentCity.Id;
                        address.StateId = currentCity.StateId;
                    }
                    #endregion

                    success++;
                }
                else
                {
                    neshanNotReturned++;

                    continue;
                }

                await UnitOfWork.AddressRepository.UpdateAsync(address);

                await UnitOfWork.SaveAsync();
                #endregion
                #endregion
            }

            string message = $"تعداد کل {enAddresses.Count} ---- تعداد شکست {failed} ---- تعداد بازگشتی نشان {success}  ---- عدم بازگشت نشان {neshanNotReturned} ";

            SuccessAlert(message);
            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion

        #region ( Fix Duplicate Jobs )
        /// <summary>
        /// شغل ها با route تکراری را پیدا  کرده و به انتهای آنها یک کاراکتر اضافه میکند
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FixDuplicateJobs()
        {
            var duplicateRoutes = UnitOfWork.JobRepository.TableNoTracking
                .GroupBy(j => j.Route)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            var jobs = await UnitOfWork.JobRepository.TableNoTracking
                .Where(j => duplicateRoutes.Contains(j.Route))
                .OrderBy(j => j.Route)
                .ThenByDescending(j => j.CreateDate).ToListAsync();

            foreach (var job in jobs)
            {
                var randomChar = Strings.RandomString();
                var route = $"{job.Route}-{randomChar}";

                var jobBranches = await UnitOfWork.JobBranchRepository.TableNoTracking.Where(j => j.JobId == job.Id)
                    .ToListAsync();

                foreach (var jobBranch in jobBranches)
                {
                    jobBranch.Route = route;

                    await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);
                }

                job.Route = route;

                await UnitOfWork.JobRepository.UpdateAsync(job);
            }

            await UnitOfWork.SaveAsync();

            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion

        #region ( Key Words )
        #region ( Index )
        [HttpGet]
        public async Task<IActionResult> IndexKeyword(KeywordFilterViewModel filter)
        {
            #region ( Fill View Data )
            var categories = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive && c.ParentId != 0);

            ViewData["categories"] = categories;
            #endregion

            return View(UnitOfWork.KeywordRepository.GetByFilter(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> CreateKeyword()
        {
            #region ( Fill View Data )
            var categories = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive);

            ViewData["categories"] = categories;
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateKeyword(CreateKeywordViewModel createKeywordViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                #region ( Fill View Data )
                var categories = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive);

                ViewData["categories"] = categories;
                #endregion

                return View(createKeywordViewModel);
            }

            #region ( Check route is duplicated or not )
            bool slugExist = await UnitOfWork.KeywordRepository.SlugExist(createKeywordViewModel.Slug);

            if (slugExist)
            {
                ErrorAlert(Errors.RouteDuplicate);

                #region ( Fill View Data )
                var categories = await UnitOfWork.CategoryRepository.GetAllAsync();

                ViewData["categories"] = categories;
                #endregion

                return View(createKeywordViewModel);
            }
            #endregion

            var keyword = Mapper.Map<Keyword>(createKeywordViewModel);

            keyword.IsActive = true;
            keyword.Slug = keyword.Slug.ToSlug();

            await UnitOfWork.KeywordRepository.InsertAsync(keyword);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception exception)
            {
                ErrorAlert(exception.Message);
            }

            return RedirectToAction("IndexKeyword");
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> UpdateKeyword(Guid id)
        {
            #region ( Fill View Data )
            var categories = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive);

            ViewData["categories"] = categories;
            #endregion

            var keyword = await UnitOfWork.KeywordRepository.TableNoTracking.SingleOrDefaultAsync(k => k.Id == id);

            var model = Mapper.Map<UpdateKeywordViewModel>(keyword);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateKeyword(UpdateKeywordViewModel updateKeywordViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                #region ( Fill View Data )
                var categories = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive);

                ViewData["categories"] = categories;
                #endregion

                return View(updateKeywordViewModel);
            }

            #region ( Check route is duplicated or not )
            bool slugExist = await UnitOfWork.KeywordRepository.SlugExist(updateKeywordViewModel.Id, updateKeywordViewModel.Slug);

            if (slugExist)
            {
                ErrorAlert(Errors.RouteDuplicate);

                #region ( Fill View Data )
                var categories = await UnitOfWork.CategoryRepository.GetAllAsync();

                ViewData["categories"] = categories;
                #endregion

                return View(updateKeywordViewModel);
            }
            #endregion

            var keyword = await UnitOfWork.KeywordRepository.TableNoTracking.SingleOrDefaultAsync(k => k.Id == updateKeywordViewModel.Id);

            keyword = Mapper.Map(updateKeywordViewModel, keyword);
            keyword.Slug = keyword.Slug.ToSlug();

            await UnitOfWork.KeywordRepository.UpdateAsync(keyword);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();

                #region ( Remove Cache Data )

                await DistributedCache.RemoveAsync(key: CacheKeys.GetAllKeywordsQuery());

                #endregion
            }
            catch (Exception exception)
            {
                ErrorAlert(exception.Message);
            }

            return RedirectToAction("IndexKeyword");
        }
        #endregion

        #region ( Delete )
        [HttpGet]
        public async Task<IActionResult> DeleteKeyword(Guid id)
        {
            var keyword = await UnitOfWork.KeywordRepository.TableNoTracking.SingleOrDefaultAsync(k => k.Id == id);

            if (keyword == null)
            {
                ErrorAlert("چیزی یافت نشد!");

                return RedirectToAction("IndexKeyword");
            }

            try
            {
                await UnitOfWork.KeywordRepository.DeleteAsync(keyword);
                await UnitOfWork.SaveAsync();

                #region ( Remove Cache Data )

                await DistributedCache.RemoveAsync(key: CacheKeys.GetAllKeywordsQuery());

                #endregion
            }
            catch (Exception exception)
            {
                ErrorAlert(exception.Message);
            }

            return RedirectToAction("IndexKeyword");
        }
        #endregion

        #region ( Hard Delete All )
        [HttpGet]
        public async Task<IActionResult> DeleteKeywords()
        {
            await UnitOfWork.KeywordRepository.BeginTransactionAsync();

            var allKeywords = await UnitOfWork.KeywordRepository.GetAllAsync();

            try
            {
                if (allKeywords.Any() && allKeywords.Count >= 1)
                {
                    UnitOfWork.KeywordRepository.RemoveRange(allKeywords);

                    await UnitOfWork.SaveAsync();
                }
            }
            catch (Exception exception)
            {
                await UnitOfWork.JobRepository.RollBackTransactionAsync();
                Logger.LogError(message: exception.InnerException?.Message ?? exception.Message);

                return RedirectToAction("IndexKeyword");
            }

            await UnitOfWork.KeywordRepository.CommitTransactionAsync();

            #region ( Remove Cache Data )

            await DistributedCache.RemoveAsync(key: CacheKeys.GetAllKeywordsQuery());

            #endregion

            return RedirectToAction("IndexKeyword");
        }
        #endregion

        #region ( Create KeyWords From Category )
        [HttpGet]
        public async Task<IActionResult> CreateKeywordCategory()
        {
            var categories = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive);
            var keywords = await UnitOfWork.KeywordRepository.GetAllAsync();

            foreach (var category in categories)
            {
                if (keywords.Any(k => k.Slug == category.Route))
                {
                    continue;
                }

                var keyword = new Keyword()
                {
                    Title = category.Name,
                    Slug = category.Route.ToSlug(),

                    CanonicalMeta = category.CanonicalMeta,
                    MetaCanonicalUrl = category.MetaCanonicalUrl,
                    IndexMeta = category.IndexMeta,
                    MetaDesc = category.MetaDesc,
                    MetaTitle = category.MetaTitle,

                    IsCategory = true,
                    IsActive = true,
                    CategoryId = category.Id,
                };

                await UnitOfWork.KeywordRepository.InsertAsync(keyword);
            }

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (Exception exception)
            {
                ErrorAlert(exception.Message);
            }

            return RedirectToAction("IndexKeyword");
        }
        #endregion
        #endregion
        #endregion

        #region ( Job Branches )
        #region ( Index )
        [HttpGet]
        public async Task<IActionResult> IndexJobBranch(int jobId)
        {
            var job = await UnitOfWork.JobRepository.Table.Where(j => j.Id == jobId).SingleOrDefaultAsync();

            #region ( Job Is Null )
            if (job == null)
            {
                ErrorAlert("شغل یافت نشد!");

                return RedirectToAction("IndexJob");
            }
            #endregion

            ViewData["jobTitle"] = job.Title;
            ViewData["jobId"] = job.Id;

            var jobBranches = await UnitOfWork.JobBranchRepository.GetAllAsync(j => j.JobId == jobId);

            return View(jobBranches);
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> CreateJobBranch(int jobId)
        {
            var job = await UnitOfWork.JobRepository.Table.Where(j => j.Id == jobId).SingleOrDefaultAsync();

            #region ( Job Is Null )
            if (job == null)
            {
                ErrorAlert("شغل یافت نشد!");

                return RedirectToAction("IndexJob");
            }
            #endregion

            ViewData["jobTitle"] = job.Title;
            ViewData["jobId"] = job.Id;

            var model = new CreateJobBranchViewModel()
            {
                Title = job.Title,
                Route = job.Route,
                HeadingTitle = job.Title,
                JobId = job.Id,
                BranchContent = job.Content,
                MetaTitle = job.Title,
                MetaDesc = job.Summary,
                Description = job.Content,
                UserId = job.AdminId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobBranch(CreateJobBranchViewModel createJobBranchViewModel)
        {
            #region ( Find Job )
            var job = await UnitOfWork.JobRepository.Table
                .Include(j => j.JobBranches)
                .SingleOrDefaultAsync(j => j.Id == createJobBranchViewModel.JobId);

            if (job == null)
            {
                return BadRequest();
            }
            #endregion

            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                return View(createJobBranchViewModel);
                #endregion
            }

            if (job.JobBranches.Any())
            {
                #region ( Error Business Roles )
                ErrorAlert("بیشتر از یک شعبه نمیتوان ثبت کرد");
                #endregion

                return RedirectToAction("IndexJobBranch", new { jobId = createJobBranchViewModel.JobId });
            }

            var jobBranch = Mapper.Map<JobBranch>(createJobBranchViewModel);

            #region ( Pictures )
            if (createJobBranchViewModel.LargePictureFile != null)
            {
                var largePictureName = await FtpService.UploadFileToFtpServer(createJobBranchViewModel.LargePictureFile, TypeFile.Image, Paths.JobBranch, createJobBranchViewModel.LargePictureFile.FileName);
                jobBranch.LargePicture = largePictureName;
            }

            if (createJobBranchViewModel.SmallPictureFile != null)
            {
                var smallPictureName = await FtpService.UploadFileToFtpServer(createJobBranchViewModel.SmallPictureFile, TypeFile.Image, Paths.JobBranch, createJobBranchViewModel.SmallPictureFile.FileName);
                jobBranch.SmallPicture = smallPictureName;
            }
            #endregion

            jobBranch.UserId = job.AdminId;
            jobBranch.CreateDate = DateTime.Now;
            jobBranch.IsAdminCreator = true;
            jobBranch.Status = JobBranchStatus.Accepted;
            jobBranch.IsConfirmedByAdmin = true;

            await UnitOfWork.JobBranchRepository.InsertAsync(jobBranch);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert("عملیات انجام گردید لطفا برای شعبه مورد نظر از آدرس را ثبت کنید!");

                return RedirectToAction("AddressJobBranch", new { id = jobBranch.Id });
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            ViewData["jobTitle"] = jobBranch.Title;
            ViewData["jobId"] = jobBranch.Id;

            return RedirectToAction("IndexJobBranch", new { jobId = createJobBranchViewModel.JobId });
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> UpdateJobBranch(string id)
        {
            var jobBranch = await UnitOfWork.JobBranchRepository.Table.SingleOrDefaultAsync(j => j.Id == id);

            var model = Mapper.Map<UpdateJobBranchViewModel>(jobBranch);

            model.CurrentPicture = jobBranch.LargePicture;
            model.CurrentSmallPicture = jobBranch.SmallPicture;
            model.CurrentBranchVideo = jobBranch.BranchVideo;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobBranch(UpdateJobBranchViewModel updateJobBranchViewModel)
        {
            #region ( Find Job )
            var job = await UnitOfWork.JobRepository.Table
                .Include(j => j.JobBranches)
                .SingleOrDefaultAsync(j => j.Id == updateJobBranchViewModel.JobId);

            if (job == null)
            {
                return BadRequest();
            }
            #endregion

            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                return View(updateJobBranchViewModel);
                #endregion
            }

            var jobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(updateJobBranchViewModel.Id);

            jobBranch = Mapper.Map(updateJobBranchViewModel, jobBranch);

            #region ( Pictures )
            if (updateJobBranchViewModel.LargePictureFile != null)
            {
                var largePictureName = await FtpService.UploadFileToFtpServer(updateJobBranchViewModel.LargePictureFile, TypeFile.Image, Paths.JobBranch, updateJobBranchViewModel.LargePictureFile.FileName);
                jobBranch.LargePicture = largePictureName;
            }

            if (updateJobBranchViewModel.SmallPictureFile != null)
            {
                var smallPictureName = await FtpService.UploadFileToFtpServer(updateJobBranchViewModel.SmallPictureFile, TypeFile.Image, Paths.JobBranch, updateJobBranchViewModel.SmallPictureFile.FileName);
                jobBranch.SmallPicture = smallPictureName;
            }
            #endregion

            jobBranch.LastUpdateDate = DateTime.Now;

            await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexJobBranch", new { updateJobBranchViewModel.JobId });
        }
        #endregion

        #region ( Address )
        [HttpGet]
        public async Task<IActionResult> AddressJobBranch(string id)
        {
            ViewData["jobBranchId"] = id;
            ViewData["isUpdate"] = "false";

            ViewData["cities"] = await UnitOfWork.CityBaseRepository.GetAllAsync(c => c.StateId == 5);
            var address = await UnitOfWork.AddressRepository.Table.Where(a => a.JobBranchId == id)
                .Include(a => a.Location).FirstOrDefaultAsync();

            var model = new AddressJobBranchViewModel();

            if (address != null)
            {
                ViewData["isUpdate"] = "true";
                model.AddressId = address.Id;
                model.CityId = address.CityId;
                model.StateId = address.StateId;
                model.JobBranchId = address.JobBranchId;
                model.Long = address.Location.Long;
                model.Lat = address.Location.Lat;
                model.Neighbourhood = address.Neighbourhood;
                model.PostalAddress = address.PostalAddress;
                model.PostalCode = address.PostalCode;
            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddressJobBranch(AddressJobBranchViewModel addressJobBranchViewModel)
        {
            await UnitOfWork.AddressRepository.BeginTransactionAsync();
            if (addressJobBranchViewModel.AddressId == null)
            {
                // Create

                var location = new Location()
                {
                    Lat = addressJobBranchViewModel.Lat,
                    Long = addressJobBranchViewModel.Long,
                    PlaceType = PlaceType.Home,
                    CreateDate = DateTime.Now,
                };

                await UnitOfWork.LocationRepository.InsertAsync(location);
                await UnitOfWork.SaveAsync();

                var Address = new Address()
                {
                    CityId = addressJobBranchViewModel.CityId,
                    JobBranchId = addressJobBranchViewModel.JobBranchId!,
                    LocationId = location.Id,
                    Neighbourhood = addressJobBranchViewModel.Neighbourhood,
                    PostalAddress = addressJobBranchViewModel.PostalAddress,
                    OtherAddress = addressJobBranchViewModel.PostalAddress,
                    StateId = addressJobBranchViewModel.StateId,
                    CreateDate = DateTime.Now,
                };
                await UnitOfWork.AddressRepository.InsertAsync(Address);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            else
            {
                // Update

                var address = await UnitOfWork.AddressRepository.Table.Include(a => a.Location)
                    .SingleAsync(a => a.Id == addressJobBranchViewModel.AddressId);

                address.Location.Lat = addressJobBranchViewModel.Lat;
                address.Location.Long = addressJobBranchViewModel.Long;
                address.Location.LastUpdateDate = DateTime.Now;
                await UnitOfWork.LocationRepository.UpdateAsync(address.Location);


                address.PostalAddress = addressJobBranchViewModel.PostalAddress;
                address.OtherAddress = addressJobBranchViewModel.PostalAddress;
                address.CityId = addressJobBranchViewModel.CityId;
                address.Neighbourhood = addressJobBranchViewModel.Neighbourhood;
                address.PostalCode = addressJobBranchViewModel.PostalCode;
                address.UpdateDate = DateTime.Now;

                await UnitOfWork.AddressRepository.UpdateAsync(address);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }

            await UnitOfWork.AddressRepository.CommitTransactionAsync();


            return RedirectToAction("AddressJobBranch", new { id = addressJobBranchViewModel.JobBranchId });
        }
        #endregion

        #region ( Delete )
        [HttpPost]
        public async Task<IActionResult> DeleteJobBranch(string id)
        {
            var jobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(id);

            var jobId = jobBranch != null ? jobBranch.JobId : 0;

            if (jobBranch != null)
            {
                await UnitOfWork.JobBranchRepository.DeleteAsync(jobBranch);
                await UnitOfWork.SaveAsync();

                #region ( Remove Cache Data )

                await DistributedCache.RemoveAsync(key: CacheKeys.GetJobBranchByIdQuery(jobBranch.Id));
                await DistributedCache.RemoveAsync(key: CacheKeys.GetJobBranchByRouteQuery(jobBranch.Route!));

                #endregion

                return RedirectToAction("IndexJobBranch", new { jobId = jobId });
            }

            return RedirectToAction("IndexJob");
        }
        #endregion

        #region ( Image Gallery )
        [HttpGet]
        public async Task<IActionResult> IndexJobBranchImageGallery(string id)
        {
            var model = await UnitOfWork.JobBranchGalleryRepository.GetAllAsync(j => j.JobBranchId == id);

            ViewData["jobBranchId"] = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobBranchImageGallery(CreateJobBranchImageGalleryViewModel createJobBranchImageGalleryViewModel)
        {
            var jobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(createJobBranchImageGalleryViewModel.JobBranchId);

            if (jobBranch == null)
            {
                return RedirectToAction("IndexJob");
            }

            byte sort = 0;

            foreach (var item in createJobBranchImageGalleryViewModel.Files)
            {
                var imageGallery = await FtpService.UploadFileToFtpServer(item, TypeFile.Image, Paths.JobBranchGallery, item.FileName);

                var jobBranchGallery = new JobBranchGallery()
                {
                    ImageName = imageGallery,
                    JobBranchId = jobBranch.Id,
                    Sort = sort,
                };

                await UnitOfWork.JobBranchGalleryRepository.InsertAsync(jobBranchGallery);

                sort++;
            }

            await UnitOfWork.SaveAsync();

            return RedirectToAction("IndexJobBranchImageGallery", new { id = createJobBranchImageGalleryViewModel.JobBranchId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteJobBranchImageGallery(int id)
        {
            var imageGallery = await UnitOfWork.JobBranchGalleryRepository.GetByIdAsync(id);

            if (imageGallery == null)
            {
                ErrorAlert("چیزی یافت نشد!");

                return RedirectToAction("IndexJobBranchImageGallery");
            }

            await UnitOfWork.JobBranchGalleryRepository.DeleteAsync(imageGallery);

            try
            {
                await UnitOfWork.SaveAsync();

                await FtpService.DeleteFileToFtpServer(Paths.JobBranch, imageGallery.ImageName);

                #region ( Remove Cache Data )

                var jobBranch = await UnitOfWork.JobBranchRepository.GetJobBranchById(imageGallery.JobBranchId, CancellationToken.None);
                if (jobBranch is not null)
                {
                    await DistributedCache.RemoveAsync(key: CacheKeys.GetJobBranchByIdQuery(jobBranch.Id));
                    await DistributedCache.RemoveAsync(key: CacheKeys.GetJobBranchByRouteQuery(jobBranch.Route!));
                }

                #endregion
            }
            catch (Exception exception)
            {
                ErrorAlert(exception.Message);
            }

            string referer = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrEmpty(referer))
            {
                return Redirect(referer);
            }

            return RedirectToAction("IndexJobBranch");
        }
        #endregion
        #endregion

        #region ( Insert From Google Bot Json File )
        [HttpGet]
        public async Task<IActionResult> InsertJobsFromGoogle()
        {
            #region ( Fill View Model )
            ViewData["categories"] =
                await UnitOfWork.CategoryRepository.GetAllAsync(a => a.IsActive && a.NodeLevel == 3 && !a.ParentId.Equals(0));

            ViewData["cities"] =
                await UnitOfWork.CityBaseRepository.GetAllAsync();
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertJobsFromGoogle(InsertJobsFromGoogle insertJobsFromGoogle)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                #region ( Fill View Model )
                ViewData["categories"] =
                    await UnitOfWork.CategoryRepository.GetAllAsync(a => a.IsActive && a.NodeLevel == 3 && !a.ParentId.Equals(0));

                ViewData["cities"] =
                    await UnitOfWork.CityBaseRepository.GetAllAsync();
                #endregion

                return View(insertJobsFromGoogle);
                #endregion
            }

            #region ( Check Type File )  
            if (!insertJobsFromGoogle.File.ContentType.Equals("application/json"))
            {
                #region ( Fill View Model )
                ViewData["categories"] =
                    await UnitOfWork.CategoryRepository.GetAllAsync(a => a.IsActive && a.NodeLevel == 3 && !a.ParentId.Equals(0));

                ViewData["cities"] =
                    await UnitOfWork.CityBaseRepository.GetAllAsync();
                #endregion

                return View(insertJobsFromGoogle);
            }
            #endregion

            var json = string.Empty;

            var fileStream = insertJobsFromGoogle.File.OpenReadStream();
            using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                json = await streamReader.ReadToEndAsync();

            var jobs = JsonSerializer.Deserialize<List<JobsGoogleViewModel>>(json);

            var itemCount = 0;
            var itemAddressFailedCount = " ";
            var itemDuplicatedCount = 0;


            foreach (var item in jobs)
            {
                await UnitOfWork.JobRepository.BeginTransactionAsync();

                try
                {
                    #region ( Exist Item )
                    var existJob = await UnitOfWork.JobBranchRepository.TableNoTracking
                        .Include(j => j.Address)
                        .Include(j => j.Job)
                        .FirstOrDefaultAsync(j => j.Address.CityId.Equals(insertJobsFromGoogle.CityId)
                                                  && j.Title.Contains(item.Name)
                                                  && j.Job.PhoneNumberInfos.Contains($"{item.MobileNumber}"));

                    if (existJob != null)
                    {
                        itemDuplicatedCount++;

                        await UnitOfWork.JobRepository.RollBackTransactionAsync();

                        continue;
                    }
                    #endregion

                    #region ( Phone Number And Social Medias )
                    List<SocialMediaInfosViewModel> socialMediaLinks = new();
                    if (!string.IsNullOrWhiteSpace(item.InstagramProfile))
                    {
                        socialMediaLinks.Add(new SocialMediaInfosViewModel()
                        {
                            SocialMediaLink = item.InstagramProfile,
                            SocialMediaType = SocialMediaTypes.Instagram
                        });
                    }

                    List<PhoneNumberInfosViewModel> phoneNumberInfos = new();
                    if (!string.IsNullOrWhiteSpace(item.MobileNumber))
                    {
                        if (item.MobileNumber.StartsWith("26") || item.MobileNumber.StartsWith("026"))
                        {
                            phoneNumberInfos.Add(new PhoneNumberInfosViewModel()
                            {
                                PhoneNumber = item.MobileNumber,
                                PhoneNumberType = PhoneNumberTypes.PhoneNumberTel
                            });
                        }
                        else
                        {
                            phoneNumberInfos.Add(new PhoneNumberInfosViewModel()
                            {
                                PhoneNumber = item.MobileNumber,
                                PhoneNumberType = PhoneNumberTypes.PhoneNumberMobile
                            });
                        }
                    }
                    #endregion

                    #region ( Fields )
                    var name = item.Name.SanitizeText().ToLower();
                    var route = item.Name.SanitizeText().ToLower().ToSlug();
                    var description = item.BusinessDescription.SanitizeText().ToLower();
                    var rating = Convert.ToInt32(item.Rating);
                    var socialMedias = socialMediaLinks.Any() ? JsonSerializer.Serialize(socialMediaLinks) : string.Empty;
                    var phoneNumbers = phoneNumberInfos.Any() ? JsonSerializer.Serialize(phoneNumberInfos) : string.Empty;
                    var user = await UserManager.GetUserAsync(User);
                    var city = await UnitOfWork.CityBaseRepository.GetByPredicate(a => a.Id.Equals(insertJobsFromGoogle.CityId));
                    #endregion

                    #region ( Job )
                    var job = new Job
                    {
                        Route = route,
                        Title = name,
                        SubTitle = name,
                        Summary = description,
                        AverageRate = rating,
                        IsGoogleData = true,
                        Content = description ?? name,
                        SocialMediaInfos = socialMedias,
                        PhoneNumberInfos = phoneNumbers,
                        Status = JobBranchStatus.Accepted,
                        CreateDate = DateTime.Now,
                    };

                    await UnitOfWork.JobRepository.InsertAsync(job);
                    await UnitOfWork.SaveAsync();
                    #endregion

                    #region ( Job Category )
                    var jobCategory = new JobCategory()
                    {
                        JobId = job.Id,
                        CategoryId = insertJobsFromGoogle.CategoryId
                    };

                    await UnitOfWork.JobCategoryRepository.InsertAsync(jobCategory);
                    await UnitOfWork.SaveAsync();
                    #endregion

                    #region ( Job Branch )
                    var jobBranch = new JobBranch
                    {
                        Route = route,
                        Title = name,
                        JobId = job.Id,
                        Description = description ?? name,
                        JobTimeWorkType = JobTimeWorkType.WorkAllTime,
                        IsConfirmedByAdmin = true,
                        CanonicalMeta = false,
                        IndexMeta = false,
                        IsOffer = false,
                        AddressId = string.Empty,
                        ConfirmationDate = DateTime.Now,
                        LastUpdateDate = DateTime.Now,
                        Status = JobBranchStatus.Accepted,
                        UserId = user.Id,
                        Job = job,
                        ApplicationUser = null,
                        Address = null
                    };

                    await UnitOfWork.JobBranchRepository.InsertAsync(jobBranch);
                    await UnitOfWork.SaveAsync();
                    #endregion

                    #region ( Implement Location (Address) )
                    LocationDataViewModel? locationDataViewModel = await NeshanApiService.GetReverseGeocodeAsync(item.Latitude, item.Longitude);

                    #region ( Insert Location )
                    var location = new Location
                    {
                        Lat = Convert.ToDouble(item.Latitude),
                        Long = Convert.ToDouble(item.Longitude),
                        Route = string.Empty
                    };

                    await UnitOfWork.LocationRepository.InsertAsync(location);
                    await UnitOfWork.SaveAsync();
                    #endregion

                    #region ( Insert Address )
                    var address = new Address();
                    address.JobBranchId = jobBranch.Id;
                    address.LocationId = location.Id;
                    address.PostalCode = item.PostalCode;
                    address.CityId = city.Id;
                    address.StateId = city.StateId;

                    if (locationDataViewModel == null)
                    {
                        #region ( Neshan Not Returned Data )
                        address.OtherAddress = item.Address;
                        address.PostalAddress = item.Address;
                        address.Neighbourhood = string.Empty;

                        itemAddressFailedCount += $"{item.Name} - ";
                        #endregion
                    }
                    else
                    {
                        #region ( Nesham Reurned Data )
                        address.OtherAddress = locationDataViewModel.FormattedAddress;
                        address.PostalAddress = locationDataViewModel.FormattedAddress;
                        address.Neighbourhood = locationDataViewModel.Neighbourhood;

                        var currentCity = await NeshanApiService.GetCityState
                            (locationDataViewModel.City,
                            locationDataViewModel.State,
                            locationDataViewModel.Neighbourhood,
                            UnitOfWork);

                        if (currentCity != null)
                        {
                            address.CityId = currentCity.Id;
                            address.StateId = currentCity.StateId;
                        }
                        #endregion
                    }

                    await UnitOfWork.AddressRepository.InsertAsync(address);

                    jobBranch.AddressId = address.Id;

                    await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);
                    await UnitOfWork.SaveAsync();
                    #endregion
                    #endregion

                    itemCount++;
                }
                catch
                {
                    await UnitOfWork.JobRepository.RollBackTransactionAsync();

                    continue;
                }

                await UnitOfWork.JobRepository.CommitTransactionAsync();

            }


            SuccessAlert($"آیتم های استخراج شده از فایل : {jobs.Count}\r\nآیتم های اضافه شده :  {itemCount}\r\nآیتم های تکراری : {itemDuplicatedCount} \r\nآیتم هایی که آدرس از نشان درج نشده و نیاز به بررسی دارد : \"{itemAddressFailedCount}\"");

            return RedirectToAction("IndexJob");
        }
        #endregion

        #region ( Insert From Google Bot Excel File )
        [HttpGet]
        public async Task<IActionResult> InsertJobsExcelFromGoogle()
        {
            #region ( Fill View Model )
            ViewData["categories"] =
                await UnitOfWork.CategoryRepository.GetAllAsync(a => a.IsActive && a.NodeLevel == 3 && !a.ParentId.Equals(0));

            ViewData["cities"] =
                await UnitOfWork.CityBaseRepository.GetAllAsync();
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertJobsExcelFromGoogle(InsertJobsExcelFromGoogle insertJobsExcelFromGoogle)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                #region ( Fill View Model )
                ViewData["categories"] =
                    await UnitOfWork.CategoryRepository.GetAllAsync(a => a.IsActive && a.NodeLevel == 3 && !a.ParentId.Equals(0));

                ViewData["cities"] =
                    await UnitOfWork.CityBaseRepository.GetAllAsync();
                #endregion

                return View(insertJobsExcelFromGoogle);
                #endregion
            }

            #region ( Check Type File )  
            if (!insertJobsExcelFromGoogle.File.ContentType.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                #region ( Fill View Model )
                ViewData["categories"] =
                    await UnitOfWork.CategoryRepository.GetAllAsync(a => a.IsActive && a.NodeLevel == 3 && !a.ParentId.Equals(0));

                ViewData["cities"] =
                    await UnitOfWork.CityBaseRepository.GetAllAsync();
                #endregion

                return View(insertJobsExcelFromGoogle);
            }
            #endregion

            var json = insertJobsExcelFromGoogle.File.ConvertExcelToJson();

            var jobs = JsonSerializer.Deserialize<List<JobsGoogleExcelViewModel>>(json);

            var itemCount = 0;
            var itemAddressFailedCount = " ";
            var itemDuplicatedCount = 0;


            foreach (var item in jobs)
            {
                await UnitOfWork.JobRepository.BeginTransactionAsync();

                try
                {
                    #region ( Exist Item )
                    var existJob = await UnitOfWork.JobBranchRepository.TableNoTracking
                        .Include(j => j.Address)
                        .Include(j => j.Job)
                        .FirstOrDefaultAsync(j => j.Address.CityId.Equals(insertJobsExcelFromGoogle.CityId)
                                                  && j.Title.Contains(item.Name)
                                                  && j.Job.PhoneNumberInfos.Contains($"{item.MobileNumber}"));

                    if (existJob != null)
                    {
                        itemDuplicatedCount++;

                        await UnitOfWork.JobRepository.RollBackTransactionAsync();

                        continue;
                    }
                    #endregion

                    #region ( Phone Number And Social Medias )
                    List<SocialMediaInfosViewModel> socialMediaLinks = new();
                    if (!string.IsNullOrWhiteSpace(item.InstagramProfile))
                    {
                        socialMediaLinks.Add(new SocialMediaInfosViewModel()
                        {
                            SocialMediaLink = item.InstagramProfile,
                            SocialMediaType = SocialMediaTypes.Instagram
                        });
                    }

                    List<PhoneNumberInfosViewModel> phoneNumberInfos = new();
                    if (!string.IsNullOrWhiteSpace(item.MobileNumber))
                    {
                        if (item.MobileNumber.StartsWith("26") || item.MobileNumber.StartsWith("026"))
                        {
                            phoneNumberInfos.Add(new PhoneNumberInfosViewModel()
                            {
                                PhoneNumber = item.MobileNumber,
                                PhoneNumberType = PhoneNumberTypes.PhoneNumberTel
                            });
                        }
                        else
                        {
                            phoneNumberInfos.Add(new PhoneNumberInfosViewModel()
                            {
                                PhoneNumber = item.MobileNumber,
                                PhoneNumberType = PhoneNumberTypes.PhoneNumberMobile
                            });
                        }
                    }
                    #endregion

                    #region ( Fields )
                    var name = item.Name.SanitizeText().ToLower();
                    var route = (item.Name.SanitizeText().ToLower() + "-" + Strings.RandomString()).ToSlug();
                    var description = item.BusinessDescription.SanitizeText().ToLower();

                    int rating = 3;

                    #region ( Fix Bug Rating )
                    try
                    {
                        if (item.Rating != null)
                        {
                            var decimalNumber = Convert.ToDouble(item.Rating);
                            rating = (int)Math.Floor(decimalNumber);
                        }
                    }
                    catch
                    {

                    }
                    #endregion


                    var socialMedias = socialMediaLinks.Any() ? JsonSerializer.Serialize(socialMediaLinks) : string.Empty;
                    var phoneNumbers = phoneNumberInfos.Any() ? JsonSerializer.Serialize(phoneNumberInfos) : string.Empty;
                    var user = await UserManager.GetUserAsync(User);
                    var city = await UnitOfWork.CityBaseRepository.GetByPredicate(a => a.Id.Equals(insertJobsExcelFromGoogle.CityId));
                    #endregion

                    #region ( Job )
                    var job = new Job
                    {
                        Route = route,
                        Title = name,
                        SubTitle = name,
                        Summary = description,
                        AverageRate = rating,
                        IsGoogleData = true,
                        Content = description ?? name,
                        SocialMediaInfos = socialMedias,
                        PhoneNumberInfos = phoneNumbers,
                        Status = JobBranchStatus.Accepted,
                        CreateDate = DateTime.Now,
                    };

                    await UnitOfWork.JobRepository.InsertAsync(job);
                    await UnitOfWork.SaveAsync();
                    #endregion

                    #region ( Job Category )
                    var jobCategory = new JobCategory()
                    {
                        JobId = job.Id,
                        CategoryId = insertJobsExcelFromGoogle.CategoryId
                    };

                    await UnitOfWork.JobCategoryRepository.InsertAsync(jobCategory);
                    await UnitOfWork.SaveAsync();
                    #endregion

                    #region ( Job Branch )
                    var jobBranch = new JobBranch
                    {
                        Route = route,
                        Title = name,
                        JobId = job.Id,
                        Description = description ?? name,
                        JobTimeWorkType = JobTimeWorkType.WorkAllTime,
                        IsConfirmedByAdmin = true,
                        CanonicalMeta = false,
                        IndexMeta = false,
                        IsOffer = false,
                        AddressId = string.Empty,
                        ConfirmationDate = DateTime.Now,
                        LastUpdateDate = DateTime.Now,
                        Status = JobBranchStatus.Accepted,
                        UserId = user.Id,
                        Job = job,
                        ApplicationUser = null,
                        Address = null
                    };

                    await UnitOfWork.JobBranchRepository.InsertAsync(jobBranch);
                    await UnitOfWork.SaveAsync();
                    #endregion

                    #region ( Implement Location (Address) )
                    LocationDataViewModel? locationDataViewModel = await NeshanApiService.GetReverseGeocodeAsync(item.Latitude, item.Longitude);

                    #region ( Insert Location )
                    var location = new Location
                    {
                        Lat = Convert.ToDouble(item.Latitude),
                        Long = Convert.ToDouble(item.Longitude),
                        Route = string.Empty
                    };

                    await UnitOfWork.LocationRepository.InsertAsync(location);
                    await UnitOfWork.SaveAsync();
                    #endregion

                    #region ( Insert Address )
                    var address = new Address();
                    address.JobBranchId = jobBranch.Id;
                    address.LocationId = location.Id;
                    address.PostalCode = item.PostalCode;
                    address.CityId = city.Id;
                    address.StateId = city.StateId;

                    if (locationDataViewModel == null)
                    {
                        #region ( Neshan Not Returned Data )
                        address.OtherAddress = item.Address;
                        address.PostalAddress = item.Address;
                        address.Neighbourhood = string.Empty;

                        itemAddressFailedCount += $"{item.Name} - ";
                        #endregion
                    }
                    else
                    {
                        #region ( Nesham Reurned Data )
                        address.OtherAddress = locationDataViewModel.FormattedAddress;
                        address.PostalAddress = locationDataViewModel.FormattedAddress;
                        address.Neighbourhood = locationDataViewModel.Neighbourhood;

                        var currentCity = await NeshanApiService.GetCityState
                            (locationDataViewModel.City,
                            locationDataViewModel.State,
                            locationDataViewModel.Neighbourhood,
                            UnitOfWork);

                        if (currentCity != null)
                        {
                            address.CityId = currentCity.Id;
                            address.StateId = currentCity.StateId;
                        }
                        #endregion
                    }

                    await UnitOfWork.AddressRepository.InsertAsync(address);

                    jobBranch.AddressId = address.Id;

                    await UnitOfWork.JobBranchRepository.UpdateAsync(jobBranch);
                    await UnitOfWork.SaveAsync();
                    #endregion
                    #endregion

                    itemCount++;
                }
                catch (Exception exception)
                {
                    await UnitOfWork.JobRepository.RollBackTransactionAsync();

                    continue;
                }

                await UnitOfWork.JobRepository.CommitTransactionAsync();

            }


            SuccessAlert($"آیتم های استخراج شده از فایل : {jobs.Count} , \r\nآیتم های اضافه شده :  {itemCount} , \r\nآیتم های تکراری : {itemDuplicatedCount} , \r\nآیتم هایی که آدرس از نشان درج نشده و نیاز به بررسی دارد : \"{itemAddressFailedCount}\"");

            return RedirectToAction("IndexJob");
        }
        #endregion
    }
}
