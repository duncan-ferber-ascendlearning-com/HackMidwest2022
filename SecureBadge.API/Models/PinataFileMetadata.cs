using Newtonsoft.Json;

namespace SecureBadge.API.Models
{
    public class PinataFileMetadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("keyvalues")]
        public KeyValues KeyValues { get; set; }
    }

    public class KeyValues
    {
        [JsonProperty("company")]
        public string Company { get; set; }
    }

}
