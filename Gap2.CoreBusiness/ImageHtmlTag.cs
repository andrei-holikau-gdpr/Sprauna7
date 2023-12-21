using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap2.CoreBusiness
{
    public class ImageHtmlTag
    {
        public int Id { get; set; }
        public string FileName { get; set; } = "";
        public string Alt { get; set; } = "";

        public ImageHtmlTag()
        {

        }
        public ImageHtmlTag(int imageHtmlTagId, string fileName, string alt = "")
        {
            Id = imageHtmlTagId;
            FileName = fileName;
            Alt = alt;
        }
    }
}
