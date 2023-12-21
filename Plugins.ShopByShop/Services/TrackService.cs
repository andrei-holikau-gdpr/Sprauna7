using CoreBusiness.ShopByShop.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using UseCases.ShopByShop.InterfacesRepositories;

namespace Plugins.ShopByShop.Services
{
    public class TrackService : ShopByShopService, ITrackRepository
    {
        #region Private Fields

        // Получение всех треков пользователя
        private readonly string UrlGetTracks = "/track";
        // Создание трека
        private readonly string UrlCreateTrackPost = "/track";
        // Update track
        private readonly string UrlUpdateTrackPost = "/track/{id}";
        // Soft delete track
        private readonly string UrlDeleteTrack = "/track/{id}";
        // Show info track
        private readonly string UrlGetInfoTrack = "/track/{id}";
        // Recover track
        private readonly string UrlRecoverTrackGet = "/track/{id}/recover";

        #endregion
        //---
        #region Public Methods

        public TrackService(ShopByShopSettings shopByShopConfig, HttpClient? client)
            : base(shopByShopConfig, client)
        {
            UrlGetTracks       = sbsConfig.UrlApi + UrlGetTracks;
            UrlCreateTrackPost = sbsConfig.UrlApi + UrlCreateTrackPost;
            UrlUpdateTrackPost = sbsConfig.UrlApi + UrlUpdateTrackPost;
            UrlDeleteTrack     = sbsConfig.UrlApi + UrlDeleteTrack;
            UrlGetInfoTrack    = sbsConfig.UrlApi + UrlGetInfoTrack;
            UrlRecoverTrackGet = sbsConfig.UrlApi + UrlRecoverTrackGet;
            if (client == null) {
                client = new HttpClient();
            }
        }

        #pragma warning disable CS8603 //todo: #pragma warning disable CS8600 

        /// <summary>
        /// Получение всех треков пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TrackItem>> GetTracksAsync()
        {
            List<TrackItem> result = new();
            var response = await httpClient.GetAsync(UrlGetTracks);
            if(response.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                //var jsonResponse = await _httpClient.GetStringAsync(requestUri);
                if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
                {
                    //var restoredRoot = JsonSerializer.Deserialize<IEnumerable<JsonElement>>(jsonResponse);
                    //var jsonDeserialize = JsonSerializer.Deserialize<TracksJson>(jsonResponse);
                    var jsonDeserialize = JsonConvert.DeserializeObject<TracksJson>(jsonResponse);
                    var listTrackItem = jsonDeserialize?.Data?.Tracks?.Data ?? new();

                    // var temp1 = listTrackItem.OrderBy(element => element.Id).ToList();
                    // var temp2 = listTrackItem.OrderByDescending(element => element.Id);

                    // result = temp2.ToList();
                    result = listTrackItem.ToList();
                }
            } 
            return result;
        }

