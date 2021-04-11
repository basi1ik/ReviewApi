using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Parser2Gis.Models
{
    class Request
    {
        [JsonProperty("data")]
        public JRaw Data { get; set; }
    }
}
