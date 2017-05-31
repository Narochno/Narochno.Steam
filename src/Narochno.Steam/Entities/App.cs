using Newtonsoft.Json;

namespace Narochno.Steam.Entities
{
    public class App
    {
        [JsonProperty("appid")]
        public int AppId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
