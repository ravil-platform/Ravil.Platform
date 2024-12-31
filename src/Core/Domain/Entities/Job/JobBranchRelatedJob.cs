namespace Domain.Entities.Job;

public class JobBranchRelatedJob : BaseEntity
{
    #region ( Properties )
    public int Id { get; set; }

    public int CurrentCityId { get; set; }
    public string CurrentCityName { get; set; }


    public int DisplayedCityId { get; set; }
    public string DisplayedCityName { get; set; }

    public int Sort { get; set; }
    #endregion
}