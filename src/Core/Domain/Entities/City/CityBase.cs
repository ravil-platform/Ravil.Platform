namespace Domain.Entities.City
{
    public class CityBase : Entity
    {
        #region (Fields)
        public int CountyId { get; set; }

        public string Name { get; set; } = null!;
        #endregion

        #region (Relations)
        public int StateId { get; set; }
        public virtual StateBase StateBase { get; set; }


        public virtual City City { get; set; }


        public virtual ICollection<Address.Address> Addresses { get; set; }
        public virtual ICollection<MainSlider.MainSlider> MainSliders { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        #endregion
    }
}
