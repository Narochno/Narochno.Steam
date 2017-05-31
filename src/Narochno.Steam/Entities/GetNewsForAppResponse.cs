using Newtonsoft.Json;

namespace Narochno.Steam.Entities
{
    public class GetNewsForAppResponse
    {
        [JsonProperty("appnews")]
        public AppNews AppNews { get; set; }
    }
}
