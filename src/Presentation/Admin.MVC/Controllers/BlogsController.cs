namespace Admin.MVC.Controllers
{
    public class BlogsController(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
        : BaseController
    {
        #region ( DI )
        protected IMapper Mapper { get; } = mapper;
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IFtpService FtpService { get; } = ftpService;
        #endregion

        #region ( Blog )
        #region ( Index )
        public IActionResult Index(BlogFilterAdminViewModel filter)
        {
            return View(UnitOfWork.BlogRepository.GetByFilterAdmin(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["categories"] = await UnitOfWork.BlogCategoryRepository.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogViewModel createBlogViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                ViewData["categories"] = await UnitOfWork.BlogCategoryRepository.GetAllAsync();

                return View();
            }

            var blog = Mapper.Map<Blog>(createBlogViewModel);

            var pictureName = await FtpService.UploadFileToFtpServer(createBlogViewModel.PictureFile, TypeFile.Image, Paths.Cms, createBlogViewModel.PictureFile.FileName);
            var mobilePictureName = await FtpService.UploadFileToFtpServer(createBlogViewModel.MobilePictureFile, TypeFile.Image, Paths.Cms, createBlogViewModel.MobilePictureFile.FileName);

            blog.LargePicture = pictureName;
            blog.SmallPicture = mobilePictureName;
            blog.Route = blog.Route.ToSlug();
            blog.CreateDate = DateTime.Now;

            //todo : set publisher
            //blog.AuthorName = User.Identity.GetUserName();
            blog.AuthorName = "راویل";

            await UnitOfWork.BlogRepository.InsertAsync(blog);

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
        public async Task<IActionResult> Update(int blogId)
        {
            var currentBlog = await UnitOfWork.BlogRepository.GetByIdAsync(blogId);

            var model = Mapper.Map<UpdateBlogViewModel>(currentBlog);

            ViewData["categories"] = await UnitOfWork.BlogCategoryRepository.GetAllAsync();

            model.CurrentMobilePictureName = currentBlog.SmallPicture;
            model.CurrentPictureName = currentBlog.LargePicture;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogViewModel updateBlogViewModel, bool detailPage = false)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                ViewData["categories"] = await UnitOfWork.BlogCategoryRepository.GetAllAsync();

                return View(updateBlogViewModel);
            }

            var blog = await UnitOfWork.BlogRepository.GetByIdAsync(updateBlogViewModel.Id);

            blog = Mapper.Map(updateBlogViewModel, blog);

            #region ( Blog is null )
            if (blog == null)
            {
                ErrorAlert();

                return RedirectToAction("Index");
            }
            #endregion

            #region ( Picture )
            #region ( Descktop )
            if (updateBlogViewModel.PictureFile != null)
            {
                var deletedFile = "";

                if (blog.LargePicture != null)
                {
                    deletedFile = blog.LargePicture;
                }

                var pictureName = await FtpService.UploadFileToFtpServer(updateBlogViewModel.PictureFile, TypeFile.Image, Paths.Cms, updateBlogViewModel.PictureFile.FileName, 777, null, null, null, deletedFile);

                blog.LargePicture = pictureName;
            }
            #endregion

            #region ( Mobile )
            if (updateBlogViewModel.MobilePictureFile != null)
            {
                var deletedFile = "";

                if (blog.SmallPicture != null)
                {
                    deletedFile = blog.SmallPicture;
                }

                var mobilePictureName = await FtpService.UploadFileToFtpServer(updateBlogViewModel.MobilePictureFile, TypeFile.Image, Paths.Cms, updateBlogViewModel.MobilePictureFile.FileName, 777, null, null, null, deletedFile);

                blog.SmallPicture = mobilePictureName;
            }
            #endregion
            #endregion

            blog.Route = blog.Route.ToSlug();
            blog.LastUpdateDate = DateTime.Now;

            await UnitOfWork.BlogRepository.UpdateAsync(blog!);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return detailPage ? RedirectToAction("Detail", new { Id = blog!.Id }) : RedirectToAction("Index");
        }
        #endregion

        #region ( Detail )
        public async Task<IActionResult> Detail(int blogId)
        {
            var model = await UnitOfWork.BlogRepository.GetByIdAsync(blogId);

            if (model == null)
            {
                ErrorAlert("وبلاگ یافت نشد!");

                return RedirectToAction("Index");
            }

            var tags = await UnitOfWork.BlogTagRepository.TableNoTracking
                .Where(b => b.BlogId == blogId)
                .Include(b => b.Tag)
                .Select(b => b.Tag).ToListAsync();

            ViewData["tags"] = tags;

            return View(model);
        }
        #endregion

        #region ( Set Activation )
        [HttpPost]
        public async Task<IActionResult> SetActivation(int id, bool active)
        {
            await UnitOfWork.BlogRepository.SetDelete(id, active);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { blogId = id });
        }
        #endregion
        #endregion

        #region ( Blog Category )
        #region ( Index )
        public IActionResult IndexBlogCategories(BlogCategoryFilterViewModel filter)
        {
            return View(UnitOfWork.BlogCategoryRepository.GetByFilter(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> CreateBlogCategories()
        {
            ViewData["categories"] = await UnitOfWork.BlogCategoryRepository.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogCategories(CreateBlogCategoryViewModel createBlogCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                ViewData["categories"] = await UnitOfWork.BlogCategoryRepository.GetAllAsync();

                return View();
            }

            var blogCategory = Mapper.Map<BlogCategory>(createBlogCategoryViewModel);

            //var iconName = await FtpService.UploadFileToFtpServer(createBlogCategoryViewModel.IconPictureFile, TypeFile.Image, Paths.CmsBlogCategory, createBlogCategoryViewModel.IconPictureFile.FileName);

            //blogCategory.IconPictureName = iconName;
            //blogCategory.Slug = blogCategory.Slug.ToSlug();

            await UnitOfWork.BlogCategoryRepository.InsertAsync(blogCategory);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexBlogCategories");
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> UpdateBlogCategories(int blogCategoryId)
        {
            var currentBlogCategory = await UnitOfWork.BlogCategoryRepository.GetByIdAsync(blogCategoryId);

            if (currentBlogCategory == null)
            {
                ErrorAlert("دسته یافت نشد!");

                return RedirectToAction("IndexBlogCategories");
            }

            var model = Mapper.Map<UpdateBlogCategoryViewModel>(currentBlogCategory);

            ViewData["categories"] = await UnitOfWork.BlogCategoryRepository.TableNoTracking.Where(b => b.Id != blogCategoryId).ToListAsync();

            //model.CurrentIconPictureName = currentBlogCategory.IconPictureName;
            model.ParentName =
                await UnitOfWork.BlogCategoryRepository.TableNoTracking
                    .Where(b => b.ParentId == currentBlogCategory.ParentId && b.Id != currentBlogCategory.Id)
                    .Select(b => b.Title)
                    .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlogCategories(UpdateBlogCategoryViewModel updateBlogCategoryViewModel, bool detailPage = false)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                ViewData["categories"] = await UnitOfWork.BlogCategoryRepository.TableNoTracking.Where(b => b.Id != updateBlogCategoryViewModel.Id).ToListAsync();

                return View();
            }

            var blogCategory = await UnitOfWork.BlogCategoryRepository.GetByIdAsync(updateBlogCategoryViewModel.Id);

            blogCategory = Mapper.Map(updateBlogCategoryViewModel, blogCategory);

            #region ( BlogCategory is null )
            if (blogCategory == null)
            {
                ErrorAlert();

                return RedirectToAction("IndexBlogCategories");
            }
            #endregion

            #region ( Picture )
            //if (updateBlogCategoryViewModel.IconPictureFile != null)
            //{
            //    var deletedFile = "";

            //    if (blogCategory.IconPictureName != null)
            //    {
            //        deletedFile = blogCategory.IconPictureName;
            //    }

            //    var iconName = await FtpService.UploadFileToFtpServer(updateBlogCategoryViewModel.IconPictureFile, TypeFile.Image, Paths.CmsBlogCategory, updateBlogCategoryViewModel.IconPictureFile.FileName, 777, null, null, null, deletedFile);

            //    blogCategory.IconPictureName = iconName;
            //}
            #endregion

            //blogCategory.Slug = blogCategory.Slug.ToSlug();

            await UnitOfWork.BlogCategoryRepository.UpdateAsync(blogCategory!);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return detailPage ? RedirectToAction("DetailBlogCategories", new { blogCategoryId = blogCategory!.Id }) : RedirectToAction("IndexBlogCategories");
        }
        #endregion

        #region ( Detail )
        public async Task<IActionResult> DetailBlogCategories(int blogCategoryId)
        {
            var model = await UnitOfWork.BlogCategoryRepository.GetByIdAsync(blogCategoryId);

            if (model == null)
            {
                ErrorAlert("دسته بندی یافت نشد!");

                return RedirectToAction("IndexBlogCategories");
            }

            return View(model);
        }
        #endregion

        #region ( Set Activation )
        [HttpPost]
        public async Task<IActionResult> SetActivationBlogCategories(int id, bool active)
        {
            await UnitOfWork.BlogCategoryRepository.SetActivation(id, active);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("DetailBlogCategories", new { BlogCategoryId = id });
        }
        #endregion
        #endregion

        #region ( Blog Comments )
        //#region ( Index )
        //[HttpGet]
        //public async Task<IActionResult> BlogComments(int blogId)
        //{
        //    var comments = await UnitOfWork.BlogCommentRepository.AsNoTrackingQueryable
        //        .Where(b => b.BlogId == blogId)
        //        .Select(b => b.Comment)
        //        .ToListAsync();

        //    return View(comments);
        //}
        //#endregion
        #endregion

        #region ( Blog Tags )
        [HttpGet]
        public async Task<IActionResult> BlogTags(int blogId)
        {
            #region ( Get All Tags )
            var tags = await UnitOfWork.TagRepository.GetAllAsync();
            #endregion

            #region ( Get Current Blog )
            var blog = await UnitOfWork.BlogRepository.TableNoTracking.Where(b => b.Id == blogId).Select(b => b.Title).SingleOrDefaultAsync();

            if (blog == null)
            {
                ErrorAlert("وبلاگ یافت نشد!");

                return RedirectToAction("Index");
            }
            #endregion

            #region ( Get Current Blog Tags )
            var currentBlogTags = await UnitOfWork.BlogTagRepository.TableNoTracking
                .Where(b => b.BlogId == blogId).Select(b => b.Tag).ToListAsync();
            #endregion

            #region ( Fill View Datas )
            ViewData["blog"] = blog;
            ViewData["blogId"] = blogId;
            ViewData["currentBlogTags"] = currentBlogTags;
            ViewData["tags"] = tags;
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BlogTags(int[] tags, int blogId)
        {
            var currentBlog = await UnitOfWork.BlogRepository.GetByIdAsync(blogId);

            if (currentBlog == null)
            {
                ErrorAlert();

                return RedirectToAction("Index");
            }

            if (tags.Length < 0)
            {
                ErrorAlert("لطفا حداقل یک تگ را انتخاب کنید");

                return RedirectToAction("BlogTags", new { blogId });
            }

            var currentTags = await UnitOfWork.BlogTagRepository.GetAllAsync(t => t.BlogId == blogId);

            if (currentTags != null || currentTags.Count > 0)
            {
                UnitOfWork.BlogTagRepository.RemoveRange(currentTags);
            }

            foreach (var item in tags)
            {
                var newTag = new BlogTag()
                {
                    BlogId = blogId,
                    TagId = item,
                };

                await UnitOfWork.BlogTagRepository.InsertAsync(newTag);
            }


            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                ErrorAlert(e.Message);
            }


            return RedirectToAction("Index");
        }
        #endregion

    }
}
