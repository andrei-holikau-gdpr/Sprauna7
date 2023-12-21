using Newtonsoft.Json;

namespace CoreBusiness.ExpressPay
{
    public class InvoiceJson
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        [JsonProperty("InvoiceNo")]
        public int? InvoiceNo;

        [JsonProperty("InvoiceUrl")]
        public string? InvoiceUrl;

        [JsonProperty("AccountNo")]
        public string? AccountNo;

        [JsonProperty("Status")]
        public int? Status;

        [JsonProperty("Created")]
        public string? Created;

        [JsonProperty("Expiration")]
        public string? Expiration;

        [JsonProperty("Amount")]
        public string? Amount;

        [JsonProperty("Currency")]
        public int? Currency;
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class InvoicesJson
    {
        [JsonProperty("Items")]
        public List<InvoiceJson>? Invoices;
    }

}
