namespace Domain.Entities.Location
{
    public class Location : BaseEntity<Guid>
    {
        #region (Fields)
        public string Route { get; set; } = null!;

        public double Lat { get; set; }

        public double Long { get; set; }

        public PlaceType PlaceType { get; set; }
        #endregion

        #region (Relations)
        public string AddressId { get; set; }
        public virtual Address.Address Address { get; set; }
        #endregion
    }
}