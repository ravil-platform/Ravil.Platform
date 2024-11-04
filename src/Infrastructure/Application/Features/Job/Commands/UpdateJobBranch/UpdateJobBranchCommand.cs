namespace Application.Features.Job.Commands.UpdateJobBranch
{
    public class UpdateJobBranchCommand : IRequest<UpdateJobBranchViewModel>
    {
        public string JobBranchId { get; set; }

        public CreateJobBranchViewModel CreateJobBranchViewModel { get; set; }


        public int[]? Tags { get; set; }
        public int[]? Services { get; set; }
        public int[]? Categories { get; set; }

        public List<JobTimeWorkViewModel>? JobTimeWork { get; set; } = null;
    }
}