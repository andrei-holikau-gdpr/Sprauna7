using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap2.CoreBusiness
{
    public class Question : SimpleEntity
    {
        public string NotionId { get; set; }

        public int QuestionTypeId { get; set; }

        public QuestionType QuestionType { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Jurisdiction> Jurisdictions { get; set; }
    }
}
