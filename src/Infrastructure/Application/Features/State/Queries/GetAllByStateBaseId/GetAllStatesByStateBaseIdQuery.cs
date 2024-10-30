using ViewModels.QueriesResponseViewModel.State;

namespace Application.Features.State.Queries.GetAllByStateBaseId
{
    public class GetAllStatesByStateBaseIdQuery : IRequest<List<StateViewModel>>
    {
        public int StateBaseId { get; set; }
    }
}
