namespace ViewModels.Filter.User
{
    public class UsersFilterViewModel : Paging<ApplicationUser>
    {
        #region (Fields)
        public string? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? NationalCode { get; set; }
        public string? Phone { get; set; }
        public string? UserName { get; set; }
        public bool? Active { get; set; }
        public DateTime? RegisterDateFrom { get; set; }
        public DateTime? RegisterDateTo { get; set; }
        public bool FindAll { get; set; }
        #endregion
    }
}
