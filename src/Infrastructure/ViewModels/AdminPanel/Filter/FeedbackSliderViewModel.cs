namespace ViewModels.AdminPanel.Filter;

public class FeedbackSliderFilterViewModel : Paging<Domain.Entities.FeedbackSlider.FeedbackSlider>
{
    public int? CategoryId { get; set; }

    public string? UserName { get; set; } 
    public string? Description { get; set; } 

    public bool FindAll { get; set; }
}