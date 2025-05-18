
namespace Persistence.Contracts
{
    public class UnitOfWork : UnitOfWork<ApplicationDbContext>, IUnitOfWork
    {
        #region ( Constructor )
        public UnitOfWork(Options options) : base(options: options)
        {
        }
        #endregion

        #region ( Address )
        private IAddressRepository? _addressRepository;
        public IAddressRepository AddressRepository
        {
            get
            {
                if (_addressRepository is null)
                {
                    _addressRepository = new AddressRepository(DatabaseContext);
                }

                return _addressRepository;
            }
        }
        #endregion

        #region ( Banner )
        private IBannerRepository? _bannerRepository;
        public IBannerRepository BannerRepository
        {
            get
            {
                if (_bannerRepository == null)
                {
                    _bannerRepository = new BannerRepository(DatabaseContext);
                }

                return _bannerRepository;
            }
        }
        #endregion

        #region ( Blog )
        private IBlogCategoryRelRepository? _blogCategoryRelRepository;
        public IBlogCategoryRelRepository BlogCategoryRelRepository
        {
            get
            {
                if (_blogCategoryRelRepository == null)
                {
                    _blogCategoryRelRepository = new BlogCategoryRelRepository(DatabaseContext);
                }

                return _blogCategoryRelRepository;
            }
        }


        private IBlogCategoryRepository? _blogCategoryRepository;
        public IBlogCategoryRepository BlogCategoryRepository
        {
            get
            {
                if (_blogCategoryRepository == null)
                {
                    _blogCategoryRepository = new BlogCategoryRepository(DatabaseContext);
                }

                return _blogCategoryRepository;
            }
        }


        private IBlogTagRepository? _blogTagRepository;
        public IBlogTagRepository BlogTagRepository
        {
            get
            {
                if (_blogTagRepository == null)
                {
                    _blogTagRepository = new BlogTagRepository(DatabaseContext);
                }

                return _blogTagRepository;
            }
        }


        private IBlogRepository? _blogRepository;
        public IBlogRepository BlogRepository
        {
            get
            {
                if (_blogRepository == null)
                {
                    _blogRepository = new BlogRepository(DatabaseContext);
                }

                return _blogRepository;
            }
        }
        #endregion

        #region ( Brand )
        private IBrandRepository? _brandRepository;
        public IBrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                {
                    _brandRepository = new BrandRepository(DatabaseContext);
                }

