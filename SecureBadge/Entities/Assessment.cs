using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureBadge.Entities
{
    public class Assessment
    {
        public int AssessmentID { get; set; }
        public string Title { get; set; }
        public string BadgeTemplate { get; set; }
    }
}
