using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.PMBoK
{
    public class PMBoKCategory
    {
        public int PMBoKCategoryId { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";


        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
