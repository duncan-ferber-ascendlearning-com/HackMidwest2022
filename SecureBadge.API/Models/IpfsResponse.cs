using System;
using System.Collections.Generic;
using System.Text;

namespace SecureBadge.API.Models
{
    public class IpfsResponse
    {
        public string IpfsHash { get; set; }
        public int PinSize { get; set; }
        public string Timestamp { get; set; }
        public bool isDuplicate { get; set; }
    }
}
