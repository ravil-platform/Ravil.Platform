namespace Domain.Entities.Payment;

public class PromotionCode : Entity
{
    #region (Fields)
    public string Title { get; set; } = null!;
    public string Code { get; set; }

    public PromoCodeType Type { get; set; }

    public double Amount { get; set; }
    public double? CartMinimum { get; set; }
    public double? CartMaximum { get; set; }
    public short? UseCountLimit { get; set; }

    public bool IsUseLimit { get; set; } = false;
    public bool IsActiveForDiscounts { get; set; } = true;
    public bool Status { get; set; }

    public DateTime ExpireDate { get; set; } = DateTime.Now;
    #endregion

    #region ( Relation )
    public virtual ICollection<Payment> Payments { get; set; }
    #endregion
}