namespace Domain.Entities.State;

public class StateBase
{
    #region (Fields)
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Multiplier { get; set; }
    #endregion

    #region (Relations)
    public virtual State State { get; set; }
    public virtual ICollection<MainSlider.MainSlider> MainSliders { get; set; }
    public virtual ICollection<Address.Address> Addresses { get; set; }
    public virtual ICollection<UserAddress> UserAddresses { get; set; }
    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    #endregion
}

