namespace ViewModels.AdminPanel.Filter;

public class WalletFilterViewModel : Paging<Domain.Entities.Wallets.Wallet>
{
    public string? ApplicationUserId { get; set; }

    public double? InventoryFrom { get; set; }
    public double? InventoryTo { get; set; }

    public bool FindAll { get; set; }
}