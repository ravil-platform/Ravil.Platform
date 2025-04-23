using System.Text.Json.Serialization;

namespace ViewModels.QueriesResponseViewModel.Job
{
    public class JobTimeWorkViewModel
    {
        [JsonPropertyName("timeWorkId")]
        public int TimeWorkId { get; set; }

        [JsonPropertyName("jobBranchId")]
        public string? JobBranchId { get; set; }

        [JsonPropertyName("dayOfWeekId")]
        public int DayOfWeekId { get; set; }

        [JsonPropertyName("startTime")]
        public string StartTime { get; set; } = null!;

        [JsonPropertyName("endTime")]
        public string EndTime { get; set; } = null!;
    }
}
