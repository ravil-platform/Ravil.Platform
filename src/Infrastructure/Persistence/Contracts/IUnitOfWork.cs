namespace Persistence.Contracts
{
    public interface IUnitOfWork : RNX.Persistence.IUnitOfWork
    {
        #region  ( Account )
        public IAccountAttrRepository AccountAttrRepository { get; }
        public IAccountCategoryRepository AccountCategoryRepository { get; }
        public IAccountLevelRepository AccountLevelRepository { get; }
        public IAccountRepository AccountRepository { get; }
        #endregion

        #region ( Address )
        public IAddressRepository AddressRepository { get; }
        #endregion

        #region ( Admin Theme )
        public IAdminThemeRepository AdminThemeRepository { get; }
        #endregion

        #region ( Attr )
        public IAttrAccountRepository AttrAccountRepository { get; }
        public IAttrAccountValueRepository AttrAccountValueRepository { get; }
        public IAttrCategoryRepository AttrCategoryRepository { get; }
        public IAttrRepository AttrRepository { get; }
        public IAttrValueRepository AttrValueRepository { get; }
        #endregion

        #region ( Banner )
        public IBannerRepository BannerRepository { get; }
        #endregion

        #region ( Blog )
        public IBlogCategoryRelRepository BlogCategoryRelRepository { get; }
        public IBlogCategoryRepository BlogCategoryRepository { get; }
        public IBlogTagRepository BlogTagRepository { get; }
        public IBlogRepository BlogRepository { get; }
        #endregion

        #region ( Brand )
        public IBrandRepository BrandRepository { get; }
        #endregion

        #region ( Category )
        public ICategoryRepository CategoryRepository { get; }
        public ICategoryServiceRepository CategoryServiceRepository { get; }
        public ICategoriesCityContentRepository CategoriesCityContentRepository { get; }
        public ITargetRepository TargetRepository { get; }
        public IRelatedCategorySeoRepository RelatedCategorySeoRepository { get; }
        public ICategoryTagRepository CategoryTagRepository { get; }
        #endregion

        #region ( City )
        public ICityBaseRepository CityBaseRepository { get; }
        public ICityCategoryRepository CityCategoryRepository { get; }
        public ICityRepository CityRepository { get; }
        #endregion

        #region ( Comment )
        public IAnswerCommentRepository AnswerCommentRepository { get; }
        public ICommentRepository CommentRepository { get; }
        #endregion

        #region ( Config )
        public IConfigRepository ConfigRepository { get; }
        #endregion

        #region ( Contact Us )
        public IContactusRepository ContactusRepository { get; }
        #endregion

        #region ( Day Of Week )
        public IDayOfWeekRepository DayOfWeekRepository { get; }
        #endregion

        #region ( Faq ) 
        public IFaqJobCategoryRepository FaqJobCategoryRepository { get; }
        public IFaqCategoryRepository FaqCategoryRepository { get; }
        public IFaqRepository FaqRepository { get; }
        #endregion

        #region ( Feedback Slider )
        public IFeedbackSliderRepository FeedbackSliderRepository { get; }
        #endregion

        #region ( Job )
        public IJobBranchAttrRepository JobBranchAttrRepository { get; }
        public IJobBranchRepository JobBranchRepository { get; }
        public IJobBranchRelatedJobRepository JobBranchRelatedJobRepository { get; }
        public IJobBranchGalleryRepository JobBranchGalleryRepository { get; }
        public IJobBranchShortLinkRepository JobBranchShortLinkRepository { get; }
        public IJobBranchTagRepository JobBranchTagRepository { get; }
        public IJobCategoryRepository JobCategoryRepository { get; }
        public IJobRepository JobRepository { get; }
        public IJobSelectionSliderRepository JobSelectionSliderRepository { get; }
        public IJobServiceRepository JobServiceRepository { get; }
        public IJobTagRepository JobTagRepository { get; }
        public IJobTimeWorkRepository JobTimeWorkRepository { get; }
        public IJobBranchAdsRepository JobBranchAdsRepository { get; }
        #endregion

        #region ( Location )
        public ILocationRepository LocationRepository { get; }
        #endregion

        #region ( Main Slider )
        public IMainSliderRepository MainSliderRepository { get; }
        #endregion

        #region ( Order )
        public IOrderRepository OrderRepository { get; }
        public IPromotionCodeRepository PromotionCodeRepository { get; }
        #endregion

        #region ( Payment Portal )
        public IPaymentPortalRepository PaymentPortalRepository { get; }
        #endregion

        #region ( Redirection Url )
        public IRedirectionUrlRepository RedirectionUrlRepository { get; }
        #endregion

        #region ( Service )
        public IServiceRepository ServiceRepository { get; }
        #endregion

        #region ( Short Link )
        public IShortLinkRepository ShortLinkRepository { get; }
        #endregion

        #region ( State )
        public IStateRepository StateRepository { get; }
        public IStateBaseRepository StateBaseRepository { get; }
        #endregion

        #region ( Tag )
        public ITagRepository TagRepository { get; }
        #endregion

        #region ( Team )
        public ITeamRepository TeamRepository { get; }
        #endregion

        #region ( Transaction )
        public ITransactionRepository TransactionRepository { get; }
        public IWalletRepository WalletRepository { get; }
        public IWalletTransactionRepository WalletTransactionRepository { get; }
        #endregion

        #region ( Uploaded File )
        public IUploadedFileRepository UploadedFileRepository { get; }
        #endregion

        #region ( User )
        public IApplicationUserRepository ApplicationUserRepository { get; }
        public IUserAddressRepository UserAddressRepository { get; }

        public IUserBannerClickRepository UserBannerClickRepository { get; }
        public IUserBannerViewRepository UserBannerViewRepository { get; }

        public IUserBlogLikeRepository UserBlogLikeRepository { get; }

        public IUserBookMarkRepository UserBookMarkRepository { get; }

        public IUserFeedbackSliderRepository UserFeedbackSliderRepository { get; }

        public IUserTokensRepository UserTokensRepository { get; }
        #endregion


        //AI Recommendation

        #region ( Action Histories )
        public IActionHistoriesRepository ActionHistoriesRepository { get; }
        #endregion

        public IJobCategoriesViewRepository JobCategoriesViewRepository { get; }
    }
}