        /// <summary>
        /// Создание трека
        /// </summary>
        /// <returns></returns>
        public async Task<int?> CreateTrackAsync(TrackItem trackItem)
        {
            var endpoint = UrlCreateTrackPost;

            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            var content = new MultipartFormDataContent();

            #region Fill Form Data
            content.Add(new StringContent(trackItem.Code.Replace(":", "")), 
                "code");            // * 1
            content.Add(new StringContent(trackItem.RecipientId?.ToString()), 
                "recipient_id");    // * 2
            content.Add(new StringContent(trackItem.UserName), 
                "user_name");       // * 3
            content.Add(new StringContent(trackItem.Surname), 
                "surname");         // * 4
            content.Add(new StringContent(trackItem.Pvz?.ToString()), 
                "pvz");             // * 5
            content.Add(new StringContent(trackItem.Store), 
                "store");           // * 6
            content.Add(new StringContent(trackItem.Wait?.ToString()), 
                "wait");            // * 7
            content.Add(new StringContent(trackItem.Agree?.ToString()), 
                "agree");           // * 8

            /*
            content.Add(new StringContent("2013"), "recipient_id");
            content.Add(new StringContent("UserName"), "user_name");
            content.Add(new StringContent("surname"), "surname");
            content.Add(new StringContent("70130010"), "pvz");
            content.Add(new StringContent("TestStore"), "store");
            content.Add(new StringContent("1"), "wait");
            content.Add(new StringContent("1"), "agree");
            */

            content.Add(new StringContent("2"), "delivery_type"); // * 9
            content.Add(new StringContent("1"), "agree2");  // * 10
            content.Add(new StringContent("1"), "agree3");  // * 11

            // content.Add(new ByteArrayContent(File.ReadAllBytes("C:/48.jpg")), "invoice", "48.jpg");

            int i = 1;
            foreach(var product in trackItem.Products)
            {
                content.Add(new StringContent(product.Name),
                    $"item_list[{i}][name]");   // * 01
                content.Add(new StringContent(product?.Count?.ToString() ?? "0"),
                    $"item_list[{i}][count]");  // * 02
                content.Add(new StringContent(product?.Link?.ToString() ?? "0"),
                    $"item_list[{i}][link]");   // * 03
                content.Add(new StringContent(product?.Price?.ToString() ?? "0"),
                    $"item_list[{i}][price]");  // * 04

               // content.Add(new ByteArrayContent(File.ReadAllBytes("C:/48.jpg")),
               //     $"invoice[{i}][file]", "48.jpg");

            }

            var currentDirectory = Directory.GetCurrentDirectory();

            var path = Path.Combine(currentDirectory, "unsafe_uploads",
                    "invoice-allegro.jpg");

            content.Add(new StreamContent(File.OpenRead(path)), "invoice", "invoice-allegro.jpg");

            /* Заглушки
            content.Add(new StringContent("KAWA ZIARNISTA 1KG NICARAGUA ARABICA ŚWIEŻO PALONA"), 
                "item_list[0][name]");
            content.Add(new StringContent("1"), 
                "item_list[0][count]");
            content.Add(new StringContent("https://allegro.pl/oferta/kawa-ziarnista-1kg"), 
                "item_list[0][link]");
            content.Add(new StringContent("55.99"), 
                "item_list[0][price]");
            content.Add(new ByteArrayContent(File.ReadAllBytes("C:/48.jpg")), 
                "invoice[0][file]", "48.jpg");
            */
            #endregion

            request.Content = content;

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", "Bearer 1|27DetjHTbItGQJZoJUTfSZnnBo9DTmlWxBBQHvh5");

            var response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created
                || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonDeserialize = JsonConvert.DeserializeObject<TrackShowJson>(jsonResponse);
                
                if (jsonDeserialize?.Success == true)
                {
                    var trackId = jsonDeserialize?.Data?.Id;
                    return trackId;
                } 
                else
                {
                    var jsonErrorDeserialize = JsonConvert.DeserializeObject<ErrorJson>(jsonResponse);

                    throw new Exception("Error:2108038. SbsTrack No Created. " + jsonErrorDeserialize.Message);
                }                
            }  
            else
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonErrorDeserialize = JsonConvert.DeserializeObject<ErrorJson>(jsonResponse);

                // https://www.online-decoder.com/ru
                // {"message":"The given data was invalid.","errors":{"code":["\u0442\u0430\u043a\u043e\u0439 \u0442\u0440\u0435\u043a-\u043d\u043e\u043c\u0435\u0440 \u0443\u0436\u0435 \u0434\u043e\u0431\u0430\u0432\u043b\u0435\u043d"]}}
                // {"message":"The given data was invalid.","errors":{"code":["такой трек-номер уже добавлен"]}} 

                //string unicodeString = jsonResponse;
                //Encoding unicode = Encoding.Unicode;
                //Encoding utf8 = Encoding.UTF8;

                //byte[] unicodeBytes = unicode.GetBytes(unicodeString);
                //byte[] utf8Bytes = Encoding.Convert(unicode, utf8, unicodeBytes);

                //string utf8String = utf8.GetString(utf8Bytes);

