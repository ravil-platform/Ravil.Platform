namespace ViewModels.QueriesResponseViewModel.Location
{
    public class LocationViewModel
    {
    
        public string Route { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public PlaceType PlaceType { get; set; }

        public string? AddressId { get; set; }
    }
}
