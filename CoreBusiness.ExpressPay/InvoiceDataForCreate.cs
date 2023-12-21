using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.ExpressPay
{
    public class InvoiceDataForCreate
    {
        // ToDo: Уточнить, что за AccountNo ?
        public string? AccountNo { get; set; } = "123456";
        public string? Amount { get; set; }
        public string? Currency { get; set; } = "933";
        public string? Expiration { get; set; }
        public string? Info { get; set; }
        public string? Surname { get; set; }
        public string? FirstName { get; set; }
        public string? Patronymic { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Building { get; set; }
        public string? Apartment { get; set; }
        public string? IsNameEditable { get; set; } = "0";
        public string? IsAddressEditable { get; set; } = "0";
        public string? IsAmountEditable { get; set; } = "0";
        public string? EmailNotification { get; set; }
        public string? ReturnInvoiceUrl { get; set; } = "1";
    }
}
