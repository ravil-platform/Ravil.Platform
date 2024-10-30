using ViewModels.QueriesResponseViewModel.Tag;

namespace ViewModels.QueriesResponseViewModel.Job;

public class JobTagViewModel
{
    public int Id { get; set; }

    public int JobId { get; set; }


    public int TagId { get; set; }
    public TagViewModel Tag { get; set; }
}