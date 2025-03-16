namespace ViewModels.QueriesResponseViewModel.Address
{
    public class AddressViewModel
    {
        public double Lat { get; set; }
        public double Long { get; set; }

        public int StateId { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public string CityRoute { get; set; } = null!;

        public string PostalAddress { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string OtherAddress { get; set; } = null!;

        public string Neighbourhood { get; set; } = null!;
    }
}
