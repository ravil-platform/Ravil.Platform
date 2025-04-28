namespace ViewModels.AdminPanel.Payment
{
    public class UpdatePaymentViewModel
    {
        public Guid Id { get; set; }

        public double Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
