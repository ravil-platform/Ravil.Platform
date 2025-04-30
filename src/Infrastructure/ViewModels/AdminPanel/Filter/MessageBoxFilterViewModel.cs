using Domain.Entities.MessageBox;

namespace ViewModels.AdminPanel.Filter;

public class MessageBoxFilterViewModel : Paging<Domain.Entities.MessageBox.MessageBox>
{
    public bool? IsRead { get; set; }
    public MessageBoxType? Type { get; set; }


    public int? JobId { get; set; }


    public DateTime? From { get; set; }
    public DateTime? To { get; set; }

    public bool FindAll { get; set; }
}