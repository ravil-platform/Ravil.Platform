namespace ViewModels.QueriesResponseViewModel.DayOfWeek
{
    public class DayOfWeekViewModel
    {
        public int Id { get; set; }

        public string? AlternateName { get; set; }

        public string PersianName { get; set; } = null!;

        public byte Sort { get; set; }

        public bool IsSelectedPersianName { get; set; } 
    }
}
