using Domain.Entities.Order;

namespace ViewModels.AdminPanel.Filter
{
    public class PromotionCodeFilterViewModel : Paging<PromotionCode>
    {
        public string? Title { get; set; }
        public string? Code { get; set; }

        public bool FindAll { get; set; }
    }
}
