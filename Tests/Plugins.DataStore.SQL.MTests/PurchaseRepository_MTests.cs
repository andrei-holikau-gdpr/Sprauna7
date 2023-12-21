using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Plugins.DataStore.SQL.MTests
{
    [TestClass]
    public class PurchaseRepository_MTests
    {
        [TestMethod]
        public void PurchaseRepository_AddPurchase_Succesful()
        {
            var mockSet = new Mock<DbSet<Purchase>>();

            var options = new DbContextOptionsBuilder<SpraunaContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var mockContext = new Mock<SpraunaContext>(options);
            mockContext.Setup(m => m.Purchases).Returns(mockSet.Object);

            var service = new PurchaseRepository(mockContext.Object);
            service.AddPurchase(new Purchase());

            mockSet.Verify(m => m.Add(It.IsAny<Purchase>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}