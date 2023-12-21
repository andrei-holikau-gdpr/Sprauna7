using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductSpRepository
    {
        IEnumerable<ProductSp> GetProductsSp();
        void AddProductSp(ProductSp productSp);
        void UpdateProductSp(ProductSp productSp);
        ProductSp GetProductSpById(int productSpId);
        void DeleteProductSp(int productSpId);
        IEnumerable<ProductSp> GetProductSpByPurchase(int purchaseId);
        bool ExistsProductSpByTrackNumber(string TrackNumber);
    }
}
