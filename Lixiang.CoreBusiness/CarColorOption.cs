using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lixiang.CoreBusiness;

public class CarColorOption: SimpleOption
{
    public int CarColorOptionId { get; set; }
    public List<ImageHtmlTag> Images { get; set; } = new();
}
