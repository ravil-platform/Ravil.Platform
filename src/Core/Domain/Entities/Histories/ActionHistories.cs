﻿namespace Domain.Entities.Histories
{
    public class ActionHistories : IEntity
    {
        #region ( Fields )
        /// <summary>
        /// شناسه اصلی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// شناسه کاربر
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// نام و نام خانوادگی کاربر
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// نام دسته بندی مثلا  : رستوران
        /// </summary>
        public string CategoryName { get; set; } = null!;
        public int CategoryId { get; set; }

        /// <summary>
        /// آدرس آی پی
        /// </summary>
        public string AddressIp { get; set; } = null!;

        /// <summary>
        /// آدرس مثلا : کرج
        /// </summary>
        public string Location { get; set; } = null!;
        public string PageTitle { get; set; } = null!;
        public string PageSlug { get; set; } = null!;
        public string PageUrl { get; set; } = null!;
        
        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public bool? JobIsActiveAds { get; set; }
        
        /// <summary>
        /// نوع عملیات کاربر مثلا : لایک کردن
        /// </summary>
        public string ActionType { get; set; }


        /// <summary>
        /// تاریخ ثبت عملیات
        /// </summary>
        public DateTime Time { get; set; }
        #endregion
    }
}
