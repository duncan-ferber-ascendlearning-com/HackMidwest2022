using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SecureBadge.API.Models
{
    public class PinnedFileList
    {
       [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("rows")]
        public List<Row> Rows { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("keyvalues")]
        public object KeyValues { get; set; }
    }

    public class Region
    {

        [JsonProperty("regionId")]
        public string RegionId { get; set; }
        [JsonProperty("currentReplicationCount")]
        public int CurrentReplicationCount { get; set; }
        [JsonProperty("desiredReplicationCount")]
        public int DesiredReplicationCount { get; set; }
    }


    public class Row
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("ipfs_pin_hash")]
        public string IpfsPinHash { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("date_pinned")]
        public DateTime DatePinned { get; set; }
        [JsonProperty("date_unpinned")]
        public object DateUnpinned { get; set; }
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
        [JsonProperty("regions")]
        public List<Region> Regions { get; set; }
    }
}
