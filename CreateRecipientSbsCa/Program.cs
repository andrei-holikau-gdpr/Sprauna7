using System.Net.Http.Headers;

var client = new HttpClient();
var requestContent = new MultipartFormDataContent();
requestContent.Add(new StringContent("Сергей"), "first_name");
requestContent.Add(new StringContent("Иванов"), "last_name");
requestContent.Add(new StringContent("Иванович"), "middle_name");
requestContent.Add(new StringContent("+375293453253"), "phone");
requestContent.Add(new StringContent("05.05.1980"), "birthdate");
requestContent.Add(new StringContent("КВ"), "passport_serial");
requestContent.Add(new StringContent("345"), "passport_number");
requestContent.Add(new StringContent("05.05.2020"), "passport_date");
requestContent.Add(new StringContent("РОВД"), "passport_founder");
requestContent.Add(new StringContent("456"), "iin");
requestContent.Add(new StringContent("Минск 123"), "passport_address");
requestContent.Add(new StringContent("Минск обл"), "region");
requestContent.Add(new StringContent("Ленинская"), "street");
requestContent.Add(new StringContent("Минск"), "city");
requestContent.Add(new StringContent("23"), "building");
requestContent.Add(new StringContent("234234"), "index");
requestContent.Add(new StringContent("05.05.2020"), "created_at");
requestContent.Add(new StringContent("1"), "type");
requestContent.Add(new StringContent("test-nov@gmail.com"), "email");
var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://devprofile.shopbyshop.by/api/v1/recipient");
requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "1|27DetjHTbItGQJZoJUTfSZnnBo9DTmlWxBBQHvh5");
requestMessage.Content = requestContent;
var response = await client.SendAsync(requestMessage);

var jsonResponse1 = await response.Content.ReadAsStringAsync();

Console.WriteLine(jsonResponse1);

if (response.StatusCode == System.Net.HttpStatusCode.Created
                || response.StatusCode == System.Net.HttpStatusCode.OK)
{
    var jsonResponse = await response.Content.ReadAsStringAsync();
    try
    {
        // If Ответ JSON
        if (response.Content.Headers.ContentType.MediaType == "application/json")
        {
            // bool FirstName_IsValid = System.Text.RegularExpressions.Regex
            // .IsMatch(jsonResponse, @"^([а-яА-ЯёЁ]+)(\d+)?$");

            /*
            var jsonDeserialize = JsonConvert.DeserializeObject<TrackShowJson>(jsonResponse);
            if (jsonDeserialize?.Success == true)
            {
                var recipientId = jsonDeserialize?.Data?.Id;
                return recipientId;
            }
            else throw new Exception(" Error 2108040. SbsRecipient No Created. "); // ToDo: Add jsonResponse to logFile
            */
        }
        else if (response.Content.Headers.ContentType.MediaType == "text/html")
            throw new Exception(" Error 27081413. SbsRecipient No Created. HTML Ответ");
        else // Неизвестный тип ответа
            throw new Exception(" Error 27081414. SbsRecipient No Created. Неизвестный тип ответа");
    }
    catch (Exception ex)
    {
        throw new Exception(" Error:2108042: SbsRecipient No Created. \n" + ex.Message);
    }
}
else
{
    var jsonResponse = await response.Content.ReadAsStringAsync(); // ToDo: Add jsonResponse to logFile
    throw new Exception(" Error:2108041. SbsRecipient No Created. \n");
}
