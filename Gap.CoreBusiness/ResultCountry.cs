using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.CoreBusiness;

public class ResultCountry
{
    public int Id { get; set; }
    public Country? Country { get; set; }
    public string? Description { get; set; }
    public StatusGapEnum StatusGap { get; set; }
}
