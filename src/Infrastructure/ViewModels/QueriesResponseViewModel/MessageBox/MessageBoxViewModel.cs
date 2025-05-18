namespace ViewModels.QueriesResponseViewModel.MessageBox;

public class MessageBoxViewModel
{
    public string Description { get; set; } = null!;
    public string Type { get; set; }
    public bool IsRead { get; set; }
    public int JobId { get; set; }
}
