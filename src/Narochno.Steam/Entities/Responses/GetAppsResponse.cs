using Newtonsoft.Json;

namespace Narochno.Steam.Entities.Responses
{
    public class GetAppsResponse
    {
        [JsonProperty("applist")]
        public AppList AppList { get; set; }
    }
}
