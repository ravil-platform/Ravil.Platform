namespace Domain.Entities.Location
{
    public class Location : BaseEntity
    {
        #region (Fields)
        public new string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 9);

        public string Route { get; set; } = null!;

        public double Lat { get; set; }

        public double Long { get; set; }

        public PlaceType PlaceType { get; set; }
        #endregion

        #region (Relations)
        public string? AddressId { get; set; } 
        public virtual  Address.Address? Address { get; set; }
        #endregion
    }
}