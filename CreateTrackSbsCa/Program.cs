var endpoint = "http://devprofile.shopbyshop.by/api/v1/track";

var client = new HttpClient();

var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

var content = new MultipartFormDataContent();

content.Add(new StringContent("613"), "code");
content.Add(new StringContent("2013"), "recipient_id");
content.Add(new StringContent("UserName"), "user_name");
content.Add(new StringContent("surname"), "surname");
content.Add(new StringContent("70130010"), "pvz");
content.Add(new StringContent("TestStore"), "store");
content.Add(new StringContent("1"), "wait");
content.Add(new StringContent("1"), "agree");
content.Add(new StringContent("2"), "delivery_type");
content.Add(new StringContent("1"), "agree2");
content.Add(new StringContent("1"), "agree3");

content.Add(new ByteArrayContent(File.ReadAllBytes("C:/48.jpg")), "invoice", "48.jpg");
content.Add(new StringContent("KAWA ZIARNISTA 1KG NICARAGUA ARABICA ŚWIEŻO PALONA"), "item_list[0][name]");
content.Add(new StringContent("1"), "item_list[0][count]");
content.Add(new StringContent("https://allegro.pl/oferta/kawa-ziarnista-1kg"), "item_list[0][link]");
content.Add(new StringContent("55.99"), "item_list[0][price]");
content.Add(new ByteArrayContent(File.ReadAllBytes("C:/48.jpg")), "invoice[0][file]", "48.jpg");

request.Content = content;

request.Headers.Add("Accept", "application/json");
request.Headers.Add("Authorization", "Bearer 1|27DetjHTbItGQJZoJUTfSZnnBo9DTmlWxBBQHvh5");

var response = await client.SendAsync(request);

var responseContent = await response.Content.ReadAsStringAsync();
Console.ReadLine();