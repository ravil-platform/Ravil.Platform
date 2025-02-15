using System.Text.Json.Serialization;

namespace ViewModels.AdminPanel.Job
{
    public class LocationDataViewModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("neighbourhood")]
        public string Neighbourhood { get; set; }

        [JsonPropertyName("municipality_zone")]
        public string MunicipalityZone { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("in_traffic_zone")]
        public bool InTrafficZone { get; set; }

        [JsonPropertyName("in_odd_even_zone")]
        public bool InOddEvenZone { get; set; }

        [JsonPropertyName("route_name")]
        public string RouteName { get; set; }

        [JsonPropertyName("route_type")]
        public string RouteType { get; set; }

        [JsonPropertyName("place")]
        public object Place { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; }

        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonPropertyName("village")]
        public object Village { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }
    }
}
