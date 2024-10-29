namespace ViewModels.QueriesResponseViewModel.Job
{
    public class JobViewModel
    {
        public int Id { get; set; }
        public string Route { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public string LargePicture { get; set; }

        public string SmallPicture { get; set; }

        public string Email { get; set; }

        public string WebSiteName { get; set; }

        #region Contact Informations
        public string PhoneNumberInfos { get; set; } //Json Format (PhoneNumberInfosVm)

        public string SocialMediaInfos { get; set; } //Json Format (SocialMediaInfosVm)

        #region Additional Info
        public bool? ShowPhoneTelInSite { get; set; }

        public bool? ShowFirstPhoneMobileInSite { get; set; }
        #endregion
        #endregion

        public int AverageRate { get; set; }

        public bool IsGoogleData { get; set; } 
    }

    public class PhoneNumberInfosViewModel
    {
        public PhoneNumberInfosViewModel()
        {
            PhoneNumberType = PhoneNumberTypes.PhoneNumberTel;
        }

        public string PhoneNumber { get; set; }

        public PhoneNumberTypes PhoneNumberType { get; set; }
    }

    public class SocialMediaInfosViewModel
    {
        public SocialMediaInfosViewModel()
        {
            SocialMediaType = SocialMediaTypes.Telegram;
        }

        public string SocialMediaLink { get; set; }

        public SocialMediaTypes SocialMediaType { get; set; }
    }
}
