namespace ViewModels.AdminPanel.Filter;

public class PanelTutorialFilterViewModel : Paging<Domain.Entities.PanelTutorial.PanelTutorial>
{
    public string? Title { get; set; }

    public bool FindAll { get; set; }
}