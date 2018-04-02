using Newtonsoft.Json;

namespace Narochno.Steam.Entities
{
    public class ReviewQuerySummary
    {
        [JsonProperty("num_reviews")]
        public uint NumReviews { get; set; }
        [JsonProperty("review_score")]
        public uint ReviewScore { get; set; }
        [JsonProperty("review_score_desc")]
        public string ReviewScoreDescription { get; set; }
        [JsonProperty("total_positive")]
        public uint TotalPositive { get; set; }
        [JsonProperty("total_negative")]
        public uint TotalNegative { get; set; }
        [JsonProperty("total_reviews")]
        public uint TotalReviews { get; set; }
    }
}
