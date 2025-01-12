using Domain.Entities.ContactUs;

namespace ViewModels.AdminPanel.Filter;

public class ContactFormFilterAdminViewModel : Paging<ContactUs>
{
    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Description { get; set; }

    public bool? IsRead { get; set; }

    public bool FindAll { get; set; }
}