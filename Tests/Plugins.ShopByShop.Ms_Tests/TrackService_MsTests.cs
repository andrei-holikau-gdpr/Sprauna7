using Moq;
using UseCases.ShopByShop.InterfacesRepositories;
using CoreBusiness.ShopByShop.Models;
using Plugins.ShopByShop.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Net;
using Moq.Protected;
using System.Net.Http;

namespace Plugins.ShopByShop.Ms_Tests
{

    [TestClass]
    public class TrackService_MsTests
    {
        private MockRepository _mockRepository;

        private Mock<ShopByShopSettings> _sbsConfigMock = new();
        private HttpClient? _mockHttpClient;
        private ITrackRepository? _trackService;

        private Mock<HttpMessageHandler> _handlerMock;
        private HttpClient _magicHttpClient;

        [TestInitialize]
        public void Setup()
        {
            _sbsConfigMock.Object.UrlApi = "urlApi";
            _sbsConfigMock.Object.Token = "myToken";

            _mockRepository = new(MockBehavior.Default);
            _handlerMock = _mockRepository.Create<HttpMessageHandler>();
        }



        //[TestMethod]
        //public async Task GetTracksAsync_ShouldReturnNull_WhenResponseIsNullOrEmpty()
        //{
        //    // Arrange
        //    string response = "";
        //    string requestUri = It.IsAny<string>();
        //    _trackService = new TrackService(_sbsConfigMock.Object);

        //    var _handlerMock = new Mock<HttpMessageHandler>();
        //    var _magicHttpClient = new Mock<HttpClientSp>(_handlerMock.Object);

        //    _magicHttpClient = new(_handlerMock.Object);

        //    _magicHttpClient.Setup<Task<string>>("GetStringAsync", requestUri)
        //        .ReturnsAsync(response);

        //    // Act
        //    var result = await _trackService.GetTracksAsync(_magicHttpClient.Object);
        //    // var result = await _trackService.GetTracksAsync(_mockHttpClient);

        //    // Assert
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public async Task GetTracksAsync_ShouldReturnNull_WhenTokenIsNullOrWhiteSpace()
        //{
        //    // Arrange
        //    _sbsConfigMock.Object.Token = "";
        //    _trackService = new TrackService(_sbsConfigMock.Object);

        //    // Act
        //    //var result = await _trackService.GetTracksAsync();Ghb
        //    var result = await _trackService.GetTracksAsync(_mockHttpClient);

        //    // Assert
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public async Task GetTracksAsync_ShouldReturnRoot_WhenResponseIsValid()
        //{
        //    // Arrange
        //    string response = "{\"data\": [{\"id\": 1, \"name\": \"Track 1\"}]}";

        //    //_mockHttpClient.Setup(
        //    //    x => x.GetStringAsync(It.IsAny<string>()))
        //    //    .ReturnsAsync(response);

        //    // Act
        //    var result = await _trackService.GetTracksAsync(_mockHttpClient);

        //    // Assert
        //    Assert.IsNotNull(result);

        //   // Assert.AreEqual(1, result?.data[0]?.id);
        //   // Assert.AreEqual("Track 1", result.data[0].name);
        //}
    }
}