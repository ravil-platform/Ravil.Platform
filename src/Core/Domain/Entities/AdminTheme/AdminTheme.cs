namespace Domain.Entities.AdminTheme
{
    public class AdminTheme : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Theme { get; set; }
        #endregion
    }
}
