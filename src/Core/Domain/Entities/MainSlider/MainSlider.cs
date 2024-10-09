namespace Domain.Entities.MainSlider
{
    public class MainSlider : BaseEntity
    {
        #region (Fields)
        public string Title { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.Now;

        public int? ExpireDay { get; set; }

        public string LargePicture { get; set; } = null!;

        public string SmallPicture { get; set; } = null!;

        public string LinkPage { get; set; } = null!;

        public byte Sort { get; set; }
        #endregion

        #region (Relations)
        public string JobBranchId { get; set; } = null!;
        public virtual JobBranch JobBranch { get; set; }

        public int StateId { get; set; }
        public virtual StateBase State { get; set; }

        public int CityId { get; set; }
        public virtual CityBase City { get; set; }
        #endregion
    }
}