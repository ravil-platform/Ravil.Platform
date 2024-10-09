namespace Domain.Entities.PaymentPortal
{
    public class PaymentPortal
    {
        #region (Fields)
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool Status { get; set; }

        public string Picture { get; set; } = null!;
        #endregion
    }
}
