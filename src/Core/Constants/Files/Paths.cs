namespace Constants.Files
{
    public static class Paths
    {
        public const string DefaultAvatarPath = "DefaultAvatar.jpg";
        public const string DefaultJobPath = "default.jpg";
        public const string DefaultIconPath = "DefaultIcon.jpg";
        public const string DefaultsImagePath = "/content/defaults/images/cms/";
        public static string DefaultsImageCmsPath = $"/content/defaults/images/cms/";
        public static string DefaultsImageJobPath = $"/content/defaults/images/job/{DefaultJobPath}";

        #region ( User )
        public static string User = "img/user";
        public static string UserServer = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{User}");
        #endregion

        #region ( Faq )
        public static string Faq = "/content/images/faq/origin/";
        public static string FaqCategory = "/content/images/faq/origin/category/";

        public static string FaqImageServer =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/faq/origin/");
        #endregion

        #region ( Job )
        public static string Job = "/img/job/";
        public static string JobImageServer = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{Job}");

        public static string JobBranch = "/img/job/branch/";
        public static string JobBranchImageServer = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{JobBranch}");

        public static string JobBranchGallery = "/img/gallery/branch/";
        public static string JobBranchGalleryServer = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{JobBranchGallery}");

        public static string JobBranchVideo = "/video/branch/";
        public static string JobBranchVideoServer = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{JobBranchVideo}");
        #endregion

        #region ( Category )
        public static string Category = "/img/category/";
        #endregion

        #region ( Cms )
        public static string Cms = "/img/cms/";
        public static string CmsBlogCategory = "/img/cms/category";
        public static string CmsBlogTag = "/img/cms/tag";
        #endregion

        #region ( Feedback Slider )
        public static string FeedbackSlider = "/img/slider/";
        #endregion

        #region ( Main Slider )
        public static string MainSlider = "/img/slider/";
        #endregion

        #region ( Banner )
        public static string Banner = "/img/banner/";
        #endregion

        #region ( Ckeditor Content )
        public static string CkeditorContent = "/img/ckeditor/content/";
        #endregion
    }
}
