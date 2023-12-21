using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.ShopByShop.Models
{
    public class ErrorJson
    {
        [JsonProperty("message")]
        public string Message;
    }
}
