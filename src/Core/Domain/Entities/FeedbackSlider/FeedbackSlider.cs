namespace Domain.Entities.FeedbackSlider
{
    public class FeedbackSlider
    {
        #region (Fields)
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public string UserName { get; set; } = null!;

        public string UserRole { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte Sort { get; set; }

        public string Picture { get; set; } = null!;
        #endregion
    }
}
