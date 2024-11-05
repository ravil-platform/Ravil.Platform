namespace Constants.Files
{
    public static class Paths
    {
        public const string DefaultAvatarPath = "DefaultAvatar.jpg";
        public const string DefaultIconPath = "DefaultIcon.jpg";

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
    }
}
