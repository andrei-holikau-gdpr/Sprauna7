using CoreBusiness.ShopByShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.ShopByShop.Services
{
    public class ConsolidationService : ShopByShopService
    {
        #region Private Fields Consolidation

        // Получение всех консолидаций
        private readonly string UrlConsolidations = "/consolidation";
        // Просмотр данных консолидации
        private readonly string UrlGetInfoConsolidation = "/consolidation/{id}";
        // Создание консолидации из посылок
        private readonly string UrlCreateConsolidationPost = "/consolidation/create";
        // Удаление консолидации
        // Удалить можно только в течении 5 минут после создания
        private readonly string UrlDeleteConsolidation = "/consolidation/{id}";

        #endregion
        //---
        #region Public Methods

        public ConsolidationService(
            ShopByShopSettings shopByShopConfig,
            HttpClient? client = null)
                : base(shopByShopConfig, client)
        {
            UrlConsolidations = sbsConfig.UrlApi + UrlConsolidations;
            UrlGetInfoConsolidation = sbsConfig.UrlApi + UrlGetInfoConsolidation;
            UrlCreateConsolidationPost = sbsConfig.UrlApi + UrlCreateConsolidationPost;
            UrlDeleteConsolidation = sbsConfig.UrlApi + UrlDeleteConsolidation;
        }

#pragma warning disable CS8603 //todo: #pragma warning disable CS8600 

        /// <summary> Получение всех консолидаций </summary>
        public async Task<List<ConsolidationItem>> GetConsolidationsAsync()
        {
            List<ConsolidationItem> result = new();
            var response = await httpClient.GetAsync(UrlConsolidations);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                //var jsonResponse = await _httpClient.GetStringAsync(requestUri);
                if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
                {
                    var jsonDeserialize = JsonConvert.DeserializeObject<ConsolidationListJson>(jsonResponse);
                    var listItem = jsonDeserialize?.Data?.Tracks?.Data;
                    
                    result = listItem;
                }
            }
            return result;
        }
        /// <summary> Просмотр данных консолидации </summary>
        public async Task<int?> CreateConsolidationAsync(ConsolidationItem consolidationItem)
        {
            #region Заглушки

            // ToDo: Убрать заглушки
            //consolidationItem.Birthdate = DateTime.Now;
            
            #endregion
            var endpoint = UrlCreateConsolidationPost;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            #region Fill Form Data

            var parameters = new MultipartFormDataContent
            {
                // { new StringContent(consolidationItem.Email), "email" },
            };
           // parameters.Add(new StringContent(consolidationItem.Email), "email");

            #endregion
            client.DefaultRequestHeaders.Add("Accept", "application/json"); // sbsConfig.Accept);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {sbsConfig.Token}");
            // request.Headers.Add("Accept", "application/json");

            var response = await client.PostAsync(endpoint, parameters);

            if (response.StatusCode == System.Net.HttpStatusCode.Created
                || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    // If Ответ JSON
                    if (response?.Content?.Headers?.ContentType?.MediaType == "application/json")
                    {
                        // bool FirstName_IsValid = System.Text.RegularExpressions.Regex
                        // .IsMatch(jsonResponse, @"^([а-яА-ЯёЁ]+)(\d+)?$");

                        var jsonDeserialize = JsonConvert.DeserializeObject<ConsolidationListJson>(jsonResponse);
                        if (jsonDeserialize?.Success == true)
                        {
                            // var consolidationId = jsonDeserialize?.Data.;
                            // return consolidationId;
                            return 1;
                        }
                        else throw new Exception(" Error 2108040. SbsConsolidation No Created. "); // ToDo: Add jsonResponse to logFile
                    }
                    else if (response?.Content?.Headers?.ContentType?.MediaType == "text/html")
                        throw new Exception(" Error 27081413. SbsConsolidation No Created. HTML Ответ");
                    else // Неизвестный тип ответа
                        throw new Exception(" Error 27081414. SbsConsolidation No Created. Неизвестный тип ответа");
                }
                catch (Exception ex)
                {
                    throw new Exception(" Error:2108042: SbsConsolidation No Created. \n" + ex.Message);
                }
            }
            else
            {
                var jsonResponse = await response.Content.ReadAsStringAsync(); // ToDo: Add jsonResponse to logFile
                throw new Exception(" Error:2108041. SbsConsolidation No Created. \n");
            }
        }

        /// <summary>
        /// Show info consolidation
        /// </summary>
        /// <returns></returns>
        public async Task<ConsolidationItem> GetInfoConsolidationAsync(int Id)
        {
            // throw new NotImplementedException(); // UrlGetInfoConsolidation

            ConsolidationItem? result = new();
            string urlWithId = UrlGetInfoConsolidation.Replace("{id}", Id.ToString());
            var response = await httpClient.GetAsync(urlWithId);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    var jsonResponse = await response.Content.ReadAsStringAsync();
            //    //var jsonResponse = await _httpClient.GetStringAsync(requestUri);
            //    if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
            //    {
            //        //var restoredRoot = JsonSerializer.Deserialize<IEnumerable<JsonElement>>(jsonResponse);
            //        //var jsonDeserialize = JsonSerializer.Deserialize<TracksJson>(jsonResponse);
            //        var jsonDeserialize = JsonConvert.DeserializeObject<ConsolidationShowJson>(jsonResponse);
            //        var consolidationItem = jsonDeserialize?.Data;
            //        result = consolidationItem;
            //    }
            //}
            if (response.StatusCode == System.Net.HttpStatusCode.Created
                || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    // If Ответ JSON
                    if (response?.Content?.Headers?.ContentType?.MediaType == "application/json")
                    {
                        // bool FirstName_IsValid = System.Text.RegularExpressions.Regex
                        // .IsMatch(jsonResponse, @"^([а-яА-ЯёЁ]+)(\d+)?$");

                        var jsonDeserialize = JsonConvert.DeserializeObject<ConsolidationViewJson>(jsonResponse);
                        if (jsonDeserialize?.Success == true)
                        {
                            var consolidation = jsonDeserialize?.Data;
                            return consolidation;
                        }
                        else throw new Exception(" Error 28081211. "); // ToDo: Add jsonResponse to logFile
                    }
                    else if (response?.Content?.Headers?.ContentType?.MediaType == "text/html")
                        throw new Exception(" Error 28081212. HTML Ответ вместо json");
                    else // Неизвестный тип ответа
                        throw new Exception(" Error 28081213. Неизвестный тип ответа вместо json");
                }
                catch (Exception ex)
                {
                    throw new Exception(" Error:28081214 " + ex.Message);
                }
            }
            else
            {
                var jsonResponse = await response.Content.ReadAsStringAsync(); // ToDo: Add jsonResponse to logFile
                throw new Exception(" Error:28081215. ");
            }
        }

        /// <summary>
        /// Soft delete consolidation
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteConsolidationAsync(int Id)
        {
            // throw new NotImplementedException(); 
            bool result = false;
            string urlWithId = UrlDeleteConsolidation.Replace("{id}", Id.ToString());
            var response = await httpClient.GetAsync(urlWithId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                //var jsonResponse = await _httpClient.GetStringAsync(requestUri);
                if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
                {
                    var jsonDeserialize = JsonConvert.DeserializeObject<ConsolidationDeleteJson>(jsonResponse);
                    if (jsonDeserialize?.Success == true)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
