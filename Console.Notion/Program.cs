using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

#pragma warning disable CS8602,  CS8618, CS8600
class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();

        //var request = new HttpRequestMessage
        //{
        //    Method = HttpMethod.Get,
        //    RequestUri = new Uri("https://api.notion.com/v1/pages/374c8d04e94548fab0be37c8f0d15af5"),
        //    Headers =
        //    {
        //        { "Notion-Version", "2022-06-28" },
        //        { "Bearer", "secret_3UfyLbNHaE7K4b2keBVJtjac382LiTwPj9VERctVTyT" }
        //    },
        //};
        //using (var response = await client.SendAsync(request))
        //{
        //    response.EnsureSuccessStatusCode();
        //    var body = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine(body);
        //    Console.ReadLine();
        //}

        client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "secret_3UfyLbNHaE7K4b2keBVJtjac382LiTwPj9VERctVTyT");
        client.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");

        var jsonResponse = await client.GetStringAsync("https://api.notion.com/v1/blocks/e3ef02ada74f432fb9050057a107adba/children?page_size=100");
        // Parse JSON response https://metanit.com/sharp/tutorial/6.5.php

        if (jsonResponse != null && !string.IsNullOrWhiteSpace(jsonResponse))
        {
            //var json = JsonSerializer.Deserialize<Root>(jsonResponse);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(jsonResponse);

            foreach(var Result in myDeserializedClass.Results)
            {
                switch (Result.Type) {
                    case "code":
                        {
                            Console.WriteLine(Result.Code.RichText[0].PlainText); break;
                        }
                    case "paragraph":
                        {
                            Console.WriteLine(Result.Paragraph.RichText[0].PlainText); break;
                        }
                }
            }    
        }
        Console.ReadLine();
    }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Annotations
{
    [JsonProperty("bold", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Bold;

    [JsonProperty("italic", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Italic;

    [JsonProperty("strikethrough", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Strikethrough;

    [JsonProperty("underline", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Underline;

    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Code;

    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string Color;
}

public class Block
{
}

public class Code
{
    [JsonProperty("caption", NullValueHandling = NullValueHandling.Ignore)]
    public List<object> Caption;

    [JsonProperty("rich_text", NullValueHandling = NullValueHandling.Ignore)]
    public List<RichText> RichText;

    [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
    public string Language;
}

public class CreatedBy
{
    [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
    public string Object;

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id;
}

public class LastEditedBy
{
    [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
    public string Object;

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id;
}

public class Paragraph
{
    [JsonProperty("rich_text", NullValueHandling = NullValueHandling.Ignore)]
    public List<RichText> RichText;

    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string Color;
}

public class Parent
{
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type;

    [JsonProperty("page_id", NullValueHandling = NullValueHandling.Ignore)]
    public string PageId;
}

public class Result
{
    [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
    public string Object;

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id;

    [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
    public Parent Parent;

    [JsonProperty("created_time", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? CreatedTime;

    [JsonProperty("last_edited_time", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? LastEditedTime;

    [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
    public CreatedBy CreatedBy;

    [JsonProperty("last_edited_by", NullValueHandling = NullValueHandling.Ignore)]
    public LastEditedBy LastEditedBy;

    [JsonProperty("has_children", NullValueHandling = NullValueHandling.Ignore)]
    public bool? HasChildren;

    [JsonProperty("archived", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Archived;

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type;

    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public Code Code;

    [JsonProperty("paragraph", NullValueHandling = NullValueHandling.Ignore)]
    public Paragraph Paragraph;
}

public class RichText
{
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type;

    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    public Text Text;

    [JsonProperty("annotations", NullValueHandling = NullValueHandling.Ignore)]
    public Annotations Annotations;

    [JsonProperty("plain_text", NullValueHandling = NullValueHandling.Ignore)]
    public string PlainText;

    [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
    public object Href;
}

public class Root
{
    [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
    public string Object;

    [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
    public List<Result> Results;

    [JsonProperty("next_cursor", NullValueHandling = NullValueHandling.Ignore)]
    public object NextCursor;

    [JsonProperty("has_more", NullValueHandling = NullValueHandling.Ignore)]
    public bool? HasMore;

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type;

    [JsonProperty("block", NullValueHandling = NullValueHandling.Ignore)]
    public Block Block;

    [JsonProperty("developer_survey", NullValueHandling = NullValueHandling.Ignore)]
    public string DeveloperSurvey;
}

public class Text
{
    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public string Content;

    [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
    public object Link;
}

