using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class DirectorySp
    {
        public int DirectorySpId { get; set; }
        [Required]
        public string DirectoryName { get; set; }
        [Required]
        public string CurrentUserId { get; set; }
    }
}
