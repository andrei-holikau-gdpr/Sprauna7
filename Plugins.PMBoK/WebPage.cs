using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.PMBoK
{
    public class WebPage
    {
        public int WebPageId { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Link { get; set; } = "";


        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
