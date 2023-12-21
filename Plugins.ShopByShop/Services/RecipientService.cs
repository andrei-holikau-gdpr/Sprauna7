using CoreBusiness.ShopByShop.Models;
using Newtonsoft.Json;
using System.Text.Json;
using UseCases.ShopByShop.InterfacesRepositories;

namespace Plugins.ShopByShop.Services
{
    public class RecipientService : ShopByShopService, IRecipientRepository
    {
        #region Private Fields Recipient

        // Получение всех треков пользователя
        private readonly string UrlGetRecipients = "/recipient";
        // Show info recipient
        private readonly string UrlGetInfoRecipient = "/recipient/{id}";
        // Create recipient
        private readonly string UrlCreateRecipientPost = "/recipient";
        // Update recipient
        private readonly string UrlUpdateRecipientPost = "/recipient/{id}";
        // Soft delete recipient
        private readonly string UrlDeleteRecipient = "/recipient/{id}";
        // Recover recipient
        private readonly string UrlRecoverRecipientGet = "/recipient/{id}/recover";

        #endregion
        //---
        #region Public Methods

        public RecipientService(
            ShopByShopSettings shopByShopConfig, 
            HttpClient? client = null)
                : base(shopByShopConfig, client)
        {
            UrlGetRecipients        = sbsConfig.UrlApi + UrlGetRecipients;
            UrlCreateRecipientPost  = sbsConfig.UrlApi + UrlCreateRecipientPost;
            UrlGetInfoRecipient     = sbsConfig.UrlApi + UrlGetInfoRecipient;
            UrlDeleteRecipient      = sbsConfig.UrlApi + UrlDeleteRecipient;
            UrlUpdateRecipientPost  = sbsConfig.UrlApi + UrlUpdateRecipientPost;
            UrlRecoverRecipientGet  = sbsConfig.UrlApi + UrlRecoverRecipientGet;
        }

        #pragma warning disable CS8603 //todo: #pragma warning disable CS8600 

