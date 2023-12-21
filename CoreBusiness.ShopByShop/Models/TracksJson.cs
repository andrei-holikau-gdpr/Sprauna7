using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

#pragma warning disable CS8618

namespace CoreBusiness.ShopByShop.Models
{
    public class Errors
    {
        [JsonProperty("user_name")]
        public List<string>? UserName;

        [JsonProperty("code")]
        public List<string>? Code;

        [JsonProperty("pvz")]
        public List<string>? Pvz;
    }

    public class TrackItem
    {
        [JsonProperty("id")]
        public int? Id;
        public string Code;
        public int? RecipientId;
        public object ConsolidationId;
        public object LeadId;
        public int? DeliveryType = 2;
        public int? Status;
        public int? Hide;        
        [JsonProperty("user_name")] //[JsonPropertyName("user_name")]
        public string UserName;
        public string Surname;
        public string Pvz;
        public object Address;
        public object City;
        public string Comment;
        public object Price;
        public string Store;
        public int? Wait;
        public object Weight;
        public int? Type;
        public DateTime? CreatedAt;
        public DateTime? UpdatedAt;
        public string ShopNumber;
        public object Apartment;
        public object CdekNumber;
        public object PaymentToken;
        public object CommentAmo;
        public object TrackStatus;
        public object AdditionalServices;
        public object AdditionalServicesPrice;
        public int? Agree;
        public int? Insurence;
        public int? Photo;
        public int? CheckSize;
        public int? Packing;
        public object Invoice;
        public string StatusLabel;
        public int? PriceReal;
        public string AdditionalServicesText;
        public string PvzAddress;
        public List<object> File;
        public List<Product> Products;
    }

    public class Product
    {
        public int? Id;
        public int? TrackId;
        public string Name;
        public int? Count;
        public double? Price;
        public string Link;
        public double? Total;
        public object CodeTnved;
        public object NameTnved;
    }

    public class TracksJson
    {
        public bool? Success;
        public TrackJsonData? Data;
        public string? Message;
    }

    public class TrackShowJson
    {
        public bool? Success;
        public TrackItem? Data;
        public string? Message;
    }

    public class TrackDelJson
    {
        [JsonProperty("success")]
        public bool? Success;

        [JsonProperty("data")]
        public List<object> Data;

        [JsonProperty("message")]
        public string Message;
    }

    public class Tracks
    {
        public List<TrackItem> Data;

        public int? CurrentPage;
        public string FirstPageUrl;
        public int? From;
        public int? LastPage;
        public string LastPageUrl;
        public object NextPageUrl;
        public string Path;
        public int? PerPage;
        public object PrevPageUrl;
        public int? To;
        public int? Total;
    }

    public class TrackJsonData
    {
        public Tracks? Tracks;
    }

    public class TracksJson_2
    {
        [JsonPropertyName("success")]
        public bool? Success;

        [JsonPropertyName("data")]
        public TrackJsonData Data;

        [JsonPropertyName("message")]
        public string Message;
    }

    public class TrackJsonData_2
    {
        //[JsonPropertyName("tracks")]
        //public Tracks Tracks;
    }

    public class Tracks_2
    {
        //    [JsonPropertyName("current_page")]
        //    public int? CurrentPage;

        //    [JsonPropertyName("data")]
        //    public List<TrackItem> TrackItems;

        //    [JsonPropertyName("first_page_url")]
        //    public string FirstPageUrl;

        //    [JsonPropertyName("from")]
        //    public int? From;

        //    [JsonPropertyName("last_page")]
        //    public int? LastPage;

        //    [JsonPropertyName("last_page_url")]
        //    public string LastPageUrl;

        //    [JsonPropertyName("next_page_url")]
        //    public object NextPageUrl;

        //    [JsonPropertyName("path")]
        //    public string Path;

        //    [JsonPropertyName("per_page")]
        //    public int? PerPage;

        //    [JsonPropertyName("prev_page_url")]
        //    public object PrevPageUrl;

        //    [JsonPropertyName("to")]
        //    public int? To;

