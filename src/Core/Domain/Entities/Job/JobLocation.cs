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
        [Required]
        public string LocationId { get; set; }
        public virtual Location.Location Location { get; set; }


        [Required]
        public string JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }


        [Required]
        public string AddressId { get; set; }
        public virtual Address.Address Address { get; set; }


        [Required]
        public string JobId { get; set; }
        #endregion
    }
}