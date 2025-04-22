namespace ViewModels.QueriesResponseViewModel.Job
{
    public class JobInfoViewModel
    {
        public int Id { get; set; }
        public string Route { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Summary { get; set; }
        
        public string Content { get; set; }

        public string Email { get; set; }

        public string WebSiteName { get; set; }
        
        //public List<string>? Emails { get; set; }

        //public List<string>? WebSiteNames { get; set; }

        public int AverageRate { get; set; }

        public JobBranchStatus Status { get; set; }

        #region Contact Informations
        public List<PhoneNumberInfosViewModel> PhoneNumberInfos { get; set; } //Json Format (PhoneNumberInfosVm)

        public List<SocialMediaInfosViewModel> SocialMediaInfos { get; set; } //Json Format (SocialMediaInfosVm)

        #region Additional Info
        public bool? ShowPhoneTelInSite { get; set; }

        public bool? ShowFirstPhoneMobileInSite { get; set; }
        #endregion
        #endregion
    }
}
