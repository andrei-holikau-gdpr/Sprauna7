using CoreBusiness;
using Moq;
using System.Xml;
using UseCases.DataStorePluginInterfaces;
using UseCases.PurchasesUseCases;

namespace Plugins.DataStore.InMemorySp.NTests
{
    public class PurchaseInMemoryRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetById_Returns_Entity_When_Entity_Exists()
        {
            // Arrange
            var repository = new PurchaseInMemoryRepository();
            var purchase = new Purchase { PurchaseId = 1 };
            repository.AddPurchase(purchase);

            // Act
            var result = repository.GetPurchaseById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(purchase.PurchaseId == result.PurchaseId);
        }



        [Test]
        public void GetPurchaseById_ReturnsPurchase_WhenPurchaseExists()
        {
            // Arrange
            int purchaseId = 1;
            var purchases = new List<Purchase> { 
                new Purchase { PurchaseId = purchaseId }, 
                new Purchase { PurchaseId = 2 } 
            };
            var mockRepository = new Mock<IPurchaseRepository>();
            mockRepository.Setup(r => r.GetPurchases()).Returns(purchases);
            var service = new GetPurchaseByIdUseCase(mockRepository.Object);

            // Act
            var result = service.Execute(purchaseId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(purchaseId == result.PurchaseId);
            //Assert.AreEqual(currentUserId, result.First<Purchase>( p => p.CurrentUserId == currentUserId)?.CurrentUserId);
        }

        [Test]
        public void GetPurchaseById_ReturnsNull_WhenPurchaseDoesNotExist()
        {
            // Arrange
            string currentUserId = "-1";
            var purchases = new List<Purchase>();
            var mockRepository = new Mock<IPurchaseRepository>();
            mockRepository.Setup(r => r.GetPurchases()).Returns(purchases);
            var service = new ViewPurchasesUseCase(mockRepository.Object);

            // Act
            var result = service.Execute(currentUserId);

            // Assert
            Assert.IsNull(result);
        }
    }
}