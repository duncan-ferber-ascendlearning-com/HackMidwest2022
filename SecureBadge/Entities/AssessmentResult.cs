using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecureBadge.Entities
{
    public class AssessmentResult
    {
        [Key]
        public int ID { get; set; }
        public int AssessmentID { get; set; }
        public string UserID { get; set; }
        public bool CertificateEarned { get; set; }
    }
}
