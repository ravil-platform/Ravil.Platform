namespace ViewModels.QueriesResponseViewModel.User
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? LockoutReason { get; set; }

        public string? NationalCode { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Avatar { get; set; }

        public bool UserIsBlocked { get; set; }

        public int ExpireTimeSpanBlock { get; set; }

        public bool IsDeleted { get; set; }

        public string? LastUpdateDateReason { get; set; }

        public DateTime BlockedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime LastDeleteBicycleDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public DateTime? ConfirmationDate { get; set; }

        public UserNameType UserNameType { get; set; } = UserNameType.PhoneNumber;

        public GenderPerson Gender { get; set; }
    }
}