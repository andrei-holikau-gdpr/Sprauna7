using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.ShopByShop.Models
{
    public class ShopByShopSettings
    {
        #region Public fields

        public string? UrlApi { get; set; }
        public string? Token { get; set; }
        public string? Accept { get; set; }

        #endregion
        //---
        #region Private Methods

        public bool IsValidConfig()
        {
            if (!string.IsNullOrWhiteSpace(UrlApi)
                && !string.IsNullOrWhiteSpace(Token))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
