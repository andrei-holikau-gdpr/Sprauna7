using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.ShopByShop.Models
{
    public class RecipientCreateJson
    {
        [JsonProperty("success")]
        public bool? Success;

        [JsonProperty("data")]
        public Data Data;

        [JsonProperty("message")]
        public string Message;
    }
    public class Data
    {
        [JsonProperty("recipient")]
        public RecipientItem Recipient;
    }
    
}
