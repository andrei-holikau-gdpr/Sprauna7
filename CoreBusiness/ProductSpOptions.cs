using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public static class ProductSpOptions
    {
        #region const

        public const string NameSingle = "ProductSp";
        public const string NameMany = "ProductsSp";

        public const string MainName = "Товар";

        public const string ProductTypeAndBrand = "Тип товара и марка";
        public const string Quantity = "Количество";
        public const string UrlToProduct = "Ссылка на товар";
        public const string Price = "Цена в злотых";
        public const string TrackNumber = "Трек номер";
        public const string UrlToImage = "Ссылка на картинку";
        // Relations
        public const string Purchase = "Посылка";
        public const string Category = "Категория";

        public const string Description = "Комментарий";

        #endregion

        public static ProductSp CopyProductSp(ProductSp old)
        {
            ProductSp newObject = new ProductSp();

            newObject.ProductTypeAndBrand = old.ProductTypeAndBrand;
            newObject.Quantity = old.Quantity;
            newObject.UrlToProduct = old.UrlToProduct;
            newObject.Price = old.Price;
            newObject.TrackNumber = old.TrackNumber;
            newObject.UrlToImage = old.UrlToImage;

            newObject.PurchaseNewId = old.PurchaseNewId;
            newObject.CategoryId = old.CategoryId;

            newObject.Description = old.Description;

            return newObject;
        }
    }
}
