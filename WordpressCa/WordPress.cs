using WordPressPCL;
using WordPressPCL.Models;
using System.Windows;
using System.Text;
using System.Reflection.PortableExecutable;
using Newtonsoft.Json.Linq;
using WordPressPCL.Client;
using Newtonsoft.Json;

namespace WordpressCa
{
    public class DataObject
    {
        public string? Title;
        public string? Description;
        public string? Excerpt;
        public string? Content;
        public string? Slug;
        public List<int> Categories = new();
        public List<int> Tags = new();
        public int PostId;
    }

    public static class WordPress
    {

        public static async Task CreateOrUpdatePost(DataObject dataObj)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://test2023.data-privacy-office.eu/wp-json/wp/v2/posts/1429");
            request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOi8vdGVzdDIwMjMuZGF0YS1wcml2YWN5LW9mZmljZS5ldSIsImlhdCI6MTY5NTcxMzc5NSwibmJmIjoxNjk1NzEzNzk1LCJleHAiOjE2OTYzMTg1OTUsImRhdGEiOnsidXNlciI6eyJpZCI6IjEifX19.Hgg8bTIqHZP8N-ZOGRxJRg7T12EOmZ53785Oy_dkb8g");
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(dataObj.Title), "title");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            //Console.WriteLine();

            var resultJson = await response.Content.ReadAsStringAsync();

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(resultJson);

            await ConsoleWriteLineResult(myDeserializedClass);
        }

        public static async Task ConsoleWriteLineResult(Root myDeserializedClass)
        {
            foreach (var item in myDeserializedClass.Results)
            {
                Console.WriteLine(item.Heading1.RichText.First().PlainText);
            }
        }


        public static async Task CreateOrUpdatePost2(DataObject dataObj)
        {
            // Get valid WordPress Client
           // WordPressClient wpClient = new WordPressClient("https://chimstirka.by/wp-json/");
            WordPressClient wpClient = new WordPressClient("https://chimstirka.by/wp-json/api/v1/token");

            //Basic Auth
           // wpClient.Auth.UseBasicAuth("AppUser", "CgTD djwm PhYa G6bq b3ke MJmIw");

            //Or, Bearer Auth using JWT tokens
            wpClient.Auth.UseBearerAuth(JWTPlugin.JWTAuthByEnriqueChavez);
            wpClient.Auth.RequestJWTokenAsync("AppUser", "CgTD djwm PhYa G6bq b3ke MJmIw");
            var isValidToken = wpClient.Auth.IsValidJWTokenAsync;

            //Create and Set Post object
            var post = new Post
            {
                Title = new Title(dataObj.Title),
                Meta = new Description(dataObj.Description),
                Excerpt = new Excerpt(dataObj.Excerpt),
                Content = new Content(dataObj.Content),
                //slug should be in lower case with hypen(-) separator 
                Slug = dataObj.Slug
            };

            // Assign one or more Categories, if any
            if (dataObj.Categories.Count > 0)
            {
                post.Categories = dataObj.Categories;
            }

            // Assign one or more Tags, if any
            if (dataObj.Tags.Count > 0)
            {
                post.Tags = dataObj.Tags;
            }

            if (dataObj.PostId == 0)
            {
                // if you want to hide comment section
                post.CommentStatus = OpenStatus.Closed;
                // Set it to draft section if you want to review and then publish
                post.Status = Status.Draft;
                // Create and get new the post id
                // dataObj.PostId = wpClient.Posts.CreateAsync(post).Result.Id;

                // read Note section below - Why update the Post again?
                // await wpClient.Posts.UpdateAsync(post);

                 HttpClient httpClient = new HttpClient();
                Uri requestUri = new Uri($"https://chimstirka.by/wp-json/wp/v2/pages/2370"); // {dataObj.PostId}");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, requestUri);
                request.Headers.Add("Content-Type", "application/json");

                // httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); // sbsConfig.Accept);
                //httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {sbsConfig.Token}");

                string json = @"{
                    ""title"": ""Новое название страницы"",
                    ""content"": ""Новое содержимое страницы"",
                    ""pagebuilder"": ""elementor""
                }";

                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.SendAsync(request);


                if (response.IsSuccessStatusCode)
                {
                    // Обновление страницы выполнено успешно
                }
                else
                {
                    // Обновление страницы не удалось
                }
            }
            else
            {
                // check the status of post (draft or publish) and then update
                if (IsPostDraftStatus(wpClient, dataObj.PostId))
                {
                    post.Status = Status.Draft;
                }

                await wpClient.Posts.UpdateAsync(post);
            }
        }

        private static bool IsPostDraftStatus(WordPressClient client, int postId)
        {
            var result = client.Posts.GetByIDAsync(postId, true, true).Result;

            if (result.Status == Status.Draft)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //private static string GenerateContent(NextPosts dbContent)
        //{
        //    // sample content
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<h2> " + dbContent.Header + "</h2>");
        //    sb.Append("<div>");
        //    sb.Append(dbContent.Column2 + "<br>");
        //    sb.Append("<table>");
        //    sb.Append("<tr><td>" + dbContent.Column3 + "</td></tr>");
        //    sb.Append("</table>");
        //    sb.Append("</div>");

        //    return sb.ToString();
        //}
    }
}
