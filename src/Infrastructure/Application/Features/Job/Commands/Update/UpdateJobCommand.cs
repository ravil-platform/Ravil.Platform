using Domain.Entities.Job;
using Microsoft.Extensions.Hosting;
using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Job;

namespace Application.Features.Job.Commands.Update
{
    public class UpdateJobCommand : IRequest<JobViewModel>
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
