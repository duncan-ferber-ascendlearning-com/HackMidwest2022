using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureBadge.Entities.Models
{
    public class AssessmentModel
    {
        public int AssessmentiD { get; set; }
        public string Title { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}
