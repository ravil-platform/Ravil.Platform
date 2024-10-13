namespace Domain.Entities.User;

public class UserAddress : Entity
{
    #region (Fields)
    public string ReceiverName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string PostalAddress { get; set; } = null!;

    public string PostalCode { get; set; } = null!;
    #endregion

    #region (Relations)
    public string UserId { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }

    public int StateBaseId { get; set; }
    public virtual StateBase StateBase { get; set; }

    public int CityBaseId { get; set; }
    public virtual CityBase CityBase { get; set; }
    #endregion
}

