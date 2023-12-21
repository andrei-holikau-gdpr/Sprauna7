using CoreBusiness.ShopByShop.Models;
using Moq;
using Plugins.ShopByShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.ShopByShop.X_Tests
{
    public class RecipientServiceTests
    {
        private Mock<ShopByShopSettings> config = new();
        private Mock<HttpMessageHandler> handlerMock = new();
        private HttpClient httpClient;
        private RecipientService service;

        public RecipientServiceTests()
        {
            config.Object.UrlApi = "https://sprauna.by";
            config.Object.Token = "Token";

            httpClient = new HttpClient(handlerMock.Object);
            service = new RecipientService(config.Object, httpClient);
        }

        [Fact]
        public async Task GetTracksAsync_ShouldReturnNull_WhenTokenIsNullOrWhiteSpace()
        {
            // Arrange
            config.Object.Token = "";

            // Act
            var response = await service.GetRecipientsAsync();

            // Assert
            Assert.Null(response);
        }
    }
}
