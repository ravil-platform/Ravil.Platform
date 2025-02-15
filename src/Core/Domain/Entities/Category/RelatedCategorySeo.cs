namespace Domain.Entities.Category;

public class RelatedCategorySeo : BaseEntity
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// -عنوان چی باشه ؟ مثلا : -رستوران- در فلکه اول -فردیس
    /// DisplayedCityName - در فلکه اول - CategoryName
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// لینک باشه یا نه
    /// </summary>
    public bool Link { get; set; }

    
    public int CurrentCityId { get; set; }
    public string CurrentCityName { get; set; }
    

    public string DisplayedCityName { get; set; }

    public int Sort { get; set; }
}