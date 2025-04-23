namespace Application.Features.Job.Commands.CreateFreeJobBranch
{
    public class CreateFreeJobBranchCommand : IRequest<JobBranchViewModel>
    {
        public CreateJobViewModel Job { get; set; }
        public CreateJobBranchViewModel JobBranch { get; set; }

        public int[]? Tags { get; set; }
        public int[]? Services { get; set; }
        public int[] Categories { get; set; }

        /// <summary>
        /// طول جغرافیایی
        /// </summary>
        public double Lat { get; set; } = 0.00;

        /// <summary>
        /// عرض جغرافیایی
        /// </summary>
        public double Long { get; set; } = 0.00;

        /// <summary>
        /// آدرس
        /// </summary>
        public string FullAddress { get; set; } = null!;

        /// <summary>
        /// آدرس پستی
        /// </summary>
        public string? PostalAddress { get; set; }

        /// <summary>
        /// مجله یا شهرستان
        /// </summary>
        public string? Neighbourhood { get; set; }

        /// <summary>
        /// کد پستی
        /// </summary>
        public string? PostalCode { get; set; }
        
        public int StateId { get; set; }
        public int CityId { get; set; }
        
        public string? JobTimeWork { get; set; }
    }
}
