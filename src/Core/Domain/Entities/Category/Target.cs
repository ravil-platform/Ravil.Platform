namespace Domain.Entities.Category;

public class Target : BaseEntity
{
    public int Id { get; set; }

    /// <summary>
    /// میخواهیم به این مقصد لینک بخورد
    /// </summary>
    public int DestinationCategoryId { get; set; }
    public string DestinationCategoryName { get; set; }

    /// <summary>
    /// مبدا
    /// </summary>
    public int OriginCategoryId { get; set; }
    public string OriginCategoryName { get; set; }
}