using System.Text;
using System.Text.Json;
using Application.Services.NehsanApi;
using Application.Services.SMS;
using Common.Utilities.Services.FTP;
using Domain.Entities.Address;
using Domain.Entities.Job;
using Domain.Entities.Location;
using Enums;
using Microsoft.EntityFrameworkCore;
using ViewModels.AdminPanel.Filter;
using ViewModels.AdminPanel.Job;
using CreateJobBranchViewModel = ViewModels.AdminPanel.Job.CreateJobBranchViewModel;
using PhoneNumberInfosViewModel = ViewModels.AdminPanel.Job.PhoneNumberInfosViewModel;
using SocialMediaInfosViewModel = ViewModels.AdminPanel.Job.SocialMediaInfosViewModel;
using UpdateJobBranchViewModel = ViewModels.AdminPanel.Job.UpdateJobBranchViewModel;

namespace Admin.MVC.Controllers
{
    public class JobController : BaseController
    {
        #region ( DI )
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
        protected IFtpService FtpService { get; }
        protected ISmsSender SmsSender { get; }
        protected UserManager<ApplicationUser> UserManager { get; }
        protected NeshanApiService NeshanApiService { get; }

        public JobController(IUnitOfWork unitOfWork, IMapper mapper, IFtpService ftpService, ISmsSender smsSender, UserManager<ApplicationUser> userManager, NeshanApiService neshanApiService)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            FtpService = ftpService;
            SmsSender = smsSender;
            UserManager = userManager;
            NeshanApiService = neshanApiService;
        }
        #endregion

        #region ( Job )
        #region ( Index )
        [HttpGet]
        public IActionResult IndexJob(JobFilterViewModel filter)
        {
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

            var model = Mapper.Map<UpdateJobViewModel>(job);

            model.CurrentLargePicture = job.LargePicture;
            model.CurrentSmallPictureFile = job.SmallPicture;
            model.CurrentSocialMediaInfos = job.SocialMediaInfos;
            model.CurrentPhoneNumberInfos = job.PhoneNumberInfos;
            model.Categories = job.JobCategories.Select(j => j.CategoryId).ToArray();
            model.UserOwnerId = job.AdminId;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJob(UpdateJobViewModel updateJobViewModel)
        {
            var job = await UnitOfWork.JobRepository.GetByIdAsync(updateJobViewModel.Id);
            string jobBranch = await UnitOfWork.JobBranchRepository.Table.Where(j => j.JobId == job.Id).Select(j => j.UserId).SingleOrDefaultAsync();

            #region ( Job is null )
            if (job == null)
            {
                ErrorAlert();

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

                if (job.LargePicture != null)
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

                if (job.SmallPicture != null)
                {
                    deletedFile = job.SmallPicture;
                }

                var mobilePictureName = await FtpService.UploadFileToFtpServer(updateJobViewModel.SmallPictureFile, TypeFile.Image, Paths.Job, updateJobViewModel.SmallPictureFile.FileName, 777, null, null, null, deletedFile);

                job.SmallPicture = mobilePictureName;
            }
            #endregion
            #endregion

            job.SocialMediaInfos = JsonSerializer.Serialize(updateJobViewModel.SocialMediaInfosViewModel);
            job.PhoneNumberInfos = JsonSerializer.Serialize(updateJobViewModel.PhoneNumberInfosViewModel);
            job.AdminId = updateJobViewModel.UserOwnerId ?? "";

            job.Route = job.Route.ToSlug();
            job.LastUpdateDate = DateTime.Now;

            await UnitOfWork.JobRepository.UpdateAsync(job!);
            #endregion

            #region ( Change Status And Send Sms )
            var sendSms = "";
            var phoneNumber = "";
            var userId = jobBranch ?? job.AdminId;

            if (updateJobViewModel.SendSms)
            {
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
                }
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

                SuccessAlert();
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

                    var orders = await UnitOfWork.OrderRepository.GetAllAsync(c => c.JobBranchId == branch.Id);
                    UnitOfWork.OrderRepository.RemoveRange(orders);

                    var mainSliders = await UnitOfWork.MainSliderRepository.GetAllAsync(c => c.JobBranchId == branch.Id);
                    UnitOfWork.MainSliderRepository.RemoveRange(mainSliders);

                    var jobServices = await UnitOfWork.JobServiceRepository.GetAllAsync(c => c.JobBranchId == branch.Id);
                    UnitOfWork.JobServiceRepository.RemoveRange(jobServices);

                    var jobBranchAttributes = await UnitOfWork.JobBranchAttrRepository.GetAllAsync(c => c.JobBranchId == branch.Id);
                    UnitOfWork.JobBranchAttrRepository.RemoveRange(jobBranchAttributes);

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

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

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
        public async Task<IActionResult> DeleteJobBranch(string jobBranchId)
        {
            var jobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(jobBranchId);

            var jobId = jobBranch != null ? jobBranch.JobId : 0;

            if (jobBranch != null)
            {
                await UnitOfWork.JobBranchRepository.DeleteAsync(jobBranch);
                await UnitOfWork.SaveAsync();

                return RedirectToAction("IndexJobBranch", new { jobId = jobId });
            }

            return RedirectToAction("IndexJob");
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

    }
}
