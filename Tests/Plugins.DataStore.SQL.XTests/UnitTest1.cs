//namespace Plugins.DataStore.SQL.XTests
using System.Collections.Generic;
using System.Linq;
using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Moq;
using Plugins.DataStore.SQL;
using Xunit;
using Moq.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace MyProject.Tests
{
    public class MyRepositoryTests
    {
        [Fact]
        public void GetItems_ReturnsAllItems()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SpraunaContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var mockContext = new Mock<SpraunaContext>(options);
            //var mockContext = new Mock<SpraunaContext>();

            var items = new List<Purchase>
            {
                new Purchase { PurchaseId = 1, Name = "Item 1" },
                new Purchase { PurchaseId = 2, Name = "Item 2" },
                new Purchase { PurchaseId = 3, Name = "Item 3" }
            }.AsQueryable();

            mockContext.Setup(x => x.Purchases).ReturnsDbSet(items);

            var repository = new PurchaseRepository(mockContext.Object);

            // Act
            var result = repository.GetPurchases();

            // Assert
            Assert.Equal(3, result.Count());
        }

    }
}
