using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.CoreBusiness;

public class SubProcess
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProcessToConsiderId { get; set; }


    public ProcessToConsider ProcessToConsider { get; set; }
}
