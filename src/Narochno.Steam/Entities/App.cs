using Newtonsoft.Json;

namespace Narochno.Steam.Entities
{
    public class App
    {
        [JsonProperty("appid")]
        public uint AppId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
