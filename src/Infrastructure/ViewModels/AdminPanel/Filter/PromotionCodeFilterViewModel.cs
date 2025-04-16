using Domain.Entities.Payment;
using Domain.Entities.Subscription;

namespace ViewModels.AdminPanel.Filter
{
    public class PromotionCodeFilterViewModel : Paging<PromotionCode>
    {
        public string? Title { get; set; }
        public string? Code { get; set; }

        public bool FindAll { get; set; }
    } 
}
