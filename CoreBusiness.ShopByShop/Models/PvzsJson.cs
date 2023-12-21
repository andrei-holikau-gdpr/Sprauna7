namespace CoreBusiness.ShopByShop.Models
{
    public class PvzsJson
    {
        public bool success { get; set; }
        public PvzJsonData? data { get; set; }
        public string? message { get; set; }
    }

    public class PvzJsonData
    {
        public List<PvzItem>? pvz { get; set; }
    }

    public class PvzItem
    {
        //[JsonProperty("id")]
        //public int? Id;
        public int gipermall_id { get; set; }
        public string? value { get; set; }
        public int hide { get; set; }
    }
}
