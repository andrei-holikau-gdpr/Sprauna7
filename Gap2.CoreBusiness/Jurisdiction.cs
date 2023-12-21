using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap2.CoreBusiness
{
    public class Jurisdiction : SimpleEntity
    {
        public List<Question> Questions { get; set; }    
        public bool Selected { get; set; }
        public StatusAppliacability? StatusAppliacability { get; set; }
    }
}
