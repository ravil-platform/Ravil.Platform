namespace ViewModels.AdminPanel.Filter;

public class KeywordFilterViewModel : Paging<Keyword>
{
    public string? Title { get; set; }
    public string? Slug { get; set; }
    public int? CategoryId { get; set; }
    
    public bool? IsActive { get; set; }


    public bool FindAll { get; set; }
}