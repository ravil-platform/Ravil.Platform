namespace Domain.Entities.ShortLink;

public class ShortLink : BaseEntity
{
    #region (Fields)
    public int Id { get; set; }

    public string ShortKey { get; set; }
 
    public ShortLinkType Type { get; set; }
  
    public int ItemId { get; set; }
    #endregion
}

