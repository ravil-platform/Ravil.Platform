namespace ViewModels.QueriesResponseViewModel.Job
{
    public class CreateJobViewModel
    {
        public string? Route { get; set; }

        public string Title { get; set; }

        public string? SubTitle { get; set; }

        public string? Summary { get; set; }

        public string? Content { get; set; }

        public IFormFile? LargePictureFile { get; set; }

        public IFormFile? SmallPictureFile { get; set; }

        public string? Email { get; set; }

        public string? WebSiteName { get; set; }

        public List<SocialMediaInfosViewModel>? SocialMediaInfos { get; set; }

        public List<PhoneNumberInfosViewModel>? PhoneNumberInfos { get; set; }

        public bool? ShowPhoneTelInSite { get; set; }

        public bool? ShowFirstPhoneMobileInSite { get; set; }
    }
}
