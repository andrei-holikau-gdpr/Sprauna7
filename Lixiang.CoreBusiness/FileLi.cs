using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lixiang.CoreBusiness
{
    public class FileLi
    {
        public int FileLiId { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileNameForFileStorage { get; set; }
        [Required]
        public string FilePath { get; set; }

        public DateTime CreationDate { get; set; }

        [NotMapped]
        public ImageHtmlTag ParentImageHtmlTag { get; set; }
    }
}
