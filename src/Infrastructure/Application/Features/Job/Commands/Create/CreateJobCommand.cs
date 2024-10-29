namespace Application.Features.Job.Commands.Create
{
    public class CreateJobCommand : IRequest<JobViewModel>
    {
        public string Route { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public IFormFile LargePictureFile { get; set; }

        public IFormFile SmallPictureFile { get; set; }

        public string Email { get; set; }

        public string WebSiteName { get; set; }

        #region Contact Informations
        public List<SocialMediaInfosViewModel> SocialMediaInfos { get; set; }

        public List<PhoneNumberInfosViewModel> PhoneNumberInfos { get; set; }

        #region Additional Info
        public bool? ShowPhoneTelInSite { get; set; }

        public bool? ShowFirstPhoneMobileInSite { get; set; }
        #endregion
        #endregion

        public bool IsResizePicture { get; set; } = false;

        public string AdminName { get; set; }

        public string AdminId { get; set; }

        public int ViewCountTotal { get; set; }

        public int AverageRate { get; set; }

        public bool IsGoogleData { get; set; } = false;
    }
}
