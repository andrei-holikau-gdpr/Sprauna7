using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemorySp
{
    public class ProductSpInMemoryRepository : IProductSpRepository
    {
        private List<ProductSp> productsSp;
        public ProductSpInMemoryRepository()
        {
            productsSp = new List<ProductSp>()
            {
                new ProductSp{ ProductSpId = 1,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    ProductTypeAndBrand = "Штаны 1 ", 
                    Description = "Описание 1",
                    PurchaseId = 1, 
                    Quantity = 10, 
                    Price= 10.99, 
                    UrlToImage = @"https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92"
                },
                new ProductSp{ ProductSpId = 2,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    ProductTypeAndBrand = "Майка 2 ", Description = "Описание 2",
                    PurchaseId = 1, Quantity = 30, Price= 4.99, 
                    UrlToImage = @"https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92"

                },
                new ProductSp{ ProductSpId = 3,
                    CurrentUserId = "392e95bf-c5e8-42f8-a7fd-eb47b65d71f2",
                    ProductTypeAndBrand = "Майки 3", Description = "Описание 3",
                    PurchaseId = 2, Quantity = 20, Price= 20.99,
                    UrlToImage = @"https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92"
                },
                new ProductSp{ ProductSpId = 3,
                    CurrentUserId = "4",
                    ProductTypeAndBrand = "Майки 3", Description = "Описание 3",
                    PurchaseId = 2, Quantity = 20, Price= 20.99,
                    UrlToImage = @"https://img.freepik.com/free-photo/white-t-shirts-with-copy-space-on-gray-background_53876-104920.jpg?w=1380&t=st=1684705904~exp=1684706504~hmac=fbc3236dbb2840c42a5fb2125297e813c71c158310db8002a147e015a161ff92"
                }
            };
        }

        public void AddProductSp(ProductSp productSp)
        {
            //if (productsSp.Any(x => x.ProductTypeAndBrand.Equals(productSp.ProductTypeAndBrand, StringComparison.OrdinalIgnoreCase))) return;

            if (productsSp != null && productsSp.Count > 0)
            {
                var maxId = productsSp.Max(x => x.ProductSpId);
                productSp.ProductSpId = maxId + 1;
            }
            else
            {
                productSp.ProductSpId = 1;
            }

            productsSp?.Add(productSp);
        }

        public void UpdateProductSp(ProductSp productSp)
        {
            var itemToUpdate = GetProductSpById(productSp.ProductSpId);
            if (itemToUpdate != null)
            {
                itemToUpdate.ProductTypeAndBrand = productSp.ProductTypeAndBrand;
                itemToUpdate.Quantity = productSp.Quantity;
                itemToUpdate.UrlToProduct = productSp.UrlToProduct;
                itemToUpdate.Price = productSp.Price;
                itemToUpdate.TrackNumber = productSp.TrackNumber;
                itemToUpdate.UrlToImage = productSp.UrlToImage;

                itemToUpdate.PurchaseId = productSp.PurchaseId;
                itemToUpdate.CategoryId = productSp.CategoryId;

                itemToUpdate.Description = productSp.Description;
            }
        }

        public IEnumerable<ProductSp> GetProductsSp()
        {
            return productsSp;
        }

        public ProductSp? GetProductSpById(int productSpId)
        {
            return productsSp?.FirstOrDefault(x => x.ProductSpId == productSpId);
        }

        public void DeleteProductSp(int productSpId)
        {
            var item = GetProductSpById(productSpId);
            if (item != null)
            {
                productsSp?.Remove(item);
            }            
        }

        public IEnumerable<ProductSp>? GetProductSpByPurchase(int purchaseId)
        {
            return productsSp?.Where(x => x.PurchaseId == purchaseId).ToList();
            //return productsSp?.FindAll(x => x.PurchaseId == purchaseId);
        }
    }
}
