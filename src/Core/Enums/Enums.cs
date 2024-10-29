using Resources.General;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Enums
{
    public enum CategoryBusinessType
    {
        [Display(Name = nameof(PersonalBrand))]
        PersonalBrand = 0,
        [Display(Name = nameof(BrandName))]
        BrandName = 1,
    }
    public enum JobSliderType
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.LatestJobs))]
        LatestJobs,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.TopScoreJobs))]
        TopScoreJobs,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.MomentJobs))]
        MomentJobs
    }

    public enum RedirectionTypes
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.MovedPermanently301))]
        MovedPermanently301 = 301,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Found302))]
        Found302 = 302,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.TemporaryRedirect307))]
        TemporaryRedirect307 = 307,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.UnavailableForLegalReasons451))]
        UnavailableForLegalReasons451 = 451,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Gone410))]
        Gone410 = 410
    }

    public enum SocialMediaTypes
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Telegram))]
        [Description("مثال : t.me/your-telegram-id")]
        Telegram,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Instagram))]
        [Description("مثال : instagram.com/your-page-id")]
        Instagram,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Facebook))]
        [Description("مثال : facebook.com/your-page-id")]
        FaceBook,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Whatsapp))]
        [Description("مثال : wa.me/+989123456789")]
        WhatsApp,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.LinkedIn))]
        [Description("مثال : linkedin.com/company/your-page-id")]
        LinkedIn,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Aparat))]
        [Description("مثال : aparat.com/v/mOJy85488")]
        Aparat,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Twitter))]
        [Description("مثال : twitter.com/your-page-id")]
        Twitter
    }
    public enum PhoneNumberTypes
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.PhoneNumberTel))]
        [Description("مثال : 88846090")]
        PhoneNumberTel,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.CellPhoneNumber))]
        [Description("مثال : 09121234567")]
        PhoneNumberMobile,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.FaxNumber))]
        [Description("مثال : 88846090")]
        FaxNumber
    }
    public enum SendNotificationStateMode
    {
        [Display(Name = "ارسال ایمیل")]
        [Description("")]
        SendEmail,
        [Display(Name = "ارسال پیامک")]
        [Description("")]
        SendSms
    }
    public enum SearchType
    {
        Category,
        JobBranch
    }
    public enum SliderType
    {
        MainSlider,
        JobBranch,
        NewYear
    }
    public enum MessageControllerType
    {
        FormatFileDanger,
        ExceptionError,
        EditRowCount,
        DbUpdateException
    }
    public enum UploadedFileType
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Picture))]
        Picture,
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Video))]
        Video
    }
    public enum FaqPageTypes
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.ProductPage))]
        ProductPage,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.CategoryPage))]
        CategoryPage,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.HomePage))]
        HomePage,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.BlogPage))]
        BlogPage
    }
    public enum BreadCrumbTypes
    {
        Product,
        Blog,
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.ProductPage))]
        ProductPage,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.CategoryPage))]
        CategoryPage,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.HomePage))]
        HomePage,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.BlogPage))]
        BlogPage
    }
    public enum ReviewItemTypes
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.ProductPage))]
        Product,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.JobBranchPage))]
        JobBranch,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.BlogPage))]
        Blog
    }
    public enum CommentTypes
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.ProductPage))]
        Product,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.JobBranchPage))]
        JobBranch,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.BlogPage))]
        Blog
    }
    public enum ChangeModesType
    {
        ChangePrice,
        ChangeDiscount
    }

    public enum ShortLinkType
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.ProductPage))]
        Product,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.JobBranchPage))]
        JobBranch,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.BlogPage))]
        Blog
    }

    public enum TagType
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.AccountPage))]
        Account,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.JobBranchPage))]
        JobBranch,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.BlogPage))]
        Blog,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.CityPage))]
        City
    }

    public enum OrderStatus
    {
        [Display(Name = "ایجاد شده")]
        Initial,
        [Display(Name = "پرداخت")]
        PaymentDone,
        [Display(Name = "تایید و اتمام")]
        Completed,
        [Display(Name = "نامعتبر")]
        Unverified
    }

    public enum PromoCodeType
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Percent))]
        Percent,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Amount))]
        Amount
    }

    public enum GenderPerson
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Male))]
        Male,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Female))]
        Female,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Other))]
        Other
    }
    public enum UserNameType
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.CellPhoneNumber))]
        PhoneNumber,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.EmailAddress))]
        Email,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Other))]
        Other
    }
    public enum AttributeType
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Product))]
        Product,

        [Display(Name = "پلن")]
        Account,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.JobBranch))]
        JobBranch,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Category))]
        Category
    }

    public enum BannerType
    {
        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.Blog))]
        Blog,

        [Display(ResourceType = typeof(DisplayNames), Name = nameof(DisplayNames.JobBranch))]
        JobBranch,

        [Display(Name = "ویژه")]
        Special
    }

    public enum BannerPictureType
    {
        [Display(Name = "مربع")]
        Square,
        [Display(Name = "مستطیل")]
        Rectangle
    }

    public enum ExternalLoginState
    {
        [Display(Name = "از طریق کاربر")]
        WithViewPage,
        [Display(Name = "ازطریق اطلاعات گوگل")]
        WithOutViewPage
    }

    public enum JobTimeWorkType
    {
        [Display(Name = "این کسب وکار در تمام ساعات شبانه روز باز است")]
        WorkAllTime,
        [Display(Name = "از ساعات کاری این کسب وکار اطلاعی ندارم")]
        NotInformation,
        [Display(Name = "این کسب وکار فقط در ساعات خاصی باز است")]
        WorkSomeTime
    }

    public enum PlaceType
    {
        [Display(Name = "مسکونی")]
        Home,
        [Display(Name = "اداری")]
        Office,
        [Display(Name = "کشاورزی")]
        Farm,
        [Display(Name = "تجاری")]
        Business,
        [Display(Name = "سایر")]
        Other
    }

    public enum UserBookMarkType
    {
        [Display(Name = "وبلاگ", GroupName = "نوع")]
        Blog,
        [Display(Name = "کسب وکار", GroupName = "نوع")]
        JobBranch
    }
}
