namespace Plugins.DataStore.InMemorySp.Tests
{
    public class PurchaseInMemoryRepositoryTests
    {
        [Fact]
        [Test]
        public void GetPurchaseById_ReturnsPurchase_WhenPurchaseExists()
        {
            // Arrange
            var purchaseId = 1;
            var purchases = new List<Purchase> { new Purchase { PurchaseId = purchaseId } };
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetPurchases()).Returns(purchases);
            var service = new PurchaseService(mockRepository.Object);

            // Act
            var result = service.GetPurchaseById(purchaseId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(purchaseId, result.PurchaseId);
        }

        [Test]
        public void GetPurchaseById_ReturnsNull_WhenPurchaseDoesNotExist()
        {
            // Arrange
            var purchaseId = -1;
            var purchases = new List<Purchase>();
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetPurchases()).Returns(purchases);
            var service = new PurchaseService(mockRepository.Object);

            // Act
            var result = service.GetPurchaseById(purchaseId);

            // Assert
            Assert.IsNull(result);
        }

    }
}