using ViewModels.QueriesResponseViewModel.MessageBox;

namespace Application.Features.MessageBox.Queries.GetAllMessageBoxByFilter;

public class GetAllMessageBoxByFilterQuery : IRequest<List<MessageBoxViewModel>>
{
    public int JobId { get; set; }
    public bool UnReadMessages { get; set; } = false;
}