        /// <summary>
        /// Получение всех треков пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RecipientItem>?> GetRecipientsAsync()
        {
            List<RecipientItem> result = new();
            var response = await httpClient.GetAsync(UrlGetRecipients);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                //var jsonResponse = await _httpClient.GetStringAsync(requestUri);
                if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
                {
                    //var restoredRoot = JsonSerializer.Deserialize<IEnumerable<JsonElement>>(jsonResponse);
                    var jsonDeserialize = JsonConvert.DeserializeObject<RecipientsJson>(jsonResponse);
                    var listItem = jsonDeserialize?.Data?.Recipients.Data ?? new();

                    result = listItem.ToList();
                }
            }
            return result;
        }
        /// <summary> Create recipient </summary>
        /// <returns></returns>
        public async Task<int?> CreateRecipientAsync(RecipientItem recipientItem)
        {
            #region Заглушки

            // ToDo: Убрать заглушки
            recipientItem.Birthdate = DateTime.Now;
            recipientItem.PassportDate = DateTime.Now;
            recipientItem.CreatedAt = DateTime.Now;
            recipientItem.UpdatedAt = DateTime.Now;
            //recipientItem.Iin = "456";
            recipientItem.Type = 1;

            #endregion
            var endpoint = UrlCreateRecipientPost;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            #region Fill Form Data

            var parameters = new MultipartFormDataContent
            {
               // { new StringContent(recipientItem.Email), "email" },
               // { new StringContent(recipientItem.Phone), "phone" },
               // { new StringContent(recipientItem.FirstName), "first_name" },
               // { new StringContent(recipientItem.LastName), "last_name" },
               // { new StringContent(recipientItem.MiddleName), "middle_name" },
               // { new StringContent(recipientItem.Birthdate?.ToString()), "birthdate" }, // ToDo: needs to be completed
               // { new StringContent(recipientItem.PassportSerial), "passport_serial" },
               // { new StringContent(recipientItem.PassportNumber), "passport_number" },
               // { new StringContent(recipientItem.PassportDate?.ToString("dd.MM.yyyy")), "passport_date" }, // ToDo: needs to be completed
               // { new StringContent(recipientItem.Type.ToString()), "type" },
               // { new StringContent(recipientItem.PassportFounder), "passport_founder" },
               // { new StringContent(recipientItem.Iin), "iin" },
               // { new StringContent(recipientItem.PassportAddress), "passport_address" },
               // { new StringContent(recipientItem.Region), "region" },
               // { new StringContent(recipientItem.Street), "street" },
               // { new StringContent(recipientItem.City), "city" },
               // { new StringContent(recipientItem.Building), "building" },
               // { new StringContent(recipientItem.Index), "index" },
               // { new StringContent(recipientItem?.CreatedAt?.ToString("dd.MM.yyyy")), "created_at" }
            };
            parameters.Add(new StringContent(recipientItem.Email), "email");
            parameters.Add(new StringContent(recipientItem.Phone), "phone");
            parameters.Add(new StringContent(recipientItem.FirstName), "first_name");
            parameters.Add(new StringContent(recipientItem.LastName), "last_name");
            parameters.Add(new StringContent(recipientItem.MiddleName), "middle_name");
            parameters.Add(new StringContent(recipientItem.PassportSerial), "passport_serial");
            parameters.Add(new StringContent(recipientItem.PassportNumber), "passport_number");
            parameters.Add(new StringContent(recipientItem.PassportFounder), "passport_founder");
            parameters.Add(new StringContent(recipientItem.PassportAddress), "passport_address");
            parameters.Add(new StringContent(recipientItem.Region), "region");
            parameters.Add(new StringContent(recipientItem.Street), "street");
            parameters.Add(new StringContent(recipientItem.City), "city");
            parameters.Add(new StringContent(recipientItem.Building), "building");
            parameters.Add(new StringContent(recipientItem.Index), "index");
            parameters.Add(new StringContent(recipientItem.Iin), "iin");
            parameters.Add(new StringContent(recipientItem.Type.ToString()), "type");

            parameters.Add(new StringContent(recipientItem.Birthdate?.ToString("dd.MM.yyyy")), "birthdate");
            parameters.Add(new StringContent(recipientItem.PassportDate?.ToString("dd.MM.yyyy")), "passport_date");
            parameters.Add(new StringContent(recipientItem.CreatedAt?.ToString("dd.MM.yyyy")), "created_at");

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

                        var jsonDeserialize = JsonConvert.DeserializeObject<RecipientCreateJson>(jsonResponse);
                        if (jsonDeserialize?.Success == true)
                        {
                            var recipientId = jsonDeserialize?.Data?.Recipient?.Id;
                            return recipientId;
                        }
                        else throw new Exception(" Error 2108040. SbsRecipient No Created. "); // ToDo: Add jsonResponse to logFile
                    }
                    else if (response?.Content?.Headers?.ContentType?.MediaType == "text/html")
                         throw new Exception(" Error 27081413. SbsRecipient No Created. HTML Ответ");
                    else // Неизвестный тип ответа
                         throw new Exception(" Error 27081414. SbsRecipient No Created. Неизвестный тип ответа");
                } 
                catch(Exception ex) {
                    throw new Exception(" Error:2108042: SbsRecipient No Created. \n" + ex.Message); }
            } else {                
                var jsonResponse = await response.Content.ReadAsStringAsync(); // ToDo: Add jsonResponse to logFile
                throw new Exception(" Error:2108041. SbsRecipient No Created. \n");
            }
        }

        /// <summary>
        /// Show info recipient
        /// </summary>
        /// <returns></returns>
        public async Task<RecipientItem> GetInfoRecipientAsync(int Id)
        {
            // throw new NotImplementedException(); // UrlGetInfoRecipient

            RecipientItem? result = new();
            string urlWithId = UrlGetInfoRecipient.Replace("{id}", Id.ToString());
            var response = await httpClient.GetAsync(urlWithId);
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    var jsonResponse = await response.Content.ReadAsStringAsync();
            //    //var jsonResponse = await _httpClient.GetStringAsync(requestUri);
            //    if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
            //    {
            //        //var restoredRoot = JsonSerializer.Deserialize<IEnumerable<JsonElement>>(jsonResponse);
            //        //var jsonDeserialize = JsonSerializer.Deserialize<TracksJson>(jsonResponse);
            //        var jsonDeserialize = JsonConvert.DeserializeObject<RecipientShowJson>(jsonResponse);
            //        var recipientItem = jsonDeserialize?.Data;
            //        result = recipientItem;
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

                        var jsonDeserialize = JsonConvert.DeserializeObject<RecipientCreateJson>(jsonResponse);
                        if (jsonDeserialize?.Success == true)
                        {
                            var recipient = jsonDeserialize?.Data?.Recipient;
                            return recipient;
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
        /// Soft delete recipient
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteRecipientAsync(int Id)
        {
            // throw new NotImplementedException(); 
            bool result = false;
            string urlWithId = UrlDeleteRecipient.Replace("{id}", Id.ToString());
            var response = await httpClient.GetAsync(urlWithId);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                //var jsonResponse = await _httpClient.GetStringAsync(requestUri);
                if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
                {
                    var jsonDeserialize = JsonConvert.DeserializeObject<RecipientDelJson>(jsonResponse);
                    if (jsonDeserialize?.Success == true)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Update recipient
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UpdateRecipientAsync(RecipientItem newRecipient)
        {
            // throw new NotImplementedException(); // UrlUpdateRecipientPost

            var oldTrackItem = GetInfoRecipientAsync(newRecipient.Id ?? 0);
            if (oldTrackItem == null) return false;
            else {
                var endpoint = UrlUpdateRecipientPost.Replace("{id}", newRecipient.Id.ToString());
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

                #region Fill Form Data
                var parameters = new MultipartFormDataContent
                {
                    { new StringContent("PUT"), "_method" },

                    { new StringContent(newRecipient.Email), "email" },
                    { new StringContent(newRecipient.Phone), "phone" },
                    { new StringContent(newRecipient.FirstName), "first_name" },
                    { new StringContent(newRecipient.LastName), "last_name" },
                    { new StringContent(newRecipient.MiddleName), "middle_name" },
                    { new StringContent(newRecipient?.Birthdate?.ToString("dd.MM.yyyy") 
                        ?? DateTime.Now.ToString("dd.MM.yyyy")), "birthdate" }, // ToDo: "05.05.1980" needs to be completed
                    { new StringContent(newRecipient.PassportNumber), "passport_number" },
                    { new StringContent(newRecipient.PassportSerial), "passport_serial" },
                    { new StringContent(newRecipient.PassportDate?.ToString("dd.MM.yyyy") 
                        ?? DateTime.Now.ToString("dd.MM.yyyy")), "passport_date" }, // ToDo: needs to be completed
                    { new StringContent(newRecipient.PassportFounder), "passport_founder" },
                    { new StringContent(newRecipient.Iin), "iin" },
                    { new StringContent(newRecipient.PassportAddress), "passport_address" },
                    { new StringContent(newRecipient.Region), "region" },
                    { new StringContent(newRecipient.Street), "street" },
                    { new StringContent(newRecipient.City), "city" },
                    { new StringContent(newRecipient.Building), "building" },
                    { new StringContent(newRecipient.Index), "index" },
                    { new StringContent(newRecipient.UpdatedAt?.ToString("dd.MM.yyyy") 
                        ?? DateTime.Now.ToString("dd.MM.yyyy")), "updated_at" }

                    // { new StringContent(newRecipient.Type.ToString()), "type" },
                };

                parameters.Add(new StringContent(newRecipient?.Type?.ToString() ?? "0"), "type");
                #endregion

                // request.Content = content;

                // request.Headers.Add("Accept", "application/json");
                // request.Headers.Add("Authorization", "Bearer 1|27DetjHTbItGQJZoJUTfSZnnBo9DTmlWxBBQHvh5");

                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {sbsConfig.Token}");

                var response = await client.PostAsync(endpoint, parameters);

                //if (response.StatusCode == System.Net.HttpStatusCode.Created
                //    || response.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    var jsonResponse = await response.Content.ReadAsStringAsync();

                //    var jsonDeserialize = JsonConvert.DeserializeObject<TrackShowJson>(jsonResponse);
                //    if (jsonDeserialize?.Success != true)
                //        throw new Exception("Error:2108347. SbsRecipient No Edit. "); // ToDo: Add jsonResponse to logFile
                //    else
                //        return true;
                //}
                //else
                //{ 
                //    var jsonResponse = await response.Content.ReadAsStringAsync(); // ToDo: Add jsonResponse to logFile
                //    throw new Exception("Error:2108348. SbsRecipient No Edit ");
                //}

                if (response.StatusCode == System.Net.HttpStatusCode.Created
                || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    try {
                        // If Ответ JSON
                        if (response?.Content?.Headers?.ContentType?.MediaType == "application/json")
                        {
                            // bool FirstName_IsValid = System.Text.RegularExpressions.Regex
                            // .IsMatch(jsonResponse, @"^([а-яА-ЯёЁ]+)(\d+)?$");

                            var jsonDeserialize = JsonConvert.DeserializeObject<RecipientCreateJson>(jsonResponse);
                            if (jsonDeserialize?.Success == true)
                            {
                                var recipientId = jsonDeserialize?.Data?.Recipient?.Id;
                                return (recipientId != null) && (recipientId > 0);
                            }
                            else throw new Exception(" Error 28081221. SbsRecipient No Update. "); // ToDo: Add jsonResponse to logFile
                        }
                        else if (response?.Content?.Headers?.ContentType?.MediaType == "text/html")
                            throw new Exception(" Error 28081222. SbsRecipient No Update. HTML Ответ вместо json ");
                        else // Неизвестный тип ответа
                            throw new Exception(" Error 28081223. SbsRecipient No Update. Неизвестный тип ответа  вместо json ");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(" Error:28081224: SbsRecipient No Update. " + ex.Message);
                    }
                }
                else
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync(); // ToDo: Add jsonResponse to logFile
                    throw new Exception(" Error:28081225. SbsRecipient No Update. ");
                }
            }            
        }

        /// <summary>
        /// Recover recipient
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RecovereRecipientAsync(int id)
        {
            throw new NotImplementedException();

            var response = await httpClient.GetAsync(UrlRecoverRecipientGet);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

            }
        }

#pragma warning restore CS8603

        #endregion
        //---
    }
}