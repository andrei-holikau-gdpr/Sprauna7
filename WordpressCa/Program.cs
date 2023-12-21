// See https://aka.ms/new-console-template for more information


using WordpressCa;

Console.WriteLine("Start");

DataObject dataObject = new();
dataObject.Title = "2109";
dataObject.Description = "2109";
dataObject.Excerpt = "2109";
dataObject.Content = "2109";
dataObject.Slug = "2110";

WordPress.CreateOrUpdatePost(dataObject);

Console.WriteLine($"dataObject.PostId = {dataObject.PostId}");
Console.WriteLine("End");
Console.ReadLine();