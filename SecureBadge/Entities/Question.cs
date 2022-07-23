using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureBadge.Entities
{
    public class Question
    {
        public int QuestionID { get; set; }
        public int AssessmentID { get; set; }
        public string Text { get; set; }

    }
}
