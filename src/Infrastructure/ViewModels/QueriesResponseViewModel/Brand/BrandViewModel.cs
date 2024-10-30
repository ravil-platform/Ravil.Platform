namespace Domain.Entities.Brand
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string AlternateTitle { get; set; }

        public string Introduction { get; set; }

        public string SearchLink { get; set; }

        public string Picture { get; set; }

        public bool Status { get; set; }
    }
}
