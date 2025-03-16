namespace ViewModels.QueriesResponseViewModel.City
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Subtitle { get; set; } 

        public string Name { get; set; }
        
        public string Route { get; set; } 

        public string Picture { get; set; } 

        public bool Status { get; set; }

        public bool IsResizePicture { get; set; }

        public int CityBaseId { get; set; }
    }
}
