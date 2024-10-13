namespace Domain.Entities.Order;

public class PromotionCode : Entity
{
    #region (Fields)
    public string Title { get; set; } = null!;

    public string Code { get; set; }

    public DateTime ExpireDate { get; set; } = DateTime.Now;

    public double Amount { get; set; }

    public PromoCodeType Type { get; set; }

    public double? CartMinimum { get; set; }

    public double? CartMaximum { get; set; }

    public short? UseCountLimit { get; set; }

    public bool IsUseLimit { get; set; } = false;

    public bool IsActiveForDiscounts { get; set; } = true;

    public bool Status { get; set; }
    #endregion

    #region (Relation)
    public virtual ICollection<Order> Orders { get; set; }
    #endregion
}