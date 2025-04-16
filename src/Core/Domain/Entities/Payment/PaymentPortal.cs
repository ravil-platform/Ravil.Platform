namespace Domain.Entities.Payment
{
    public class PaymentPortal : BaseEntity
    {
        #region ( Properties )
        public int Id { get; set; }
        public string Title { get; set; }
        public string PictureName { get; set; }

        public bool IsActive { get; set; }
        #endregion

        #region ( Relations )
        public virtual IList<Payment> Payments { get; set; }
        #endregion
    }
}
