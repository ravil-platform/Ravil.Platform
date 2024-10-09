namespace Domain.Entities.City;
public class City : BaseMetaDataEntity
{
    #region (Fields)
    public string Subtitle { get; set; } = null!;

    public string Route { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public bool Status { get; set; } = true;

    public bool IsResizePicture { get; set; } = false;
    #endregion

    #region (Relations)
    public int CityBaseId { get; set; }
    public virtual CityBase CityBase { get; set; }

    public virtual ICollection<CityCategory> CityCategories { get; set; }
    #endregion
}

