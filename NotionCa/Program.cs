using Microsoft.Extensions.Logging;
using Notion;
using Notion.Client;

// Инициализация клиента Notion
var client = NotionClientFactory.Create(new ClientOptions
{
    AuthToken = "secret_3UfyLbNHaE7K4b2keBVJtjac382LiTwPj9VERctVTyT"
});
//var usersList = await client.Users.ListAsync();
//Console.WriteLine("Users");
//foreach (var user in usersList.Results) {
//    Console.WriteLine(user.Name);
//}
//Console.WriteLine("---");
Console.WriteLine("");

var databasesQueryParameters = new DatabasesQueryParameters();
databasesQueryParameters.Filter = new SelectFilter("Number", equal: "2");
var databaseId = "879c9680ea624721a5ef7ef2294febfd";
var queryResult = await client.Databases.QueryAsync(databaseId, databasesQueryParameters);


Console.WriteLine("Page Count: " + queryResult.Results.Count);
Console.WriteLine("");
foreach (var result in queryResult.Results/*[0].Properties*/)
{
    
    foreach (var property in result.Properties)
    {
        // Console.WriteLine("Title: " + property.Key + " " + GetValue(property.Value));
        // Console.WriteLine("Type = " + property.Value.GetType());

        if (property.Value.Type == PropertyValueType.MultiSelect) {
            var multiSelectPropertyValue = (MultiSelectPropertyValue)property.Value;
            foreach (var multiSelect in multiSelectPropertyValue.MultiSelect)
            {
                Console.WriteLine("MultiSelect \n\t" + multiSelect.Name);
            }
        } else if (property.Value.Type == PropertyValueType.Title) {
            var titlePropertyValue = (TitlePropertyValue)property.Value;
            foreach (var title in titlePropertyValue.Title)
            {
                Console.WriteLine("Title \n\t" + title.PlainText);
            }
        } else if (property.Value.Type == PropertyValueType.Number) {
            var numberPropertyValue = (NumberPropertyValue)property.Value;
            double? number = numberPropertyValue.Number;
            {
                Console.WriteLine("Number \n\t" + number);
            }
        } else
        {
            Console.WriteLine("Other type...");
        }
        
    }
    Console.WriteLine("---");
}
Console.WriteLine();
Console.WriteLine("End");

object GetValue(PropertyValue p)
{
    switch (p)
    {
        case RichTextPropertyValue richTextPropertyValue:
            return richTextPropertyValue.RichText.FirstOrDefault()?.PlainText;
        default:
            return null;
    }
}
