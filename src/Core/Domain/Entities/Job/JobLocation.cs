namespace Domain.Entities.Job
{
    [NotMapped]
    public class JobLocation
    {
        #region (Fields)
        [Key]
        public int Id { get; set; }
        #endregion

        #region (Relations)
        public string LocationId { get; set; } = null!;
        public virtual required Location.Location Location { get; set; }

        public string JobBranchId { get; set; } = null!;
        public virtual required JobBranch JobBranch { get; set; }

        public string AddressId { get; set; } = null!;
        public virtual required Address.Address Address { get; set; }

        public string JobId { get; set; } = null!;
        #endregion
    }
}