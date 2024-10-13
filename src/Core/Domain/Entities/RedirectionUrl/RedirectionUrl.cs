namespace Domain.Entities.RedirectionUrl;

public class RedirectionUrl : BaseEntity
{
    #region (Fields)
    public int Id { get; set; }

    public bool Status { get; set; }

    public RedirectionTypes RedirectionType { get; set; }

    public string LatestUrl { get; set; } = null!;

    public string DestinationUrl { get; set; } = null!;
    #endregion
}

