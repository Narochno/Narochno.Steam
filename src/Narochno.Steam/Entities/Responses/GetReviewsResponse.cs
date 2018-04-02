using Newtonsoft.Json;
using System.Collections.Generic;

namespace Narochno.Steam.Entities.Responses
{
    public class GetReviewsResponse
    {
        [JsonProperty("query_summary")]
        public ReviewQuerySummary QuerySummary { get; set; }
        [JsonProperty("reviews")]
        public IList<Review> Reviews { get; set; }
    }
}
