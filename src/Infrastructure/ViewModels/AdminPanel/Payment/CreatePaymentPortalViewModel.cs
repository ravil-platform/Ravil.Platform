namespace ViewModels.AdminPanel.Payment;

public class CreatePaymentPortalViewModel
{
    public string Title { get; set; } = null!;
    public IFormFile? PictureName { get; set; } 

    public bool IsActive { get; set; }
}