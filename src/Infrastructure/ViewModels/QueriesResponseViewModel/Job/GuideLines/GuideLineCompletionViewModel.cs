namespace ViewModels.QueriesResponseViewModel.Job.GuideLines
{
    public class GuideLineCompletionViewModel
    {
        public JobBranchViewModel? Business { get; set; }

        /// <summary>
        /// تعداد کل گام ها
        /// </summary>
        public int TotalStepCount { get; set; } = 9;

        /// <summary>
        /// تعداد گامهای تکمیل شده
        /// </summary>
        public int CompletedStepCount { get; set; }

        public bool IsCompletedTitle { get; set; } // Comparison Fields: Title
        public bool IsCompletedAddress { get; set; } // Comparison Fields: CityId, StateId, Lat, Long, FullAddress
        public bool IsCompletedSummary { get; set; } // Comparison Fields: Summary
        public bool IsCompletedDescription { get; set; } // Comparison Fields: Description
        public bool IsCompletedGalleryAndImages { get; set; } // Comparison Fields: SmallPictureFile && Gallery && (BranchVideo || LargePictureFile)
        public bool IsCompletedKeywords { get; set; } // Comparison Fields: Keywords List Object
        public bool IsCompletedTimeWorks { get; set; } // Comparison Fields: TimeWorks List Object
        public bool IsCompletedSocialMediaInfos { get; set; } // Comparison Fields: SocialMediaInfos List Object
        public bool IsCompletedPhoneNumberInfos { get; set; } // Comparison Fields: PhoneNumberInfos List Object
    }
}
