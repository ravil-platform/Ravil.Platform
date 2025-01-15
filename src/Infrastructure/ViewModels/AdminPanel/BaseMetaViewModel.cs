namespace ViewModels.AdminPanel
{
    public class BaseMetaViewModel
    {
        #region MetaData Seo

        [Display(Name = "متا ایندکس سئو؟")]
        public bool IndexMeta { get; set; }

        [Display(Name = "متا کنونیکال؟")]
        public bool CanonicalMeta { get; set; }

        [Display(Name = "لینک کنونیکال")]
        public string? MetaCanonicalUrl { get; set; }

        [Display(Name = "توضیحات متا")]
        [StringLength(256, MinimumLength = 50, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
        public string? MetaDesc { get; set; }

        [Display(Name = "عنوان متا")]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
        public string? MetaTitle { get; set; }

        #endregion
    }
}
