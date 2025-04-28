namespace Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region ( Constructor )

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        #endregion

        #region ( Database Set )
        #region ( Address )
        public DbSet<Address> Address { get; set; }
        #endregion

        #region ( Banner )
        public DbSet<Brand> Brand { get; set; }
        #endregion

        #region ( Blog )
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<BlogCategoryRel> BlogCategoryRel { get; set; }
        public DbSet<BlogTag> BlogTag { get; set; }
        #endregion

        #region ( Brand )
        public DbSet<Banner> Banner { get; set; }
        #endregion

        #region ( Category )
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryService> CategoryService { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<CategoriesCityContent> CategoriesCityContents { get; set; }
        public DbSet<RelatedCategorySeo> RelatedCategorySeo { get; set; }
        public DbSet<CategoryTag> CategoryTags { get; set; }
        #endregion

        #region ( City )
        public DbSet<City> City { get; set; }
        public DbSet<CityBase> CityBase { get; set; }
        public DbSet<CityCategory> CityCategory { get; set; }
        #endregion

        #region ( Commnet )
        public DbSet<Comment> Comment { get; set; }
        public DbSet<AnswerComment> AnswerComment { get; set; }
        #endregion

        #region ( Config )
        public DbSet<Config> Config { get; set; }
        #endregion

        #region ( Contact Us )
        public DbSet<ContactUs> ContactUs { get; set; }
        #endregion

        #region ( Day Of Week )
        public DbSet<Domain.Entities.DayOfWeek.DayOfWeek> DayOfWeek { get; set; }
        #endregion

        #region ( Faq )
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<FaqCategory> FaqCategory { get; set; }
        public DbSet<FaqJobCategory> FaqJobCategories { get; set; }
        #endregion

        #region ( Feedback Slider )
        public DbSet<FeedbackSlider> FeedbackSlider { get; set; }
        #endregion

        #region ( Job )
        public DbSet<Job> Job { get; set; }
        public DbSet<JobTag> JobTag { get; set; }
        public DbSet<JobBranch> JobBranch { get; set; }
        public DbSet<JobBranchTag> JobBranchTag { get; set; }
        public DbSet<JobCategory> JobCategory { get; set; }
        public DbSet<JobSelectionSlider> JobSelectionSlider { get; set; }
        public DbSet<JobBranchShortLink> JobBranchShortLink { get; set; }
        public DbSet<JobBranchRelatedJob> JobBranchRelatedJob { get; set; }
        public DbSet<JobBranchAds> JobBranchAds { get; set; }
        public DbSet<JobBranchGallery> JobBranchGallery { get; set; }
        public DbSet<JobTimeWork> JobTimeWork { get; set; }
        public DbSet<JobService> JobService { get; set; }
        public DbSet<JobCategoriesView> JobCategoriesView { get; set; }

        public DbSet<JobKeyword> JobKeyword { get; set; }
        public DbSet<Keyword> Keyword { get; set; }

        public DbSet<JobInfo> JobInfo { get; set; }
        public DbSet<JobRanking> JobRanking { get; set; }
        #endregion

        #region ( Location )
        public DbSet<Location> Location { get; set; }
        #endregion

        #region ( Main Slider )
        public DbSet<MainSlider> MainSlider { get; set; }
        #endregion

        #region ( Message Box )
        public DbSet<MessageBox> MessageBox { get; set; }
        #endregion

        #region ( Panel Tutorial )
        public DbSet<PanelTutorial> PanelTutorial { get; set; }
        #endregion

        #region ( Payment )
        public DbSet<PromotionCode> PromotionCode { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentPortal> PaymentPortal { get; set; }
        #endregion

        #region ( Redirection Url )
        public DbSet<RedirectionUrl> RedirectionUrl { get; set; }
        #endregion

        #region ( Service )
        public DbSet<Service> Service { get; set; }
        #endregion

        #region ( Short Link )
        public DbSet<ShortLink> ShortLink { get; set; }
        #endregion

        #region ( State )
        public DbSet<StateBase> StateBase { get; set; }
        public DbSet<State> State { get; set; }
        #endregion

        #region ( Subscription )
        public DbSet<Click> Click { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<SubscriptionClick> SubscriptionClick { get; set; }
        public DbSet<SubscriptionFeature> SubscriptionFeature { get; set; }
        public DbSet<UserSubscription> UserSubscription { get; set; }
        #endregion

        #region ( Tag )
        public DbSet<Tag> Tag { get; set; }
        #endregion

        #region ( Team )
        public DbSet<Team> Team { get; set; }
        #endregion

        #region ( Time Work )
        //public DbSet<TimeWork> TimeWorks { get; set; }
        //public DbSet<TimeWorkDayOfWeek> TimeWorkDayOfWeeks { get; set; }
        #endregion

        #region ( Transaction )
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<WalletTransaction> WalletTransaction { get; set; }
        #endregion

        #region ( Uploaded Files )
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        #endregion

        #region ( User )
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<UsersFeedbackSlider> UsersFeedbackSlider { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<UserBannerClick> UserBannerClick { get; set; }
        public DbSet<UserBannerView> UserBannerView { get; set; }
        public DbSet<UserBlogLike> UserBlogLike { get; set; }
        public DbSet<UserBookMark> UserBookMark { get; set; }

        public DbSet<UserTokens> UserToken { get; set; }
        #endregion
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MainSlider>().HasOne(i => i.State)
                .WithMany(a => a.MainSliders).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Address>().HasOne(i => i.State)
                .WithMany(a => a.Addresses).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<JobBranch>().HasOne(i => i.ApplicationUser)
                .WithMany(a => a.JobBranches).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<JobBranch>().HasOne(i => i.Address)
                .WithOne(a => a.JobBranch).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<JobBranch>().HasOne(i => i.Job)
                .WithMany(a => a.JobBranches).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserAddress>().HasOne(i => i.CityBase)
                .WithMany(a => a.UserAddresses).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserAddress>().HasOne(i => i.ApplicationUser)
                .WithMany(a => a.UserAddresses).OnDelete(DeleteBehavior.NoAction);

            /// 
            modelBuilder
                .Entity<JobCategoriesView>(
                eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("JobCategoriesView");
                });
            /// 

            modelBuilder.AddSequentialGuidForIdConvention();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressConfigurations).Assembly);
            modelBuilder.HasDefaultSchema(DatabaseSchemas.Dbo);
        }
    }
}