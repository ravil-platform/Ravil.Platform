using Domain.Entities.State;

namespace ViewModels.AdminPanel.Filter
{
    public class StateBaseFilterViewModel : Paging<Domain.Entities.State.StateBase>
    {
        public string? Name { get; set; }

        public bool FindAll { get; set; }
    }
}
