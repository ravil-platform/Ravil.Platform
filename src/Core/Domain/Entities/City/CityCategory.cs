namespace Domain.Entities.City
{
    public class CityCategory : Entity
    {
        #region (Relations)
        [Required]
        public int CategoryId { get; set; }
        public virtual Category.Category Category { get; set; }


        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        #endregion
    }
}