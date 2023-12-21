using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lixiang.CoreBusiness
{
    public class OptionalEquipment : SimpleOption
    {
        public List<ImageHtmlTag> Images { get; set; } = new();
    }
}
