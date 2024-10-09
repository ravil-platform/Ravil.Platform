namespace Domain.Entities.State;

public class State : BaseMetaDataEntity
{
    #region (Fields)
    public string Subtitle { get; set; }

    public string Picture { get; set; }

    public bool IsResizePicture { get; set; } = false;

    public double Multiplier { get; set; }
    #endregion

    #region (Relations)
    public int StateBaseId { get; set; }
    public virtual StateBase StateBase { get; set; }

    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    #endregion
}

