using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lixiang.CoreBusiness
{
    public class SimpleOption
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Name";
        public string Description { get; set; } = "";
        public ImageHtmlTag? Thumbnail { get; set; }
        public double Price { get; set; } = 0;
    }
}
