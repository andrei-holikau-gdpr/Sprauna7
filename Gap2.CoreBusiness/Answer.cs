using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap2.CoreBusiness
{
    public class Answer : SimpleEntity
    {
        public string NotionId { get; set; }

        #region DigitalEquivalent

        public bool ResultBool { get; set; }
        public float YesDigitalEquivalent { get; set; }
        public float NoDigitalEquivalent { get; set; }

        //public float ProbabilityDigitalEquivalent { get; set; }
        #endregion

        public int QuestionId { get; set; }
        public int JurisdictionId { get; set; }

        public Question Question { get; set; }
        public Jurisdiction Jurisdiction { get; set; }
    }
}
