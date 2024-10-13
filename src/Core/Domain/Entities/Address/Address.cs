namespace Domain.Entities.Address
{
    public class Address : BaseEntity
    {
        #region ( Fields )
        public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 5);

        public string PostalAddress { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string OtherAddress { get; set; } = null!;

        public string Neighbourhood { get; set; } = null!;

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        #endregion

        #region ( Relations )
        public int StateId { get; set; }
        public virtual StateBase State { get; set; }

        public int CityId { get; set; }
        public virtual CityBase City { get; set; }


        public string JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }


        public string LocationId { get; set; }
        public virtual Location.Location Location { get; set; }
        #endregion
    }
}
