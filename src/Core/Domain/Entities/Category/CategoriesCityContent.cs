namespace Domain.Entities.Category
{
    public class CategoriesCityContent : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// دسته بندی مورد نظر 
        /// </summary>
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;


        /// <summary>
        /// نام شهر - محتوا در کدام شهر تغییر میکند؟
        /// </summary>
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;

        /// <summary>
        /// محتوای صفحه چی بشه؟
        /// </summary>
        public string Content { get; set; } = null!;
    }
}
