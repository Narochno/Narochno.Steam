using Newtonsoft.Json;

namespace Narochno.Steam.Entities.Responses
{
    public class GetNewsResponse
    {
        [JsonProperty("appnews")]
        public AppNews AppNews { get; set; }
    }
}
