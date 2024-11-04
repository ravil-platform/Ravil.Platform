namespace Application.Features.Job.Commands.UpdateJobBranchLocation
{
    public class UpdateJobBranchLocationCommand : IRequest<UpdateJobBranchLocationViewModel>
    {
        public string JobBranchId { get; set; }
        public LocationViewModel LocationViewModel { get; set; }
        public AddressViewModel AddressViewModel { get; set; }
    }
}
