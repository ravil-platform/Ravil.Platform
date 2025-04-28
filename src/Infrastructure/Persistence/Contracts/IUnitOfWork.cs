namespace Persistence.Contracts
{
    public interface IUnitOfWork : RNX.Persistence.IUnitOfWork
    {
        #region ( Address )
        public IAddressRepository AddressRepository { get; }
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
        public IJobKeywordRepository JobKeywordRepository { get; }
        public IKeywordRepository KeywordRepository { get; }

        public IJobRankingRepository JobRankingRepository { get; }
        public IJobInfoRepository JobInfoRepository { get; }

        #endregion

        #region ( Location )
        public ILocationRepository LocationRepository { get; }
        #endregion

        #region ( Main Slider )
        public IMainSliderRepository MainSliderRepository { get; }
        #endregion

        #region ( Message Box )
        public IMessageBoxRepository MessageBoxRepository { get; }
        #endregion

        #region ( Pannel Tutorial )
        public IPanelTutorialRepository PanelTutorialRepository { get; }
        #endregion

        #region ( Payment )
        public IPromotionCodeRepository PromotionCodeRepository { get; }
        public IPaymentPortalRepository PaymentPortalRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
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

        #region ( Subscription ) 
        public IClickRepository ClickRepository { get; }
        public IFeatureRepository FeatureRepository { get; }
        public ISubscriptionRepository SubscriptionRepository { get; }
        public ISubscriptionFeatureRepository SubscriptionFeatureRepository { get; }
        public ISubscriptionClickRepository SubscriptionClickRepository { get; }
        public IUserSubscriptionRepository UserSubscriptionRepository { get; }
        #endregion

        #region ( Tag )
        public ITagRepository TagRepository { get; }
        #endregion

        #region ( Team )
        public ITeamRepository TeamRepository { get; }
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

        #region ( Wallet )
        public ITransactionRepository TransactionRepository { get; }
        public IWalletRepository WalletRepository { get; }
        public IWalletTransactionRepository WalletTransactionRepository { get; }
        #endregion

        //AI Recommendation

        #region ( Action Histories )
        public IActionHistoriesRepository ActionHistoriesRepository { get; }
        #endregion

        public IJobCategoriesViewRepository JobCategoriesViewRepository { get; }
    }
}