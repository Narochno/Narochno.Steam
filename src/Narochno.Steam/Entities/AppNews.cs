using Newtonsoft.Json;
using System.Collections.Generic;

namespace Narochno.Steam.Entities
{
    public class AppNews
    {
        [JsonProperty("appid")]
        public int AppId { get; set; }
        [JsonProperty("newsitems")]
        public IList<NewsItem> NewsItems { get; set; }
    }
}
