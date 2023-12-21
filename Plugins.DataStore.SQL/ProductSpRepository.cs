using CoreBusiness;
using UseCases.DataStorePluginInterfaces;



namespace Plugins.DataStore.SQL
{

    public class ProductSpRepository : IProductSpRepository
    {
        private readonly SpraunaContext db;

        public ProductSpRepository(SpraunaContext db)
        {
            this.db = db;
        }

        public bool ExistsProductSpByTrackNumber(string TrackNumber)
        {
            var productSps = this.db.ProductSps.Where(ps => ps.TrackNumber == TrackNumber);
            return productSps != null && productSps.Count()>0;
        }

        public void AddProductSp(ProductSp productSp)
        {
            productSp.CategoryId = 1;
            //productSp.ProductSpId = db.ProductSps.OrderBy(p => p.ProductSpId).Last().ProductSpId;
            var query = db.ProductSps.Add(productSp);
            db.SaveChanges();
        }

        public void DeleteProductSp(int productSpId)
        {
            var productSp = db.ProductSps.Find(productSpId);
            if(productSp == null ) { return; }

            db.ProductSps.Remove(productSp);
            db.SaveChanges();
        }

#pragma warning disable CS8766
        // ToDo: CS8766
        public ProductSp? GetProductSpById(int productSpId)
        {
            return db.ProductSps.Find(productSpId);
        }
#pragma warning restore CS8766

        public IEnumerable<ProductSp> GetProductSpByPurchase(int purchaseId)
        {
            return db.ProductSps.Where(x => x.PurchaseNewId == purchaseId).ToList();
        }

        public IEnumerable<ProductSp> GetProductsSp()
        {
            return db.ProductSps;
        }

        public void UpdateProductSp(ProductSp productSp)
        {
            var itemToUpdate = db.ProductSps.Find(productSp.ProductSpId);

            if (itemToUpdate != null)
            {
                itemToUpdate.ProductTypeAndBrand = productSp.ProductTypeAndBrand;
                itemToUpdate.Quantity = productSp.Quantity;
                itemToUpdate.UrlToProduct = productSp.UrlToProduct;
                itemToUpdate.Price = productSp.Price;
                itemToUpdate.TrackNumber = productSp.TrackNumber;
                itemToUpdate.UrlToImage = productSp.UrlToImage;

                itemToUpdate.PurchaseNewId = productSp.PurchaseNewId;
                itemToUpdate.CategoryId = productSp.CategoryId;

                itemToUpdate.Description = productSp.Description;

                db.SaveChanges();
            }
        }
    }
}