        //    [JsonPropertyName("total")]
        //    public int? Total;
    }

    //public class TrackItem
    //{ 
    //    [JsonPropertyName("id")]
    //    public int? Id;

    //    [JsonPropertyName("code")]
    //    public string Code;

    //    [JsonPropertyName("recipient_id")]
    //    public int? RecipientId;

    //    [JsonPropertyName("consolidation_id")]
    //    public object ConsolidationId;

    //    [JsonPropertyName("lead_id")]
    //    public object LeadId;

    //    [JsonPropertyName("delivery_type")]
    //    public int? DeliveryType;

    //    [JsonPropertyName("status")]
    //    public int? Status;

    //    [JsonPropertyName("hide")]
    //    public int? Hide;

    //    [JsonPropertyName("user_name")]
    //    public string UserName;

    //    [JsonPropertyName("surname")]
    //    public string Surname;

    //    [JsonPropertyName("pvz")]
    //    public string Pvz;

    //    [JsonPropertyName("address")]
    //    public object Address;

    //    [JsonPropertyName("city")]
    //    public object City;

    //    [JsonPropertyName("comment")]
    //    public string Comment;

    //    [JsonPropertyName("price")]
    //    public object Price;

    //    [JsonPropertyName("store")]
    //    public string Store;

    //    [JsonPropertyName("wait")]
    //    public int? Wait;

    //    [JsonPropertyName("weight")]
    //    public object Weight;

    //    [JsonPropertyName("type")]
    //    public int? Type;

    //    [JsonPropertyName("created_at")]
    //    public DateTime? CreatedAt;

    //    [JsonPropertyName("updated_at")]
    //    public DateTime? UpdatedAt;

    //    [JsonPropertyName("shop_number")]
    //    public string ShopNumber;

    //    [JsonPropertyName("apartment")]
    //    public object Apartment;

    //    [JsonPropertyName("cdek_number")]
    //    public object CdekNumber;

    //    [JsonPropertyName("payment_token")]
    //    public object PaymentToken;

    //    [JsonPropertyName("comment_amo")]
    //    public object CommentAmo;

    //    [JsonPropertyName("track_status")]
    //    public object TrackStatus;

    //    [JsonPropertyName("additional_services")]
    //    public object AdditionalServices;

    //    [JsonPropertyName("additional_services_price")]
    //    public object AdditionalServicesPrice;

    //    [JsonPropertyName("agree")]
    //    public int? Agree;

    //    [JsonPropertyName("insurence")]
    //    public int? Insurence;

    //    [JsonPropertyName("photo")]
    //    public int? Photo;

    //    [JsonPropertyName("check_size")]
    //    public int? CheckSize;

    //    [JsonPropertyName("packing")]
    //    public int? Packing;

    //    [JsonPropertyName("invoice")]
    //    public object Invoice;

    //    [JsonPropertyName("statusLabel")]
    //    public string StatusLabel;

    //    [JsonPropertyName("priceReal")]
    //    public int? PriceReal;

    //    [JsonPropertyName("additionalServicesText")]
    //    public string AdditionalServicesText;

    //    [JsonPropertyName("pvzAddress")]
    //    public string PvzAddress;

    //    [JsonPropertyName("file")]
    //    public List<object> File;

    //    [JsonPropertyName("products")]
    //    public List<Product> Products;
    //}

    //public class Product
    //{
    //    [JsonPropertyName("id")]
    //    public int? Id;

    //    [JsonPropertyName("track_id")]
    //    public int? TrackId;

    //    [JsonPropertyName("name")]
    //    public string Name;

    //    [JsonPropertyName("count")]
    //    public int? Count;

    //    [JsonPropertyName("price")]
    //    public double? Price;

    //    [JsonPropertyName("link")]
    //    public string Link;

    //    [JsonPropertyName("total")]
    //    public double? Total;

    //    [JsonPropertyName("code_tnved")]
    //    public object CodeTnved;

    //    [JsonPropertyName("name_tnved")]
    //    public object NameTnved;
    //}

}

#pragma warning restore CS8618