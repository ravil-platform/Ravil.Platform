namespace Domain.Entities.Location
{
    public class Location : BaseEntity
    {
        #region (Fields)
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 9);

        public string Route { get; set; } = null!;

        public double Lat { get; set; }

        public double Long { get; set; }

        public PlaceType PlaceType { get; set; }
        #endregion

        #region (Relations)
        public string AddressId { get; set; } = null!;
        public virtual required Address.Address Address { get; set; }
        #endregion
    }
}