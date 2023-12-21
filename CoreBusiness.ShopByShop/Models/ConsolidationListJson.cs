namespace CoreBusiness.ShopByShop.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class ConsolidationListJson
    {
        [JsonProperty("success")]
        public bool? Success;

        [JsonProperty("data")]
        public Data_Consolidation Data;

        [JsonProperty("message")]
        public string Message;
    }

    public class Data_Consolidation
    {
        [JsonProperty("tracks")]
        public Tracks_Consolidation Tracks { get; set; }
    }

    public class Tracks_Consolidation
    {
        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("data")]
        public List<ConsolidationItem> Data { get; set; }

        [JsonProperty("first_page_url")]
        public string FirstPageUrl { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("last_page")]
        public long LastPage { get; set; }

        [JsonProperty("last_page_url")]
        public string LastPageUrl { get; set; }

        [JsonProperty("next_page_url")]
        public object NextPageUrl { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("prev_page_url")]
        public object PrevPageUrl { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class ConsolidationItem
    {
        [JsonProperty("additional_services")]
        public object AdditionalServices { get; set; }

        [JsonProperty("additional_services_price")]
        public object AdditionalServicesPrice { get; set; }

        [JsonProperty("additionalServicesText", NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalServicesText { get; set; }

        [JsonProperty("address")]
        public object Address { get; set; }

        [JsonProperty("agree", NullValueHandling = NullValueHandling.Ignore)]
        public long? Agree { get; set; }

        [JsonProperty("apartment")]
        public object Apartment { get; set; }

        [JsonProperty("cdek_number")]
        public object CdekNumber { get; set; }

        [JsonProperty("check_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? CheckSize { get; set; }

        [JsonProperty("city")]
        public object City { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }

        [JsonProperty("comment_amo")]
        public object CommentAmo { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; set; }

        [JsonProperty("delivery_type", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeliveryType { get; set; }

        [JsonProperty("hide", NullValueHandling = NullValueHandling.Ignore)]
        public long? Hide { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("insurence", NullValueHandling = NullValueHandling.Ignore)]
        public long? Insurence { get; set; }

        [JsonProperty("invoice_uuid")]
        public object InvoiceUuid { get; set; }

        [JsonProperty("packing", NullValueHandling = NullValueHandling.Ignore)]
        public long? Packing { get; set; }

        [JsonProperty("photo", NullValueHandling = NullValueHandling.Ignore)]
        public long? Photo { get; set; }

        [JsonProperty("price")]
        public object Price { get; set; }

        [JsonProperty("priceReal", NullValueHandling = NullValueHandling.Ignore)]
        public long? PriceReal { get; set; }

        [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.List<Product> Products { get; set; }

        [JsonProperty("pvz", NullValueHandling = NullValueHandling.Ignore)]
        public string Pvz { get; set; }

        [JsonProperty("pvzAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string PvzAddress { get; set; }

        [JsonProperty("recipient_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? RecipientId { get; set; }

        [JsonProperty("shop_number", NullValueHandling = NullValueHandling.Ignore)]
        public string ShopNumber { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public long? Status { get; set; }

        [JsonProperty("statusLabel", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusLabel { get; set; }

        [JsonProperty("store", NullValueHandling = NullValueHandling.Ignore)]
        public string Store { get; set; }

        [JsonProperty("surname", NullValueHandling = NullValueHandling.Ignore)]
        public string Surname { get; set; }

        [JsonProperty("track_status")]
        public object TrackStatus { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public long? Type { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; set; }

        [JsonProperty("user_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty("wait", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wait { get; set; }

        [JsonProperty("weight")]
        public object Weight { get; set; }
    }

    public partial class Product_Consolidation
    {
        [JsonProperty("code_tnved")]
        public object CodeTnved { get; set; }

        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
        public string Link { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("name_tnved")]
        public object NameTnved { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public long? Price { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }

        [JsonProperty("track_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? TrackId { get; set; }
    }
}