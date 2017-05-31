using Newtonsoft.Json;
using System.Collections.Generic;

namespace Narochno.Steam.Entities
{
    public class AppList
    {
        [JsonProperty("apps")]
        public IList<App> Apps { get; set; } = new List<App>();
    }
}
