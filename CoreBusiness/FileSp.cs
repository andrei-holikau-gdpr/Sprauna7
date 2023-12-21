using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class FileSp
    {
        public int FileSpId { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileNameForFileStorage { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string CurrentUserId { get; set; }

        public DateTime CreationDate { get; set; }

        #region  Relations Objects
        public Receiver Receiver { get; set; }
        #endregion
    }
}
