using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureBadge.Entities.Models
{
    public class QuestionModel
    {
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public List<Choice> Choices { get; set; }
    }
}