                // https://www.online-decoder.com/ru
                // https://2cyr.com/decode/?lang=ru
                throw new Exception("Error:2108039. SbsTrack No Created. ." + jsonResponse);
            }
            return null;
        }

        /// <summary>
        /// Update track
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UpdateTrackAsync(TrackItem trackItem)
        {
            var oldTrackItem = ShowInfoTrackAsync(trackItem.Id ?? 0);
            if (oldTrackItem != null)
            {
                var endpoint = UrlUpdateTrackPost.Replace("{id}", trackItem.Id.ToString());

                var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

                var content = new MultipartFormDataContent();
                #region Fill Form Data

                content.Add(new StringContent("PUT"), "_method");

                content.Add(new StringContent(trackItem.Code), "code");
                content.Add(new StringContent(trackItem.RecipientId?.ToString()), "recipient_id");
                content.Add(new StringContent(trackItem.UserName), "user_name");
                content.Add(new StringContent(trackItem.Surname), "surname");
                content.Add(new StringContent(trackItem.Pvz?.ToString()), "pvz");
                content.Add(new StringContent(trackItem.Store), "store");
                content.Add(new StringContent(trackItem.Wait?.ToString()), "wait");
                content.Add(new StringContent(trackItem.Agree?.ToString()), "agree");

                content.Add(new StringContent("2"), "delivery_type"); // * 9
                content.Add(new StringContent("1"), "agree2");  // * 10
                content.Add(new StringContent("1"), "agree3");  // * 11

                // content.Add(new ByteArrayContent(File.ReadAllBytes("C:/48.jpg")), "invoice", "48.jpg");

                int i = 1;
                if (trackItem.Products != null)
                {
                    foreach (var product in trackItem.Products)
                    {
                        content.Add(new StringContent(product.Name),
                            $"item_list[{i}][name]");   // * 01
                        content.Add(new StringContent(product?.Count?.ToString() ?? "0"),
                            $"item_list[{i}][count]");  // * 02
                        content.Add(new StringContent(product?.Link?.ToString() ?? "0"),
                            $"item_list[{i}][link]");   // * 03
                        content.Add(new StringContent(product?.Price?.ToString() ?? "0"),
                            $"item_list[{i}][price]");  // * 04                       
                    }
                }
                //System.IO.File.OpenRead(path)

                //string path = Server.MapPath("~/folder/image.jpeg");

                var currentDirectory = Directory.GetCurrentDirectory();

                var path = Path.Combine(currentDirectory, "unsafe_uploads",
                        "invoice-allegro.jpg");

                content.Add(new StreamContent(File.OpenRead(path)), "invoice", "invoice-allegro.jpg");

                // content.Add(new StringContent("https://www.allegropediatrics.com/uploads/images/bill-pay.jpg"),
                //             $"invoice[1][file]");

                //content.Add(new ByteArrayContent(
                //    File.ReadAllBytes(path)), //C:/images/48.jpg")),
                //            $"invoice[1][file]", "invoice-allegro.jpg");
                
                //content.Add(new StreamContent(
                //    new FileStream(path, FileMode.Open)), //C:/images/48.jpg")),
                //            $"invoice[1][file]", "invoice-allegro.jpg");

                #endregion
                request.Content = content;

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", "Bearer 1|27DetjHTbItGQJZoJUTfSZnnBo9DTmlWxBBQHvh5");

                var response = await httpClient.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return true;
                } else
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Soft delete track
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteTrackAsync(int Id)
        {
            // throw new NotImplementedException();
            bool result = false;
            string urlWithId = UrlDeleteTrack.Replace("{id}", Id.ToString());
            var response = await httpClient.GetAsync(urlWithId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                //var jsonResponse = await _httpClient.GetStringAsync(requestUri);
                if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
                {
                    //var restoredRoot = JsonSerializer.Deserialize<IEnumerable<JsonElement>>(jsonResponse);
                    //var jsonDeserialize = JsonSerializer.Deserialize<TracksJson>(jsonResponse);
                    var jsonDeserialize = JsonConvert.DeserializeObject<TrackDelJson>(jsonResponse);
                    if (jsonDeserialize?.Success == true)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Show info track
        /// </summary>
        /// <returns></returns>
        public async Task<TrackItem?> ShowInfoTrackAsync(int Id)
        {
            // throw new NotImplementedException();

            TrackItem? result = new();
            string urlWithId = UrlGetInfoTrack.Replace("{id}", Id.ToString()); 
            var response = await httpClient.GetAsync(urlWithId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                //var jsonResponse = await _httpClient.GetStringAsync(requestUri);
                if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
                {
                    //var restoredRoot = JsonSerializer.Deserialize<IEnumerable<JsonElement>>(jsonResponse);
                    //var jsonDeserialize = JsonSerializer.Deserialize<TracksJson>(jsonResponse);
                    var jsonDeserialize = JsonConvert.DeserializeObject<TrackShowJson>(jsonResponse);
                    var trackItem = jsonDeserialize?.Data;
                    result = trackItem;
                }
            }
            return result;
        }

        /// <summary>
        /// Recover track
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RecoverTrackAsync(int Id)
        {
            throw new NotImplementedException();

            var requestUri = UrlRecoverTrackGet;
            var response = await httpClient.GetAsync(requestUri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {



            } //return null;
        }

        #pragma warning restore CS8603

        #endregion
    }
}
