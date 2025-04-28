namespace ViewModels.AdminPanel.Payment;

public class UpdatePaymentPortalViewModel 
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public IFormFile? PictureName { get; set; }
    public string? CurrentPictureName { get; set; }

    public bool IsActive { get; set; }
}