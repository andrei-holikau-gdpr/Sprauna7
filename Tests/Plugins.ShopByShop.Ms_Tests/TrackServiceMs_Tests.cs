using CoreBusiness.ShopByShop.Models;
using Plugins.ShopByShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.ShopByShop.Ms_Tests
{
    [TestClass]
    public class TrackServiceTests
    {
        private readonly HttpClient _httpClient = new HttpClient();

        //[TestMethod]
        //public async Task GetTracksAsync_WithValidConfig_ReturnsTracks()
        //{
        //    // Arrange
        //    var config = new ShopByShopSettings
        //    {
        //        UrlApi = "<https://example.com/api/>",
        //        Token = "valid_token"
        //    };
        //    var trackService = new TrackService(config);

        //    // Act
        //    var result = await trackService.GetTracksAsync(_httpClient);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsInstanceOfType(result, typeof(Root));
        //}

        //[TestMethod]
        //public async Task GetTracksAsync_WithInvalidConfig_ReturnsNull()
        //{
        //    // Arrange
        //    var config = new ShopByShopSettings
        //    {
        //        UrlApi = "<https://example.com/api/>",
        //        Token = string.Empty
        //    };
        //    var trackService = new TrackService(config);

        //    //_httpClient.Setup(
        //    //    x => x.GetStringAsync(requestUri))
        //    //    .ReturnsAsync(response);

        //    // Act
        //    var result = await trackService.GetTracksAsync(_httpClient);

        //    // Assert
        //    Assert.IsNull(result);
        //}
    }

}
