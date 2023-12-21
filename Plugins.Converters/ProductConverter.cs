using CoreBusiness;
using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Converters
{
    public static class ProductConverter
    {
        public static Product ConvertToProduct(this ProductSp productSp)
        {
            return new Product()
            {
                Id = productSp.SbsId,
                // TrackId
                Name = productSp.ProductTypeAndBrand,
                Count = productSp.Quantity,
                Price = productSp.Price,
                Link = productSp.UrlToProduct
                // Total
                // CodeTnved
                // NameTnved
            };
        }
    }
}
