namespace Constants.Files
{
    public static class Paths
    {
        public const string DefaultAvatarPath = "DefaultAvatar.jpg";
        public const string DefaultIconPath = "DefaultIcon.jpg";


        #region ( Faq )
        public static string Faq = "/content/images/faq/origin/";
        public static string FaqCategory = "/content/images/faq/origin/category/";

        public static string FaqImageServer =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/faq/origin/");
        #endregion
    }
}
