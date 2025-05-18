namespace ViewModels.QueriesResponseViewModel.PanelTutorial;

public class PanelTutorialViewModel
{
    public int Id { get; set; }
    public int Sort { get; set; }
    public string Title { get; set; } = null!;
    public string CoverName { get; set; } = null!;
    public string VideoName { get; set; } = null!;
    public string Time { get; set; } = null!;
}