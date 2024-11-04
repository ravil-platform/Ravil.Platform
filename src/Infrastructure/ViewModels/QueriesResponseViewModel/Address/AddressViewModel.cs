namespace ViewModels.QueriesResponseViewModel.Address
{
    public class AddressViewModel
    {
        public int StateId { get; set; }
        public int CityId { get; set; }

        public string PostalAddress { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string OtherAddress { get; set; } = null!;

        public string Neighbourhood { get; set; } = null!;
    }
}
