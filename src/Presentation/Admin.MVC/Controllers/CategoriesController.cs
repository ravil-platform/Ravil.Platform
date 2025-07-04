﻿
using Constants.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Admin.MVC.Controllers
{
    public class CategoriesController(IUnitOfWork unitOfWork, IMapper mapper, 
        IFtpService ftpService, IDistributedCache distributedCache)
    : BaseController
    {
        #region ( DI )

        protected IMapper Mapper { get; } = mapper;
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IFtpService FtpService { get; } = ftpService;
        protected IDistributedCache DistributedCache { get; } = distributedCache;

        #endregion

        #region ( Index )
        public IActionResult Index(CategoriesFilterViewModel filter, int? mainParentId)
        {
            ViewData["parentId"] = filter.ParentId;
            ViewData["nodeLevel"] = filter.NodeLevel;
            ViewData["mainParentId"] = mainParentId ?? 0;

            return View(UnitOfWork.CategoryRepository.GetByAdminFilter(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> Create(short? nodeLevel, int? parentId, int? mainParentId)
        {
            ViewData["nodeLevel"] = nodeLevel ?? 0;
            ViewData["parentId"] = parentId ?? 0;
            ViewData["mainParentId"] = mainParentId ?? 0;
            ViewData["faqCategories"] = await UnitOfWork.FaqCategoryRepository.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel createCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                ViewData["nodeLevel"] = createCategoryViewModel.NodeLevel;
                ViewData["parentId"] = createCategoryViewModel.ParentId;
                ViewData["mainParentId"] = createCategoryViewModel.MainParentId;
                ViewData["faqCategories"] = await UnitOfWork.FaqCategoryRepository.GetAllAsync();


                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                return View(createCategoryViewModel);
                #endregion
            }

            #region ( Check route is duplicated or not )
            bool result = await UnitOfWork.CategoryRepository.RouteExist(createCategoryViewModel.Route);

            if (result)
            {
                ErrorAlert(Errors.RouteDuplicate);

                return View(createCategoryViewModel);
            }
            #endregion

            var category = Mapper.Map<Category>(createCategoryViewModel);
            category.IsActive = true;

            #region ( Picture & Icon )

            category.Picture = "noPic.webp";
            if (createCategoryViewModel.PictureFile != null)
            {
                var largePictureName = await FtpService.UploadFileToFtpServer(createCategoryViewModel.PictureFile, TypeFile.Image, Paths.Category, createCategoryViewModel.PictureFile.FileName);
                category.Picture = largePictureName;
            }

            category.IconPicture = "noIcon.webp";
            if (createCategoryViewModel.IconPictureFile != null)
            {
                var smallPictureName = await FtpService.UploadFileToFtpServer(createCategoryViewModel.IconPictureFile, TypeFile.Image, Paths.Category, createCategoryViewModel.IconPictureFile.FileName);
                category.IconPicture = smallPictureName;
            }

            #endregion

            await UnitOfWork.CategoryRepository.InsertAsync(category);

            try
            {
                await UnitOfWork.SaveAsync();

                #region ( Faq Job Category )

                if (createCategoryViewModel.Faqs != null)
                {
                    foreach (var faqId in createCategoryViewModel.Faqs)
                    {
                        var faqJobCategory = new FaqJobCategory()
                        {
                            JobCategoryId = category.Id,
                            FaqId = faqId,
                        };

                        await UnitOfWork.FaqJobCategoryRepository.InsertAsync(faqJobCategory);
                    }

                    await UnitOfWork.SaveAsync();
                }

                #endregion

                #region ( Category Keyword )

                bool slugExist = await UnitOfWork.KeywordRepository.SlugExist(category.Route);
                if (!slugExist)
                {
                    var keyword = Mapper.Map<Keyword>(category);

                    await UnitOfWork.KeywordRepository.InsertAsync(keyword);
                    await UnitOfWork.SaveAsync();
                }

                #endregion

                SuccessAlert();

                #region ( Remove Cache Data )

                await DistributedCache.RemoveAsync(key: CacheKeys.GetAllKeywordsQuery());
                await DistributedCache.RemoveAsync(key: CacheKeys.GetAllCategoriesQuery());

                #endregion
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("Index", new { parentId = category.ParentId, nodeLevel = category.NodeLevel, mainParentId = createCategoryViewModel.MainParentId });
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await UnitOfWork.CategoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                return BadRequest();
            }

            var model = Mapper.Map<UpdateCategoryViewModel>(category);
            model.CurrentPictureName = category.Picture;
            model.CurrentIconPictureName = category.IconPicture;
            model.ParentId = category.ParentId;
            model.NodeLevel = category.NodeLevel;

            ViewData["faqs"] = await UnitOfWork.FaqRepository.GetAllAsync();
            ViewData["faqCategories"] = await UnitOfWork.FaqCategoryRepository.GetAllAsync();
            ViewData["selectedFaqs"] = await UnitOfWork.FaqJobCategoryRepository.TableNoTracking.Where(f => f.JobCategoryId == category.Id)
                .Include(f => f.Faq)
                .Select(f => f.Faq).ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryViewModel updateCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                ViewData["faqs"] = await UnitOfWork.FaqRepository.GetAllAsync();
                ViewData["faqCategories"] = await UnitOfWork.FaqCategoryRepository.GetAllAsync();

                ViewData["selectedFaqs"] = await UnitOfWork.FaqJobCategoryRepository.TableNoTracking.Where(f => f.JobCategoryId == updateCategoryViewModel.Id)
                    .Include(f => f.Faq)
                    .Select(f => f.Faq).ToListAsync();

                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                return View(updateCategoryViewModel);
                #endregion
            }

            var category = await UnitOfWork.CategoryRepository.GetByIdAsync(updateCategoryViewModel.Id);

            if (category == null)
            {
                return BadRequest();
            }

            #region ( Check route is duplicated or not )
            bool result = await UnitOfWork.CategoryRepository.RouteExist(updateCategoryViewModel.Route, updateCategoryViewModel.Id);

            if (result)
            {
                ErrorAlert(Errors.RouteDuplicate);

                return View(updateCategoryViewModel);
            }
            #endregion

            category = Mapper.Map(updateCategoryViewModel, category);

            #region ( Pictures & Icon )
            #region ( Picture )
            if (updateCategoryViewModel.PictureFile != null)
            {
                var deletedFile = "";

                if (category.Picture != null)
                {
                    deletedFile = category.Picture;
                }

                var pictureName = await FtpService.UploadFileToFtpServer(updateCategoryViewModel.PictureFile, TypeFile.Image, Paths.Category, updateCategoryViewModel.PictureFile.FileName, 777, null, null, null, deletedFile);

                category.Picture = pictureName;
            }
            #endregion

            #region ( Icon )
            if (updateCategoryViewModel.IconPictureFile != null)
            {
                var deletedFile = "";

                if (category.IconPicture != null)
                {
                    deletedFile = category.IconPicture;
                }

                var mobilePictureName = await FtpService.UploadFileToFtpServer(updateCategoryViewModel.IconPictureFile, TypeFile.Image, Paths.Job, updateCategoryViewModel.IconPictureFile.FileName, 777, null, null, null, deletedFile);

                category.IconPicture = mobilePictureName;
            }
            #endregion
            #endregion

            await UnitOfWork.CategoryRepository.UpdateAsync(category);

            try
            {
                await UnitOfWork.SaveAsync();

                if (updateCategoryViewModel.Faqs != null)
                {
                    var currentFaqJobCategory = await UnitOfWork.FaqJobCategoryRepository.GetAllAsync(f => f.JobCategoryId == category.Id);

                    UnitOfWork.FaqJobCategoryRepository.RemoveRange(currentFaqJobCategory);

                    await UnitOfWork.SaveAsync();

                    foreach (var faqId in updateCategoryViewModel.Faqs)
                    {
                        var faqJobCategory = new FaqJobCategory()
                        {
                            JobCategoryId = category.Id,
                            FaqId = faqId,
                        };

                        await UnitOfWork.FaqJobCategoryRepository.InsertAsync(faqJobCategory);
                    }

                    await UnitOfWork.SaveAsync();
                }

                #region ( Category Keyword )

                var categoryKeyword = await UnitOfWork.KeywordRepository.Table.SingleOrDefaultAsync(a => a.CategoryId.Equals(category.Id) && a.IsCategory);
                if (categoryKeyword != null)
                {
                    var keyword = Mapper.Map(category, categoryKeyword);

                    await UnitOfWork.KeywordRepository.UpdateAsync(keyword);
                    await UnitOfWork.SaveAsync();
                }

                #endregion

                #region ( Remove Cache Data )

                await DistributedCache.RemoveAsync(key: CacheKeys.GetAllKeywordsQuery());
                await DistributedCache.RemoveAsync(key: CacheKeys.GetAllCategoriesQuery());

                #endregion

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            if (category.NodeLevel == 3)
            {
                var categoryMainParent = await UnitOfWork.CategoryRepository.GetByIdAsync(category.ParentId);

                return RedirectToAction("Index", new { parentId = category.ParentId, nodeLevel = category.NodeLevel, mainParentId = categoryMainParent.ParentId });
            }
            else
            {
                return RedirectToAction("Index", new { parentId = category.ParentId, nodeLevel = category.NodeLevel, });
            }
        }
        #endregion

        #region ( Set Activation )
        [HttpPost]
        public async Task<IActionResult> SetActivation(int id, bool active)
        {
            var category = await UnitOfWork.CategoryRepository.GetByIdAsync(id);

            if (category != null)
            {
                category.IsDeleted = active;
                category.IsActive = active;

                await UnitOfWork.CategoryRepository.UpdateAsync(category);
            }
            else
            {
                return BadRequest();
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

        #region ( Target Categories )
        #region ( Index )
        [HttpGet]
        public async Task<IActionResult> IndexCustomizeCategoryLink()
        {
            var model = await UnitOfWork.TargetRepository.GetAllAsync();
            return View(model);
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> CreateCustomizeCategoryLinks()
        {
            var categories = await UnitOfWork.CategoryRepository.GetAllAsync(a => a.ParentId != 0 && a.NodeLevel == 3 && a.IsActive);

            ViewData["categories"] = categories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomizeCategoryLinks(int categoryId, int[] originCategories)
        {
            if (categoryId == 0 || originCategories.Length == 0 || originCategories.Length == 0)
            {
                ErrorAlert(Errors.ModelStateIsNotValidForm);

                return RedirectToAction("IndexCustomizeCategoryLink");
            }

            try
            {
                var currentCategories =
                    await UnitOfWork.CategoryRepository.GetAllAsync(a => a.ParentId != 0 && a.NodeLevel == 3);

                var targets = await UnitOfWork.TargetRepository.GetAllAsync();

                #region ( Remove All Current Destination if Exist )
                var targetDestinationExist = targets.Where(t => t.DestinationCategoryId == categoryId).ToList();

                if (targetDestinationExist.Any())
                {
                    UnitOfWork.TargetRepository.RemoveRange(targetDestinationExist);
                    await UnitOfWork.SaveAsync();
                }
                #endregion

                #region ( Remove All Current Origin If Exist )
                foreach (var isExistOrigin in originCategories)
                {
                    var targetOriginExist = targets.Where(t => t.OriginCategoryId == isExistOrigin).ToList();

                    if (targetOriginExist.Any())
                    {
                        UnitOfWork.TargetRepository.RemoveRange(targetDestinationExist);
                    }
                }

                await UnitOfWork.SaveAsync();

                #endregion

                foreach (var originCategoryId in originCategories)
                {
                    var nameofDestinationCategory = currentCategories.Where(a => a.Id == categoryId).Select(a => a.Name).First();
                    var nameofOriginCategoryCategory = currentCategories.Where(a => a.Id == originCategoryId).Select(a => a.Name).First();

                    var target = new Target()
                    {
                        DestinationCategoryId = categoryId,
                        DestinationCategoryName = nameofDestinationCategory,
                        OriginCategoryId = originCategoryId,
                        OriginCategoryName = nameofOriginCategoryCategory,
                    };

                    await UnitOfWork.TargetRepository.InsertAsync(target);
                }

                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexCustomizeCategoryLink");
        }
        #endregion

        #region ( Delete )
        [HttpGet]
        public async Task<IActionResult> DeleteCustomizeCategoryLinks(int targetId)
        {
            var target = await UnitOfWork.TargetRepository.GetByPredicate(t => t.Id == targetId);

            if (target != null)
            {
                await UnitOfWork.TargetRepository.DeleteAsync(target);
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

            return RedirectToAction("IndexCustomizeCategoryLink");
        }
        #endregion
        #endregion

        #region ( Customize Content Cities By Category )
        #region ( Index )
        [HttpGet]
        public async Task<IActionResult> IndexCustomizeCategoriesCityContent(CategoriesCityContentsFilterViewModel filter)
        {
            var categories = await UnitOfWork.CategoryRepository
                .GetAllAsync(a => a.ParentId != 0 && a.NodeLevel == 3);
            ViewData["categories"] = categories;


            var cities = await UnitOfWork.CityRepository.GetAllAsync(c => c.Status);
            ViewData["cities"] = cities;

            return View(UnitOfWork.CategoriesCityContentRepository.GetByFilterAdmin(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> CreateCategoriesCityContent()
        {
            var categories = await UnitOfWork.CategoryRepository
                .GetAllAsync(a => a.ParentId != 0 && a.NodeLevel == 3);
            ViewData["categories"] = categories;


            var cities = await UnitOfWork.CityRepository.GetAllAsync(c => c.Status);
            ViewData["cities"] = cities;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoriesCityContent(int categoryId, int cityId, string content)
        {
            if (categoryId == null || cityId == null || content == null)
            {
                ErrorAlert("مقادیر نباید خالی باشند.");

                return RedirectToAction("IndexCustomizeCategoriesCityContent");
            }

            try
            {
                var currentCategory = await UnitOfWork.CategoryRepository.GetByPredicate(c => c.Id == categoryId);
                var currentCity = await UnitOfWork.CityRepository.GetByPredicate(c => c.CityBaseId == cityId);

                var categoriesCityContents = await UnitOfWork.CategoriesCityContentRepository.GetAllAsync();

                #region ( Remove All Current Categories CityContentsExist if Exist )
                var categoriesCityContentsExist = categoriesCityContents.Where(t => t.CategoryId == categoryId && t.CityId == cityId)
                    .ToList();

                if (categoriesCityContentsExist.Any())
                {
                    ErrorAlert("برای این شهر در این دسته بندی قبلا اطلاعات ثبت کردید!");

                    return RedirectToAction("IndexCustomizeCategoriesCityContent");
                }
                #endregion

                var newCategoriesCityContent = new CategoriesCityContent()
                {
                    CategoryId = categoryId,
                    CategoryName = currentCategory.Name,

                    CityId = currentCity.CityBaseId,
                    CityName = currentCity.Subtitle,

                    Content = content,
                };

                await UnitOfWork.CategoriesCityContentRepository.InsertAsync(newCategoriesCityContent);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexCustomizeCategoriesCityContent");
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> UpdateCategoriesCityContent(int id)
        {
            var categories = await UnitOfWork.CategoryRepository
                .GetAllAsync(a => a.ParentId != 0 && a.NodeLevel == 3);
            ViewData["categories"] = categories;

            var cities = await UnitOfWork.CityRepository.GetAllAsync(c => c.Status);
            ViewData["cities"] = cities;

            var model = await UnitOfWork.CategoriesCityContentRepository.GetByPredicate(c => c.Id == id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategoriesCityContent(CategoriesCityContent categoriesCityContent)
        {
            try
            {
                var currentModel =
                    await UnitOfWork.CategoriesCityContentRepository.GetByPredicate(c => c.Id == categoriesCityContent.Id);

                currentModel.Content = categoriesCityContent.Content;

                await UnitOfWork.CategoriesCityContentRepository.UpdateAsync(currentModel);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexCustomizeCategoriesCityContent");
        }
        #endregion

        #region ( Delete )
        [HttpGet]
        public async Task<IActionResult> DeleteCustomizeCategoriesCityContent(int id)
        {
            var categoriesCityContents = await UnitOfWork.CategoriesCityContentRepository.GetByPredicate(t => t.Id == id);

            if (categoriesCityContents != null)
            {
                await UnitOfWork.CategoriesCityContentRepository.DeleteAsync(categoriesCityContents);
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

            return RedirectToAction("IndexCustomizeCategoriesCityContent");
        }
        #endregion
        #endregion

        #region ( Related Category )
        [HttpGet]
        public async Task<IActionResult> IndexRelatedCategorySeo(RelatedCategorySeoFilterViewModel filter)
        {
            var cities = await UnitOfWork.CityRepository.GetAllAsync(c => c.Status);
            ViewData["cities"] = cities;

            return View(UnitOfWork.RelatedCategorySeoRepository.GetByFilterAdmin(filter));
        }

        [HttpGet]
        public async Task<IActionResult> CreateRelatedCategorySeo()
        {
            var cities = await UnitOfWork.CityRepository.GetAllAsync(c => c.Status);
            ViewData["cities"] = cities;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRelatedCategorySeo(int currentCityId, string[] displayedCityNames, RelatedCategorySeo relatedCategorySeo)
        {
            string[] displayedCityNamesArray = displayedCityNames;

            if (currentCityId == null || displayedCityNamesArray.Length == 0)
            {
                ErrorAlert("مقادیر نباید خالی باشند.");

                return RedirectToAction("IndexRelatedCategorySeo");
            }

            try
            {
                var currentCity = await UnitOfWork.CityRepository.GetByPredicate(c => c.CityBaseId == currentCityId);
                if (currentCity == null)
                {
                    ErrorAlert("شهر یافت نشد");

                    return RedirectToAction("IndexRelatedCategorySeo");
                }

                int sort = relatedCategorySeo.Sort;

                foreach (var displayedCityName in displayedCityNamesArray)
                {
                    var newRelatedCategorySeo = new RelatedCategorySeo()
                    {
                        Title = displayedCityName,
                        CurrentCityId = currentCity.CityBaseId,
                        CurrentCityName = currentCity.Subtitle,

                        DisplayedCityName = displayedCityName,
                        Link = relatedCategorySeo.Link,
                        Sort = sort,
                    };

                    await UnitOfWork.RelatedCategorySeoRepository.InsertAsync(newRelatedCategorySeo);

                    sort++;
                }

                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexRelatedCategorySeo");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRelatedCategorySeo(int id)
        {
            var model = await UnitOfWork.RelatedCategorySeoRepository.GetByPredicate(r => r.Id == id);

            if (model == null)
            {
                ErrorAlert("چیزی یافت نشد!");

                return RedirectToAction("IndexRelatedCategorySeo");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRelatedCategorySeo(RelatedCategorySeo relatedCategorySeo)
        {
            var model = await UnitOfWork.RelatedCategorySeoRepository.GetByPredicate(r => r.Id == relatedCategorySeo.Id);
            if (model == null)
            {
                ErrorAlert("چیزی یافت نشد!");

                return RedirectToAction("IndexRelatedCategorySeo");
            }

            model.Sort = relatedCategorySeo.Sort;
            model.Link = relatedCategorySeo.Link;
            model.DisplayedCityName = relatedCategorySeo.DisplayedCityName;

            await UnitOfWork.RelatedCategorySeoRepository.UpdateAsync(model);
            await UnitOfWork.SaveAsync();

            SuccessAlert();

            return RedirectToAction("IndexRelatedCategorySeo");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRelatedCategorySeo(int id)
        {
            var relatedCategorySeo = await UnitOfWork.RelatedCategorySeoRepository.GetByPredicate(t => t.Id == id);

            if (relatedCategorySeo != null)
            {
                await UnitOfWork.RelatedCategorySeoRepository.DeleteAsync(relatedCategorySeo);
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

            return RedirectToAction("IndexRelatedCategorySeo");
        }
        #endregion

        #region ( Category Tag )
        #region ( Index )
        [HttpGet]
        public async Task<IActionResult> IndexCategoryTag(TagsFilterViewModel filter)
        {
            filter.TagType = TagType.Category;

            var model = UnitOfWork.TagRepository.GetByFilter(filter);

            ViewData["categories"] = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive && c.NodeLevel == 3);

            return View(model);
        }
        #endregion

        #region ( Create )
        [HttpPost]
        public async Task<IActionResult> CreateCategoryTag(CreateTagViewModel createTagViewModel, int categoryId)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                ErrorAlert(Errors.ModelStateIsNotValidForm);

                return RedirectToAction("IndexCategoryTag");
                #endregion
            }

            var tag = Mapper.Map<Tag>(createTagViewModel);

            var iconName = await FtpService.UploadFileToFtpServer(createTagViewModel.IconPictureFile, TypeFile.Image, Paths.Tag, createTagViewModel.IconPictureFile.FileName);

            tag.IconPicture = iconName;
            tag.Type = TagType.Category;

            await UnitOfWork.TagRepository.InsertAsync(tag);

            try
            {
                await UnitOfWork.SaveAsync();

                var categoryTag = new CategoryTag()
                {
                    TagId = tag.Id,
                    CategoryId = categoryId
                };

                await UnitOfWork.CategoryTagRepository.InsertAsync(categoryTag);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexCategoryTag");
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> UpdateCategoryTag(int tagId)
        {
            var currentTags = await UnitOfWork.TagRepository.GetByIdAsync(tagId);

            if (currentTags == null)
            {
                ErrorAlert("تگ یافت نشد!");

                return RedirectToAction("Index");
            }

            var model = Mapper.Map<UpdateTagViewModel>(currentTags);
            model.CurrentIconPicture = currentTags.IconPicture;

            ViewData["categories"] = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive && c.NodeLevel == 3);
            ViewData["currentCategoryId"] = await UnitOfWork.CategoryTagRepository.TableNoTracking.Where(t => t.TagId == tagId).Select(t => t.CategoryId).FirstOrDefaultAsync();

            return PartialView("_UpdateCategoryTag", model);
        }

        //todo: check and fix remove bug
        [HttpPost]
        public async Task<IActionResult> UpdateCategoryTag(UpdateTagViewModel updateTagViewModel, int currentCategoryId, int categoryId)
        {
            if (!ModelState.IsValid)
            {
                ErrorAlert(Errors.ModelStateIsNotValidForm);

                return RedirectToAction("IndexCategoryTag");
            }

            var tag = await UnitOfWork.TagRepository.GetByIdAsync(updateTagViewModel.Id);

            tag = Mapper.Map(updateTagViewModel, tag);

            #region ( Picture )
            if (updateTagViewModel.IconPictureFile != null)
            {
                var deletedFile = "";

                if (tag.IconPicture != null)
                {
                    deletedFile = tag.IconPicture;
                }

                var iconName = await FtpService.UploadFileToFtpServer(updateTagViewModel.IconPictureFile, TypeFile.Image, Paths.Tag, updateTagViewModel.IconPictureFile.FileName, 777, null, null, null, deletedFile);

                tag.IconPicture = iconName;
            }
            #endregion

            tag.Type = TagType.Category;

            await UnitOfWork.TagRepository.UpdateAsync(tag!);

            try
            {
                await UnitOfWork.SaveAsync();

                #region ( Find And Delete Current Tag )
                var categoryTag = await UnitOfWork.CategoryTagRepository.GetByPredicate(t => t.TagId == updateTagViewModel.Id && t.CategoryId == currentCategoryId);

                if (categoryTag != null)
                {
                    await UnitOfWork.CategoryTagRepository.DeleteAsync(categoryTag);
                }
                #endregion

                #region ( Insert New Tag )
                var newCategoryTag = new CategoryTag()
                {
                    TagId = tag.Id,
                    CategoryId = categoryId
                };

                await UnitOfWork.CategoryTagRepository.InsertAsync(newCategoryTag);
                await UnitOfWork.SaveAsync();
                #endregion

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexCategoryTag");
        }
        #endregion

        #region ( Set Activation )
        [HttpGet]
        public async Task<IActionResult> SetActivationCategoryTag(int id, bool active)
        {
            var tag = await UnitOfWork.TagRepository.GetByIdAsync(id);

            tag.Status = active;

            try
            {
                await UnitOfWork.TagRepository.UpdateAsync(tag);
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
        #endregion
    }
}
