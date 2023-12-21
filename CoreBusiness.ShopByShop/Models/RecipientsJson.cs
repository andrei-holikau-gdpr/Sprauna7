using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

#pragma warning disable CS8618

namespace CoreBusiness.ShopByShop.Models
{
    public class RecipientsJson
    {
        public bool? Success;
        public RecipientJsonData? Data;
        public string? Message;
    }

    public class RecipientShowJson
    {
        public bool? Success;
        public RecipientItem? Data;
        public string? Message;
    }

    public class RecipientDelJson
    {
        [JsonProperty("success")]
        public bool? Success;

        [JsonProperty("data")]
        public List<object> Data;

        [JsonProperty("message")]
        public string Message;
    }

    public class RecipientJsonData
    {
        [JsonProperty("recipients")]
        public Recipients Recipients;
    }

    public class Recipients
    {
        // [JsonProperty("data")]
        public List<RecipientItem> Data;

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

    public class RecipientItem
    {
        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("phone")]
        public string Phone;

        [JsonProperty("first_name")]
        public string FirstName;

        [JsonProperty("middle_name")]
        public string MiddleName;

        [JsonProperty("last_name")]
        public string LastName;

        [JsonProperty("birthdate")]
        public DateTime? Birthdate;

        [JsonProperty("passport_serial")]
        public string PassportSerial;

        [JsonProperty("passport_number")]
        public string PassportNumber;

        [JsonProperty("passport_date")]
        public DateTime? PassportDate;

        [JsonProperty("type")]
        public int? Type;

        [JsonProperty("passport_founder")]
        public string PassportFounder;

        [JsonProperty("iin")]
        public string Iin;

        [JsonProperty("passport_address")]
        public string PassportAddress;

        [JsonProperty("hide")]
        public int Hide = 0;

        [JsonProperty("created_at")]
        public DateTime? CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt;

        [JsonProperty("region")]
        public string Region;

        [JsonProperty("street")]
        public string Street;

        [JsonProperty("city")]
        public string City;

        [JsonProperty("building")]
        public string Building;

        [JsonProperty("corpus")]
        public string Corpus;

        [JsonProperty("apartment")]
        public string Apartment;

        [JsonProperty("index")]
        public string Index;

        [JsonProperty("fullname")]
        public string Fullname;

        [JsonProperty("passport")]
        public string Passport;

        [JsonProperty("passport_human_date")]
        public string PassportHumanDate;

        [JsonProperty("passport_date_form")]
        public string PassportDateForm;

        [JsonProperty("birthdate_form")]
        public string BirthdateForm;
    }
}

#pragma warning restore CS8618