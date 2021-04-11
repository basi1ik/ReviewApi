using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Parser2Gis.Models
{
    public class Data
    {
        [JsonProperty("review")]
        public JObject Review { get; set; }
        
        [JsonProperty("data")]
        public JRaw DataRaw { get; set; }
    }
}
