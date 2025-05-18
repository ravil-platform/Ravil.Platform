namespace Domain.Entities.Subscription;

public class ClickAdsSetting : BaseEntity
{
    public int Id { get; set; }
    public bool Status { get; set; }
    public int AdDisplayRange { get; set; }
    public decimal MaxCostPerClick { get; set; }

    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}