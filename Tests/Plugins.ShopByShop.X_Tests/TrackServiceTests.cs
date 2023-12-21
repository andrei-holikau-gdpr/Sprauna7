// using HttpCode;
using CoreBusiness.ShopByShop.Models;
using Moq;
using Moq.Protected;
using Plugins.ShopByShop.Services;
using System.Net;

namespace Plugins.ShopByShop.X_Tests
{
    public class TrackServiceTests
    {
        private Mock<ShopByShopSettings> config = new();
        private Mock<HttpMessageHandler> handlerMock = new();
        private HttpClient httpClient;
        private TrackService service;

        public TrackServiceTests() {
            config.Object.UrlApi = "https://sprauna.by";
            config.Object.Token = "Token";

            httpClient = new HttpClient(handlerMock.Object);
            service = new TrackService(config.Object, httpClient);
        }

        [Fact]
        public async Task GetTracksAsync_ShouldReturnNull_WhenTokenIsNullOrWhiteSpace()
        {
            // Arrange
            config.Object.Token = "";

            // Act
            var response = await service.GetTracksAsync();

            // Assert
            Assert.Null(response);
        }

        [Fact]
        public async Task GetTracksAsync_ShouldReturnTracks_WhenIsGood()
        {
            // Arrange
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{""success"":true,""data"":{""tracks"":{""current_page"":1,""data"":[{""id"":26183,""code"":""TestCode1"",""recipient_id"":6037,""consolidation_id"":null,""lead_id"":null,""delivery_type"":2,""status"":1,""hide"":0,""user_name"":""TestUserName"",""surname"":""TestSurname"",""pvz"":""70130060"",""address"":null,""city"":null,""comment"":""TestComment"",""price"":null,""store"":""Allegro.pl"",""wait"":1,""weight"":null,""type"":0,""created_at"":""2023-07-21T14:39:43.000000Z"",""updated_at"":""2023-07-21T14:39:43.000000Z"",""shop_number"":""GP000026183PL"",""apartment"":null,""cdek_number"":null,""payment_token"":null,""comment_amo"":null,""track_status"":null,""additional_services"":null,""additional_services_price"":null,""agree"":1,""insurence"":0,""photo"":0,""check_size"":0,""packing"":0,""invoice"":null,""statusLabel"":""\u041e\u0436\u0438\u0434\u0430\u0435\u043c\u0430\u044f"",""priceReal"":0,""additionalServicesText"":"""",""pvzAddress"":""\u041e\u0442\u0434\u0435\u043b\u0435\u043d\u0438\u0435 \u21166 \u0433. \u041c\u0438\u043d\u0441\u043a, \u0443\u043b. \u041f\u0440\u0438\u0442\u044b\u0446\u043a\u043e\u0433\u043e, 29 (1-\u0439 \u044d\u0442\u0430\u0436 \u0422\u0426 \""\u0422\u0438\u0432\u0430\u043b\u0438\"")"",""file"":[],""products"":[{""id"":337170,""track_id"":26183,""name"":""KAWA ZIARNISTA 1KG NICARAGUA ARABICA \u015aWIE\u017bO PALONA"",""count"":2,""price"":56,""link"":""https:\/\/allegro.pl\/oferta\/kawa-ziarnista-1kg-nicaragua-arabica-swiezo-palona-13797863265?reco_id=64256b10-11c4-11ee-ac1d-fa37a93ec943&sid=4adeb7ec79c2f7c0bade1814890267fca3c707c4741fa54a916b445dfaf5b843"",""total"":112,""code_tnved"":null,""name_tnved"":null}]},{""id"":26182,""code"":""test-13220004836095"",""recipient_id"":2011,""consolidation_id"":null,""lead_id"":null,""delivery_type"":2,""status"":1,""hide"":0,""user_name"":""Test"",""surname"":""Test"",""pvz"":""70130010"",""address"":null,""city"":null,""comment"":null,""price"":null,""store"":""Test store"",""wait"":1,""weight"":null,""type"":0,""created_at"":""2023-06-23T15:24:09.000000Z"",""updated_at"":""2023-06-23T15:24:09.000000Z"",""shop_number"":""GP000026182PL"",""apartment"":null,""cdek_number"":null,""payment_token"":null,""comment_amo"":null,""track_status"":null,""additional_services"":null,""additional_services_price"":null,""agree"":1,""insurence"":0,""photo"":0,""check_size"":0,""packing"":0,""invoice"":null,""statusLabel"":""\u041e\u0436\u0438\u0434\u0430\u0435\u043c\u0430\u044f"",""priceReal"":0,""additionalServicesText"":"""",""pvzAddress"":""\u041e\u0442\u0434\u0435\u043b\u0435\u043d\u0438\u0435 \u21161 \u0433. \u041c\u0438\u043d\u0441\u043a, \u0443\u043b. \u041c\u043e\u043d\u0442\u0430\u0436\u043d\u0438\u043a\u043e\u0432, 2 (\u043c-\u043d \""\u0415\u0432\u0440\u043e\u043e\u043f\u0442\"")"",""file"":[],""products"":[{""id"":337169,""track_id"":26182,""name"":""KAWA ZIARNISTA 1KG NICARAGUA ARABICA \u015aWIE\u017bO PALONA"",""count"":1,""price"":55.99,""link"":""https:\/\/allegro.pl\/oferta\/kawa-ziarnista-1kg"",""total"":55.99,""code_tnved"":null,""name_tnved"":null}]}],""first_page_url"":""http:\/\/devprofile.shopbyshop.by\/api\/v1\/track?page=1"",""from"":1,""last_page"":1,""last_page_url"":""http:\/\/devprofile.shopbyshop.by\/api\/v1\/track?page=1"",""next_page_url"":null,""path"":""http:\/\/devprofile.shopbyshop.by\/api\/v1\/track"",""per_page"":100,""prev_page_url"":null,""to"":2,""total"":2}},""message"":""""}"),
            };

            handlerMock
              .Protected()
              .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
              .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object);
            var trackService = new TrackService(config.Object, httpClient);

            // Act
            var responseTracks = await trackService.GetTracksAsync();

            // Assert
            Assert.NotNull(responseTracks);
            handlerMock.Protected().Verify(
              "SendAsync",
              Times.Exactly(1),
              ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
              ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task CreateTrackAsync_ShouldReturnTracks_WhenIsGood()
        {
            // Arrange


            // Act
            var response = await service.CreateTrackAsync();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task UpdateTrackAsync_ShouldReturnTracks_WhenIsGood()
        {
            // Arrange


            // Act
            var response = await service.UpdateTrackAsync();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteTrackAsync_ShouldReturnTracks_WhenIsGood()
        {
            // Arrange


            // Act
            var response = await service.DeleteTrackAsync();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task ShowInfoTrackAsync_ShouldReturnTracks_WhenIsGood()
        {
            // Arrange


            // Act
            var response = await service.DeleteTrackAsync();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task RecoverTrackAsync_ShouldReturnTracks_WhenIsGood()
        {
            // Arrange


            // Act
            var response = await service.RecoverTrackAsync();

            // Assert
            Assert.True(false);
        }
    }
}