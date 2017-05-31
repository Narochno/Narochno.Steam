using Newtonsoft.Json;

namespace Narochno.Steam.Entities
{
    public class GetAppListResponse
    {
        [JsonProperty("applist")]
        public AppList AppList { get; set; }
    }
}
