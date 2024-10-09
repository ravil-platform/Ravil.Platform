namespace Domain.Entities.ContactUs
{
    public class ContactUs : BaseEntity
    {
        #region (Fields)
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public string Message { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? UserId { get; set; }

        public string? UserIp { get; set; }

        public bool StatusAnswer { get; set; }

        public bool IsReadByAdmin { get; set; }

        public DateTime? AnswerDate { get; set; }

        public string? AdminName { get; set; }

        public string? AdminId { get; set; }

        public string? Answer { get; set; }
        #endregion
    }
}