                return _brandRepository;
            }
        }
        #endregion

        #region ( Category )
        private ICategoryRepository? _categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(DatabaseContext);
                }

                return _categoryRepository;
            }
        }


        private ICategoryServiceRepository? _categoryServiceRepository;
        public ICategoryServiceRepository CategoryServiceRepository
        {
            get
            {
                if (_categoryServiceRepository == null)
                {
                    _categoryServiceRepository = new CategoryServiceRepository(DatabaseContext);
                }

                return _categoryServiceRepository;
            }
        }


        private ICategoriesCityContentRepository? _categoriesCityContentRepository;
        public ICategoriesCityContentRepository CategoriesCityContentRepository
        {
            get
            {
                if (_categoriesCityContentRepository == null)
                {
                    _categoriesCityContentRepository = new CategoriesCityContentRepository(DatabaseContext);
                }

                return _categoriesCityContentRepository;
            }
        }


        private ITargetRepository? _targetRepository;
        public ITargetRepository TargetRepository
        {
            get
            {
                if (_targetRepository == null)
                {
                    _targetRepository = new TargetRepository(DatabaseContext);
                }

                return _targetRepository;
            }
        }


        private IRelatedCategorySeoRepository? _relatedCategorySeoRepository;
        public IRelatedCategorySeoRepository RelatedCategorySeoRepository
        {
            get
            {
                if (_relatedCategorySeoRepository == null)
                {
                    _relatedCategorySeoRepository = new RelatedCategorySeoRepository(DatabaseContext);
                }

                return _relatedCategorySeoRepository;
            }
        }


        private ICategoryTagRepository _categoryTagRepository;
        public ICategoryTagRepository CategoryTagRepository => _categoryTagRepository ??= new CategoryTagRepository(DatabaseContext);

        #endregion

        #region ( City )
        private ICityBaseRepository? _cityBaseRepository;
        public ICityBaseRepository CityBaseRepository
        {
            get
            {
                if (_cityBaseRepository == null)
                {
                    _cityBaseRepository = new CityBaseRepository(DatabaseContext);
                }

                return _cityBaseRepository;
            }
        }


        private ICityCategoryRepository? _cityCategoryRepository;
        public ICityCategoryRepository CityCategoryRepository
        {
            get
            {
                if (_cityCategoryRepository == null)
                {
                    _cityCategoryRepository = new CityCategoryRepository(DatabaseContext);
                }

                return _cityCategoryRepository;
            }
        }


        private ICityRepository? _cityRepository;
        public ICityRepository CityRepository
        {
            get
            {
                if (_cityRepository == null)
                {
                    _cityRepository = new CityRepository(DatabaseContext);
                }

                return _cityRepository;
            }
        }
        #endregion

        #region ( Comment )
        private ICommentInteractionRepository? _commentInteractionRepository;
        public ICommentInteractionRepository CommentInteractionRepository
        {
            get
            {
                if (_commentInteractionRepository == null)
                {
                    _commentInteractionRepository = new CommentInteractionRepository(DatabaseContext);
                }

                return _commentInteractionRepository;
            }
        }


        private IAnswerCommentRepository? _answerCommentRepository;
        public IAnswerCommentRepository AnswerCommentRepository
        {
            get
            {
                if (_answerCommentRepository == null)
                {
                    _answerCommentRepository = new AnswerCommentRepository(DatabaseContext);
                }

                return _answerCommentRepository;
            }
        }


        private ICommentRepository? _commentRepository;
        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(DatabaseContext);
                }

                return _commentRepository;
            }
        }
        #endregion

        #region ( Config )
        private IConfigRepository? _configRepository;
        public IConfigRepository ConfigRepository
        {
            get
            {
                if (_configRepository == null)
                {
                    _configRepository = new ConfigRepository(DatabaseContext);
                }
                return _configRepository;
            }
        }
        #endregion

        #region ( Contact Us )
        private IContactusRepository? _contactusRepository;
        public IContactusRepository ContactusRepository
        {
            get
            {
                if (_contactusRepository == null)
                {
                    _contactusRepository = new ContactusRepository(DatabaseContext);
                }

                return _contactusRepository;
            }
        }
        #endregion

        #region ( Day Of Week )
        private IDayOfWeekRepository? _dayOfWeekRepository;
        public IDayOfWeekRepository DayOfWeekRepository
        {
            get
            {
                if (_dayOfWeekRepository == null)
                {
                    _dayOfWeekRepository = new DayOfWeekRepository(DatabaseContext);
                }

                return _dayOfWeekRepository;
            }
        }

        #endregion

        #region ( Faq )
        private IFaqCategoryRepository? _faqCategoryRepository;
        public IFaqCategoryRepository FaqCategoryRepository
        {
            get
            {
                if (_faqCategoryRepository == null)
                {
                    _faqCategoryRepository = new FaqCategoryRepository(DatabaseContext);
                }

                return _faqCategoryRepository;
            }
        }

        private IFaqRepository? _faqRepository;
        public IFaqRepository FaqRepository
        {
            get
            {
                if (_faqRepository == null)
                {
                    _faqRepository = new FaqRepository(DatabaseContext);
                }

                return _faqRepository;
            }
        }


        private IFaqJobCategoryRepository? _faqJobCategoryRepository;

        public IFaqJobCategoryRepository FaqJobCategoryRepository
        {
            get
            {
                if (_faqJobCategoryRepository == null)
                {
                    _faqJobCategoryRepository = new FaqJobCategoryRepository(DatabaseContext);
                }

                return _faqJobCategoryRepository;
            }
        }
        #endregion

        #region ( Feedback Slider )
        private IFeedbackSliderRepository? _feedbackSliderRepository;
        public IFeedbackSliderRepository FeedbackSliderRepository
        {
            get
            {
                if (_feedbackSliderRepository == null)
                {
                    _feedbackSliderRepository = new FeedbackSliderRepository(DatabaseContext);
                }

                return _feedbackSliderRepository;
            }
        }
        #endregion

        #region ( Job )
        private IJobBranchRepository? _jobBranchRepository;
        public IJobBranchRepository JobBranchRepository
        {
            get
            {
                if (_jobBranchRepository == null)
                {
                    _jobBranchRepository = new JobBranchRepository(DatabaseContext);
                }

                return _jobBranchRepository;
            }
        }

        private IJobBranchRelatedJobRepository? _jobBranchRelatedJobRepository;
        public IJobBranchRelatedJobRepository JobBranchRelatedJobRepository
        {
            get
            {
                if (_jobBranchRelatedJobRepository == null)
                {
                    _jobBranchRelatedJobRepository = new JobBranchRelatedJobRepository(DatabaseContext);
                }

                return _jobBranchRelatedJobRepository;
            }
        }

        private IJobBranchGalleryRepository? _jobBranchGalleryRepository;
        public IJobBranchGalleryRepository JobBranchGalleryRepository
        {
            get
            {
                if (_jobBranchGalleryRepository == null)
                {
                    _jobBranchGalleryRepository = new JobBranchGalleryRepository(DatabaseContext);
                }

                return _jobBranchGalleryRepository;
            }
        }


        private IJobBranchShortLinkRepository? _jobBranchShortLinkRepository;
        public IJobBranchShortLinkRepository JobBranchShortLinkRepository
        {
            get
            {
                if (_jobBranchShortLinkRepository == null)
                {
                    _jobBranchShortLinkRepository = new JobBranchShortLinkRepository(DatabaseContext);
                }

                return _jobBranchShortLinkRepository;
            }
        }


        private IJobBranchTagRepository? _jobBranchTagRepository;
        public IJobBranchTagRepository JobBranchTagRepository
        {
            get
            {
                if (_jobBranchTagRepository == null)
                {
                    _jobBranchTagRepository = new JobBranchTagRepository(DatabaseContext);
                }

                return _jobBranchTagRepository;
            }
        }


        private IJobCategoryRepository? _jobCategoryRepository;
        public IJobCategoryRepository JobCategoryRepository
        {
            get
            {
                if (_jobCategoryRepository == null)
                {
                    _jobCategoryRepository = new JobCategoryRepository(DatabaseContext);
                }

                return _jobCategoryRepository;
            }
        }


        private IJobRepository? _jobRepository;
        public IJobRepository JobRepository
        {
            get
            {
                if (_jobRepository == null)
                {
                    _jobRepository = new JobRepository(DatabaseContext);
                }

                return _jobRepository;
            }
        }


        private IJobSelectionSliderRepository? _jobSelectionSliderRepository;
        public IJobSelectionSliderRepository JobSelectionSliderRepository
        {
            get
            {
                if (_jobSelectionSliderRepository == null)
                {
                    _jobSelectionSliderRepository = new JobSelectionSliderRepository(DatabaseContext);
                }

                return _jobSelectionSliderRepository;
            }
        }


        private IJobServiceRepository? _jobServiceRepository;
        public IJobServiceRepository JobServiceRepository
        {
            get
            {
                if (_jobServiceRepository == null)
                {
                    _jobServiceRepository = new JobServiceRepository(DatabaseContext);
                }

                return _jobServiceRepository;
            }
        }


        private IJobTagRepository? _jobTagRepository;
        public IJobTagRepository JobTagRepository
        {
            get
            {
                if (_jobTagRepository == null)
                {
                    _jobTagRepository = new JobTagRepository(DatabaseContext);
                }

                return _jobTagRepository;
            }
        }


        private IJobTimeWorkRepository? _jobTimeWorkRepository;
        public IJobTimeWorkRepository JobTimeWorkRepository
        {
            get
            {
                if (_jobTimeWorkRepository == null)
                {
                    _jobTimeWorkRepository = new JobTimeWorkRepository(DatabaseContext);
                }

                return _jobTimeWorkRepository;
            }
        }


        private IJobBranchAdsRepository? _jobBranchAdsRepository;
        public IJobBranchAdsRepository JobBranchAdsRepository
        {
            get
            {
                if (_jobBranchAdsRepository == null)
                {
                    _jobBranchAdsRepository = new JobBranchAdsRepository(DatabaseContext);
                }

                return _jobBranchAdsRepository;
            }
        }

        private IJobKeywordRepository? _jobKeywordRepository;
        public IJobKeywordRepository JobKeywordRepository
        {
            get
            {
                if (_jobKeywordRepository == null)
                {
                    _jobKeywordRepository = new JobKeywordRepository(DatabaseContext);
                }

                return _jobKeywordRepository;
            }
        }

        private IKeywordRepository? _keywordRepository;
        public IKeywordRepository KeywordRepository
        {
            get
            {
                if (_keywordRepository == null)
                {
                    _keywordRepository = new KeywordRepository(DatabaseContext);
                }

                return _keywordRepository;
            }
        }

        private IJobRankingRepository? _jobRankingRepository;
        public IJobRankingRepository JobRankingRepository
        {
            get
            {
                if (_jobRankingRepository == null)
                {
                    _jobRankingRepository = new JobRankingRepository(DatabaseContext);
                }

                return _jobRankingRepository;
            }
        }

        private IJobRankingHistoryRepository? _jobRankingHistoryRepository;
        public IJobRankingHistoryRepository JobRankingHistoryRepository
        {
            get
            {   
                if (_jobRankingHistoryRepository == null)
                {
                    _jobRankingHistoryRepository = new JobRankingHistoryRepository(DatabaseContext);
                }

                return _jobRankingHistoryRepository;
            }
        }

        private IJobInfoRepository? _jobInfoRepository;
        public IJobInfoRepository JobInfoRepository
        {
            get
            {
                if (_jobInfoRepository == null)
                {
                    _jobInfoRepository = new JobInfoRepository(DatabaseContext);
                }

                return _jobInfoRepository;
            }
        }
        #endregion

        #region ( Location )
        private ILocationRepository? _locationRepository;
        public ILocationRepository LocationRepository
        {
            get
            {
                if (_locationRepository == null)
                {
                    _locationRepository = new LocationRepository(DatabaseContext);
                }

                return _locationRepository;
            }
        }
        #endregion

        #region ( Main Slider )
        private IMainSliderRepository? _mainSliderRepository;
        public IMainSliderRepository MainSliderRepository
        {
            get
            {
                if (_mainSliderRepository == null)
                {
                    _mainSliderRepository = new MainSliderRepository(DatabaseContext);
                }

                return _mainSliderRepository;
            }
        }
        #endregion

        #region ( Message Box )
        protected IMessageBoxRepository? _messageBoxRepository;
        public IMessageBoxRepository MessageBoxRepository
        {
            get
            {
                if (_messageBoxRepository == null)
                {
                    _messageBoxRepository = new MessageBoxRepository(DatabaseContext);
                }

                return _messageBoxRepository;
            }
        }
        #endregion

        #region ( Panel Tutorial )

        private IPanelTutorialRepository? _panelTutorialRepository;

        public IPanelTutorialRepository PanelTutorialRepository
        {
            get
            {
                if (_panelTutorialRepository == null)
                {
                    _panelTutorialRepository = new PanelTutorialRepository(DatabaseContext);
                }

                return _panelTutorialRepository;
            }
        }

        #endregion

        #region ( Payment )
        private IPaymentPortalRepository? _paymentPortalRepository;
        public IPaymentPortalRepository PaymentPortalRepository
        {
            get
            {
                if (_paymentPortalRepository == null)
                {
                    _paymentPortalRepository = new PaymentPortalRepository(DatabaseContext);
                }

                return _paymentPortalRepository;
            }
        }

        private IPaymentRepository _paymentRepository;
        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (_paymentRepository == null)
                {
                    _paymentRepository = new PaymentRepository(DatabaseContext);
                }

                return _paymentRepository;
            }
        }

        private IPromotionCodeRepository _promotionCodeRepository;
        public IPromotionCodeRepository PromotionCodeRepository
        {
            get
            {
                if (_promotionCodeRepository == null)
                {
                    _promotionCodeRepository = new PromotionCodeRepository(DatabaseContext);
                }

                return _promotionCodeRepository;
            }
        }
        #endregion

        #region ( Redirection Url )
        private IRedirectionUrlRepository? _redirectionUrlRepository;
        public IRedirectionUrlRepository RedirectionUrlRepository
        {
            get
            {
                if (_redirectionUrlRepository == null)
                {
                    _redirectionUrlRepository = new RedirectionUrlRepository(DatabaseContext);
                }

                return _redirectionUrlRepository;
            }
        }
        #endregion

        #region ( Service Repository )
        private IServiceRepository? _serviceRepository;
        public IServiceRepository ServiceRepository
        {
            get
            {
                if (_serviceRepository == null)
                {
                    _serviceRepository = new ServiceRepository(DatabaseContext);
                }

                return _serviceRepository;
            }
        }
        #endregion

        #region ( Short Link )
        private IShortLinkRepository? _shortLinkRepository;
        public IShortLinkRepository ShortLinkRepository
        {
            get
            {
                if (_shortLinkRepository == null)
                {
                    _shortLinkRepository = new ShortLinkRepository(DatabaseContext);
                }

                return _shortLinkRepository;
            }
        }
        #endregion

        #region ( State )
        private IStateRepository? _stateRepository;
        public IStateRepository StateRepository
        {
            get
            {
                if (_stateRepository == null)
                {
                    _stateRepository = new StateRepository(DatabaseContext);
                }

                return _stateRepository;
            }
        }

        private IStateBaseRepository? _stateBaseRepository;
        public IStateBaseRepository StateBaseRepository
        {
            get
            {
                if (_stateBaseRepository == null)
                {
                    _stateBaseRepository = new StateBaseRepository(DatabaseContext);
                }

                return _stateBaseRepository;
            }
        }
        #endregion

        #region ( Subscription )
        private IClickAdsSettingRepository? _clickAdsSettingRepository;
        public IClickAdsSettingRepository ClickAdsSettingRepository
        {
            get
            {
                if (_clickAdsSettingRepository == null)
                {
                    _clickAdsSettingRepository = new ClickAdsSettingRepository(DatabaseContext);
                }

                return _clickAdsSettingRepository;
            }
        }


        private IClickRepository? _clickRepository;
        public IClickRepository ClickRepository
        {
            get
            {
                if (_clickRepository == null)
                {
                    _clickRepository = new ClickRepository(DatabaseContext);
                }

                return _clickRepository;
            }
        }


        private IFeatureRepository? _featureRepository;
        public IFeatureRepository FeatureRepository
        {
            get
            {
                if (_featureRepository == null)
                {
                    _featureRepository = new FeatureRepository(DatabaseContext);
                }

                return _featureRepository;
            }
        }

        private ISubscriptionRepository? _subscriptionRepository;
        public ISubscriptionRepository SubscriptionRepository
        {
            get
            {
                if (_subscriptionRepository == null)
                {
                    _subscriptionRepository = new SubscriptionRepository(DatabaseContext);
                }

                return _subscriptionRepository;
            }
        }


        private ISubscriptionFeatureRepository? _subscriptionFeatureRepository;
        public ISubscriptionFeatureRepository SubscriptionFeatureRepository
        {
            get
            {
                if (_subscriptionFeatureRepository == null)
                {
                    _subscriptionFeatureRepository = new SubscriptionFeatureRepository(DatabaseContext);
                }

                return _subscriptionFeatureRepository;
            }
        }


        private ISubscriptionClickRepository? _subscriptionClickRepository;
        public ISubscriptionClickRepository SubscriptionClickRepository
        {
            get
            {
                if (_subscriptionClickRepository == null)
                {
                    _subscriptionClickRepository = new SubscriptionClickRepository(DatabaseContext);
                }

                return _subscriptionClickRepository;
            }
        }


        private IUserSubscriptionRepository? _userSubscriptionRepository;
        public IUserSubscriptionRepository UserSubscriptionRepository
        {
            get
            {
                if (_userSubscriptionRepository == null)
                {
                    _userSubscriptionRepository = new UserSubscriptionRepository(DatabaseContext);
                }

                return _userSubscriptionRepository;
            }
        }

        #endregion

        #region ( Tag )
        private ITagRepository? _tagRepository;
        public ITagRepository TagRepository
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new TagRepository(DatabaseContext);
                }

                return _tagRepository;
            }
        }
        #endregion

        #region ( Team )
        private ITeamRepository? _teamRepository;
        public ITeamRepository TeamRepository
        {
            get
            {
                if (_teamRepository == null)
                {
                    _teamRepository = new TeamRepository(DatabaseContext);
                }

                return _teamRepository;
            }
        }
        #endregion

        #region ( Uploaded File )
        private IUploadedFileRepository? _uploadedFileRepository;
        public IUploadedFileRepository UploadedFileRepository
        {
            get
            {
                if (_uploadedFileRepository == null)
                {
                    _uploadedFileRepository = new UploadedFileRepository(DatabaseContext);
                }

                return _uploadedFileRepository;
            }
        }
        #endregion

        #region ( User )
        private IApplicationUserRepository? _applicationUserRepository;
        public IApplicationUserRepository ApplicationUserRepository
        {
            get
            {
                if (_applicationUserRepository == null)
                {
                    _applicationUserRepository = new ApplicationUserRepository(DatabaseContext);
                }

                return _applicationUserRepository;
            }
        }


        private IUserAddressRepository? _userAddressRepository;
        public IUserAddressRepository UserAddressRepository
        {
            get
            {
                if (_userAddressRepository == null)
                {
                    _userAddressRepository = new UserAddressRepository(DatabaseContext);
                }

                return _userAddressRepository;
            }
        }


        private IUserBannerClickRepository? _userBannerClickRepository;
        public IUserBannerClickRepository UserBannerClickRepository
        {
            get
            {
                if (_userBannerClickRepository == null)
                {
                    _userBannerClickRepository = new UserBannerClickRepository(DatabaseContext);
                }

                return _userBannerClickRepository;
            }
        }


        private IUserBannerViewRepository? _userBannerViewRepository;
        public IUserBannerViewRepository UserBannerViewRepository
        {
            get
            {
                if (_userBannerViewRepository == null)
                {
                    _userBannerViewRepository = new UserBannerViewRepository(DatabaseContext);
                }

                return _userBannerViewRepository;
            }
        }


        private IUserBlogLikeRepository _userBlogLikeRepository;
        public IUserBlogLikeRepository UserBlogLikeRepository
        {
            get
            {
                if (_userBlogLikeRepository == null)
                {
                    _userBlogLikeRepository = new UserBlogLikeRepository(DatabaseContext);
                }

                return _userBlogLikeRepository;
            }
        }


        private IUserBookMarkRepository? _userBookMarkRepository;
        public IUserBookMarkRepository UserBookMarkRepository
        {
            get
            {
                if (_userBookMarkRepository == null)
                {
                    _userBookMarkRepository = new UserBookMarkRepository(DatabaseContext);
                }

                return _userBookMarkRepository;
            }
        }


        private IUserFeedbackSliderRepository? _userFeedbackSliderRepository;
        public IUserFeedbackSliderRepository UserFeedbackSliderRepository
        {
            get
            {
                if (_userFeedbackSliderRepository == null)
                {
                    _userFeedbackSliderRepository = new UserFeedbackSliderRepository(DatabaseContext);
                }

                return _userFeedbackSliderRepository;
            }
        }

        private IUserTokensRepository? _userTokensRepository;
        public IUserTokensRepository UserTokensRepository
        {
            get
            {
                if (_userTokensRepository == null)
                {
                    _userTokensRepository = new UserTokensRepository(DatabaseContext);
                }

                return _userTokensRepository;
            }
        }
        #endregion

        #region ( Wallet )
        private ITransactionRepository? _transactionRepository;
        public ITransactionRepository TransactionRepository
        {
            get
            {
                if (_transactionRepository == null)
                {
                    _transactionRepository = new TransactionRepository(DatabaseContext);
                }

                return _transactionRepository;
            }
        }


        private IWalletRepository? _walletRepository;
        public IWalletRepository WalletRepository
        {
            get
            {
                if (_walletRepository == null)
                {
                    _walletRepository = new WalletRepository(DatabaseContext);
                }

                return _walletRepository;
            }
        }


        private IWalletTransactionRepository? _walletTransactionRepository;
        public IWalletTransactionRepository WalletTransactionRepository
        {
            get
            {
                if (_walletTransactionRepository == null)
                {
                    _walletTransactionRepository = new WalletTransactionRepository(DatabaseContext);
                }

                return _walletTransactionRepository;
            }
        }
        #endregion
        //AI Recommendation

        #region ( Action Histories )
        private IActionHistoriesRepository? _actionHistoriesRepository;
        public IActionHistoriesRepository ActionHistoriesRepository
        {
            get
            {
                if (_actionHistoriesRepository == null)
                {
                    _actionHistoriesRepository = new ActionHistoriesRepository(DatabaseContext);
                }

                return _actionHistoriesRepository;
            }
        }
        #endregion

        #region ( JobCategoriesView )
        private IJobCategoriesViewRepository? _jobCategoriesViewRepository;
        public IJobCategoriesViewRepository JobCategoriesViewRepository
        {
            get
            {
                if (_jobCategoriesViewRepository == null)
                {
                    _jobCategoriesViewRepository = new JobCategoriesViewRepository(DatabaseContext);
                }

                return _jobCategoriesViewRepository;
            }
        }
        #endregion
    }
}
