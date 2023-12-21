namespace Lixiang.CoreBusiness
{
    public class ImageHtmlTag
    {
        public int ImageHtmlTagId { get; set; }
        public string FileName { get; set; } = "";
        public string Alt { get; set; } = "";

        public ImageHtmlTag()
        {

        }
        public ImageHtmlTag(int imageHtmlTagId, string fileName, string alt = "")
        {
            ImageHtmlTagId = imageHtmlTagId;
            FileName = fileName;
            Alt = alt;
        }
    }
}