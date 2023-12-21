using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpressCa
{
    internal class JsonResult
    {
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Annotations
    {
        [JsonProperty("bold")]
        public bool Bold;

        [JsonProperty("italic")]
        public bool Italic;

        [JsonProperty("strikethrough")]
        public bool Strikethrough;

        [JsonProperty("underline")]
        public bool Underline;

        [JsonProperty("code")]
        public bool Code;

        [JsonProperty("color")]
        public string Color;
    }

    public class Block
    {
    }

    public class BulletedListItem
    {
        [JsonProperty("rich_text")]
        public List<RichText> RichText;

        [JsonProperty("color")]
        public string Color;
    }

    public class CreatedBy
    {
        [JsonProperty("object")]
        public string Object;

        [JsonProperty("id")]
        public string Id;
    }

    public class Heading1
    {
        [JsonProperty("rich_text")]
        public List<RichText> RichText;

        [JsonProperty("is_toggleable")]
        public bool IsToggleable;

        [JsonProperty("color")]
        public string Color;
    }

    public class Heading2
    {
        [JsonProperty("rich_text")]
        public List<RichText> RichText;

        [JsonProperty("is_toggleable")]
        public bool IsToggleable;

        [JsonProperty("color")]
        public string Color;
    }

    public class LastEditedBy
    {
        [JsonProperty("object")]
        public string Object;

        [JsonProperty("id")]
        public string Id;
    }

    public class NumberedListItem
    {
        [JsonProperty("rich_text")]
        public List<RichText> RichText;

        [JsonProperty("color")]
        public string Color;
    }

    public class Paragraph
    {
        [JsonProperty("rich_text")]
        public List<RichText> RichText;

        [JsonProperty("color")]
        public string Color;
    }

    public class Parent
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("page_id")]
        public string PageId;
    }

    public class Result
    {
        [JsonProperty("object")]
        public string Object;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("parent")]
        public Parent Parent;

        [JsonProperty("created_time")]
        public DateTime CreatedTime;

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime;

        [JsonProperty("created_by")]
        public CreatedBy CreatedBy;

        [JsonProperty("last_edited_by")]
        public LastEditedBy LastEditedBy;

        [JsonProperty("has_children")]
        public bool HasChildren;

        [JsonProperty("archived")]
        public bool Archived;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("heading_1")]
        public Heading1 Heading1;

        [JsonProperty("paragraph")]
        public Paragraph Paragraph;

        [JsonProperty("heading_2")]
        public Heading2 Heading2;

        [JsonProperty("numbered_list_item")]
        public NumberedListItem NumberedListItem;

        [JsonProperty("bulleted_list_item")]
        public BulletedListItem BulletedListItem;
    }

    public class RichText
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("text")]
        public Text Text;

        [JsonProperty("annotations")]
        public Annotations Annotations;

        [JsonProperty("plain_text")]
        public string PlainText;

        [JsonProperty("href")]
        public object Href;
    }

    public class Root
    {
        [JsonProperty("object")]
        public string Object;

        [JsonProperty("results")]
        public List<Result> Results;

        [JsonProperty("next_cursor")]
        public object NextCursor;

        [JsonProperty("has_more")]
        public bool HasMore;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("block")]
        public Block Block;

        [JsonProperty("developer_survey")]
        public string DeveloperSurvey;
    }

    public class Text
    {
        [JsonProperty("content")]
        public string Content;

        [JsonProperty("link")]
        public object Link;
    }


}
