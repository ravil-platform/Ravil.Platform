﻿using System.Text.Json.Serialization;

namespace ViewModels.AdminPanel.Job
{
    public class JobsGoogleViewModel
    {
        public string Latitude { get; set; } 
        public string Longitude { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("reviewCount")]
        public string ReviewCount { get; set; }
        public string Rating { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
        public string BusinessDescription { get; set; }

        [JsonPropertyName("mobilenumber")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("instagramprofile")]
        public string InstagramProfile { get; set; }
    }

    public class JobsGoogleExcelViewModel
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("reviewCount")]
        public string ReviewCount { get; set; }
        public string Rating { get; set; }

        public string Address { get; set; }
        public string BusinessDescription { get; set; }

        [JsonPropertyName("Mobile Number")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("Instagram Profile")]
        public string InstagramProfile { get; set; }
    }
}
