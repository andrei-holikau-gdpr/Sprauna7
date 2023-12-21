using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Moq;
using UseCases.DataStorePluginInterfaces;
using Moq.EntityFrameworkCore;


namespace Plugins.DataStore.SQL.NTests
{
    [TestFixture]
    public class PurchaseRepositoryTests
    {
        private Mock<SpraunaContext> _dbContextMock;
        private IPurchaseRepository _repository;
        private Mock<DbSet<Purchase>> _mockSet;
        private DbContextOptions _mockOptions;

        private IQueryable<Purchase> _purchaseList;

        [SetUp]
        public void SetUp()
        {
            _mockSet = new Mock<DbSet<Purchase>>();

            _mockOptions = new DbContextOptionsBuilder<SpraunaContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContextMock = new Mock<SpraunaContext>(_mockOptions);
            _dbContextMock.Setup(m => m.Purchases).Returns(_mockSet.Object);

            _repository = new PurchaseRepository(_dbContextMock.Object);

            _purchaseList = new List<Purchase>
            {
                new Purchase { PurchaseId = 10, Name = "Item 10", CurrentUserId = "100" },
                new Purchase { PurchaseId = 20, Name = "Item 20", CurrentUserId = "200" },
                new Purchase { PurchaseId = 30, Name = "Item 30", CurrentUserId = "300" }
            }.AsQueryable();

            _dbContextMock.Setup(x => x.Purchases).ReturnsDbSet(_purchaseList);

            // _dbContextMock.Setup(x => x.Purchases.ToList()).Returns(_purchaseList.ToList());
        }

        [Test]
        public void GetPurchases_ReturnEntities()
        {
            // Arrange
            
            // Act
            var result = _repository.GetPurchases();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count() == _purchaseList.Count(), Is.True);
        }

        [Test]
        public void GetById_ShouldReturnEntity_WhenEntityExists()
        {
            // Arrange
            Purchase _expectedPurchase = new Purchase { PurchaseId = 1 };
            _dbContextMock.Setup(x => x.Purchases.Find(1)).Returns(_expectedPurchase);            

            // Act
            var result = _repository.GetPurchaseById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(_expectedPurchase));
        }

        [Test]
        public void GetById_ShouldReturnNull_WhenEntityNotExists()
        {
            // Arrange
            var entity = new Purchase { PurchaseId = 1 };
            int _expectedPurchaseId = 2;
            // _dbContextMock.Setup(x => x.Purchases.Find(_expectedPurchaseId)).Returns(null);

            // Act
            var result = _repository.GetPurchaseById(_expectedPurchaseId);

            // Assert
            Assert.That(result, Is.Null);
            //Assert.IsNull(result);
        }

        [Test]
        public void AddPurchase_ShouldAddEntityToDatabase()
        {
            // Arrange
            var entity = new Purchase();

            // Act
            _repository.AddPurchase(entity);

            _dbContextMock.Verify(x => x.Purchases.Add(entity), Times.Once);
            _dbContextMock.Verify(x => x.SaveChanges(), Times.Once);

            var result = _repository.GetPurchases();

            // Assert
            Assert.That(result.Count() == _purchaseList.Count()-1);
        }

        [Test]
        public void DeletePurchase_ShouldDeleteEntityToDatabase()
        {
            // Arrange
            var entity = new Purchase { PurchaseId = 10, Name = "Item 10", CurrentUserId = "100" };

            // Act
            _repository.DeletePurchase(entity.PurchaseId, "100");

            // Assert
            _dbContextMock.Verify(x => x.Purchases.Remove(entity), Times.Once);
            _dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        // Следуйте подобной структуре для тестирования методов UpdateAsync и DeleteAsync
    }
}