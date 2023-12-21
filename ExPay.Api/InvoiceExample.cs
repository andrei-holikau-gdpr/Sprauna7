using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace ExPay.Api
{
    public static class InvoiceExample
    {
        private const string NumberInvoice = "2";
        private const string CardNumberInvoice = "1674";
        private const string SiteUrl = "https://example.com/";
        public static void AddInvoice( string AccountNo = "123456")
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},
                {"AccountNo", AccountNo},
                {"Amount", "10"},
                {"Currency", "933"},
                {"Expiration", "20240505"},
                {"Info", "info"},
                {"Surname", "Ivanov"},
                {"FirstName", "Ivan"},
                {"Patronymic", "Ivanovich"},
                {"City", "Minsk"},
                {"Street", "Frunze"},
                {"House", "20"},
                {"Building", "2"},
                {"Apartment", "10"},
                {"IsNameEditable", "0"},
                {"IsAddressEditable", "0"},
                {"IsAmountEditable", "0"},
                {"EmailNotification", "kudesnik.Net@gmail.com"},
            };
            var signature = SignatureHelper.Compute(requestParams, "blazor", "add-invoice"); // string.Empty
            using (var client = new WebClient())
            {
                var url = AppSettings.ServiceUrl + "invoices?token=" + AppSettings.Token + "&signature=" + signature;
                var response = client.UploadValues(url, new NameValueCollection
                {
                    {"AccountNo", AccountNo},
                    {"Amount", "10"},
                    {"Currency", "933"},
                    {"Expiration", "20240505"},
                    {"Info", "info"},
                    {"Surname", "Ivanov"},
                    {"FirstName", "Ivan"},
                    {"Patronymic", "Ivanovich"},
                    {"City", "Minsk"},
                    {"Street", "Frunze"},
                    {"House", "20"},
                    {"Building", "2"},
                    {"Apartment", "10"},
                    {"IsNameEditable", "0"},
                    {"IsAddressEditable", "0"},
                    {"IsAmountEditable", "0"},
                    {"EmailNotification", "kudesnik.Net@gmail.com"},
                });
                var data = AppSettings.DefaultEncoding.GetString(response);
                Console.WriteLine(data);
            }
        }

        public static void GetDetailsInvoice( )
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},
                {"Id", NumberInvoice}
            };

            var signature = SignatureHelper.Compute(requestParams, string.Empty, "get-details-invoice");

            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;
                var data =
                    client.DownloadString(AppSettings.ServiceUrl + "invoices/" + NumberInvoice + "?token=" + AppSettings.Token + "&signature=" +
                                          signature);
                Console.WriteLine(data);
            }
        }

        public static void CancelInvoice()
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},
                {"Id", NumberInvoice}
            };

            var signature = SignatureHelper.Compute(requestParams, string.Empty, "cancel-invoice");
            var url = AppSettings.ServiceUrl + "invoices/" + NumberInvoice + "?token=" + AppSettings.Token + "&signature=" + signature;
            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;
                var data = client.UploadString(url, "DELETE", string.Empty);
                Console.WriteLine(data);
            }
        }

        public static void GetStatusInvoice()
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},
                {"InvoiceId", NumberInvoice}
            };

            var signature = SignatureHelper.Compute(requestParams, string.Empty, "status-invoice");
            var url = AppSettings.ServiceUrl + "invoices/" + NumberInvoice + "/status?token=" + AppSettings.Token + "&signature=" + signature;
            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;
                var data = client.DownloadString(url);
                Console.WriteLine(data);
            }
        }

        public static void GetListInvoices()
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},

                //Параметры фильтра являются опциональными, по умолчанию возврщает значения за последние 30 дней
                {"AccountNo", NumberInvoice},
                {"From", "20240101" },
                {"To", "21000101" },
                {"Status", "1" }
            };

            var signature = SignatureHelper.Compute(requestParams, string.Empty, "get-list-invoices");

            var url = AppSettings.ServiceUrl + "invoices?token=" + AppSettings.Token + "&signature=" + signature + "&From=20000101&To=21000101&AccountNo=" + NumberInvoice + "&Status=1";
            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;
                var data = client.DownloadString(url);

                Console.WriteLine(data);
            }
        }

        public static void AddCardInvoice()
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},
                {"AccountNo", "123456"},
                {"Expiration", "20231224"},
                {"Amount", "10"},
                {"Currency", "933"},
                {"Info", "info"},
                {"ReturnUrl", "https://example.com/success"},
                {"FailUrl", "https://example.com/fail"},
                {"Language", "ru"},
                {"PageView", "DESKTOP"},
                {"SessionTimeoutSecs", "2000"},
                {"ExpirationDate", "20231224235001"},
            };
            var signature = SignatureHelper.Compute(requestParams, string.Empty, "add-card-invoice");
            using (var client = new WebClient())
            {
                var url = AppSettings.ServiceUrl + "cardinvoices?token=" + AppSettings.Token + "&signature=" + signature;
                var response = client.UploadValues(url, new NameValueCollection
                {
                    {"Token", AppSettings.Token},
                    {"AccountNo", "123456"},
                    {"Expiration", "20231224"},
                    {"Amount", "10"},
                    {"Currency", "933"},
                    {"Info", "info"},
                    {"ReturnUrl", "https://example.com/success"},
                    {"FailUrl", "https://example.com/fail"},
                    {"Language", "ru"},
                    {"PageView", "DESKTOP"},
                    {"SessionTimeoutSecs", "2000"},
                    {"ExpirationDate", "20231224235001"},
                });
                var data = AppSettings.DefaultEncoding.GetString(response);
                Console.WriteLine(data);
            }
        }

        public static void StatusCardInvoice()
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},
                {"CardInvoiceNo", CardNumberInvoice},
                {"Language", "ru"},
            };
            var signature = SignatureHelper.Compute(requestParams, string.Empty, "status-card-invoice");
            using (var client = new WebClient())
            {
                var url = AppSettings.ServiceUrl + "cardinvoices/" + CardNumberInvoice + "/status?token=" + AppSettings.Token + "&signature=" + signature;
                using (var subClient = new WebClient())
                {
                    client.Encoding = AppSettings.DefaultEncoding;
                    var data = client.DownloadString(url);
                    Console.WriteLine(data);
                }
            }
        }

        public static void AddWebInvoice()
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},
                {"ServiceId", AppSettings.ServiceId.ToString()},
                {"AccountNo", "123456"},
                {"Amount", "10"},
                {"Currency", "974"},
                {"Expiration", "20230505"},
                {"Info", "info"},
                {"Surname", "Ivanov"},
                {"FirstName", "Ivan"},
                {"Patronymic", "Ivanovich"},
                {"City", "Minsk"},
                {"Street", "Frunze"},
                {"Building", "2"},
                {"Apartment", "10"},
                {"IsNameEditable", "0"},
                {"IsAddressEditable", "0"},
                {"IsAmountEditable", "0"},
                {"EmailNotification", "ivanov@gmail.com"},
                {"SmsPhone", "+375291234567"},
                {"ReturnType","redirect"},
                {"ReturnUrl", SiteUrl  + "success"},
                {"FailUrl", SiteUrl  + "fail"},
                {"ReturnInvoiceUrl", "1"},
            };

            var signature = SignatureHelper.Compute(requestParams, string.Empty, "add-web-invoice");

            using (var client = new WebClient())
            {
                var url = AppSettings.ServiceUrl;
                var response = client.UploadValues(url, new NameValueCollection
                {
                    {"ServiceId", AppSettings.ServiceId.ToString()},
                    {"AccountNo", "123456"},
                    {"Amount", "10"},
                    {"Currency", "974"},
                    {"Expiration", "20230505"},
                    {"Info", "info"},
                    {"Surname", "Ivanov"},
                    {"FirstName", "Ivan"},
                    {"Patronymic", "Ivanovich"},
                    {"City", "Minsk"},
                    {"Street", "Frunze"},
                    {"Building", "2"},
                    {"Apartment", "10"},
                    {"IsNameEditable", "0"},
                    {"IsAddressEditable", "0"},
                    {"IsAmountEditable", "0"},
                    {"EmailNotification", "ivanov@gmail.com"},
                    {"SmsPhone", "+375291234567"},
                    {"ReturnType", "redirect"},
                    {"ReturnUrl", SiteUrl  + "success"},
                    {"FailUrl", SiteUrl  + "fail"},
                    {"Signature", signature},
                    {"ReturnInvoiceUrl", "1"},
                });

                var data = AppSettings.DefaultEncoding.GetString(response);
                Console.WriteLine(data);
            }
        }

        public static void AddWebCardInvoice()
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},
                {"ServiceId", AppSettings.ServiceId.ToString()},
                {"AccountNo", "123456"},
                {"Expiration", "20231224"},
                {"Amount", "10"},
                {"Currency", "933"},
                {"Info", "info"},
                {"ReturnUrl", "https://example.com/success"},
                {"FailUrl", "https://example.com/fail"},
                {"Language", "ru"},
                {"SessionTimeoutSecs", "2000"},
                {"ExpirationDate", "20231224235001"},
                {"ReturnInvoiceUrl", "1"},
            };
            var signature = SignatureHelper.Compute(requestParams, string.Empty, "add-webcard-invoice");
            using (var client = new WebClient())
            {
                var url = AppSettings.ServiceUrl;
                var response = client.UploadValues(url, new NameValueCollection
                {
                    {"ServiceId", AppSettings.ServiceId.ToString()},
                    {"AccountNo", "123456"},
                    {"Expiration", "20231224"},
                    {"Amount", "10"},
                    {"Currency", "933"},
                    {"Info", "info"},
                    {"ReturnUrl", "https://example.com/success"},
                    {"FailUrl", "https://example.com/fail"},
                    {"Language", "ru"},
                    {"SessionTimeoutSecs", 2000.ToString()},
                    {"ExpirationDate", "20231224235001"},
                    {"Signature", signature},
                    {"ReturnInvoiceUrl", "1"},
                });
                var data = AppSettings.DefaultEncoding.GetString(response);
                Console.WriteLine(data);
            }
        }
    }
}