using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.CompilerServices;

namespace ExpressPay
{
    public static class InvoiceExample
    {
        // todo: В релизе удалить NumberInvoice
        private static string TestNumberInvoice = "100";
        private static string CardNumberInvoice = "1674";
        private static string SiteUrl = "https://example.com/";

        // todo: В релизе public Token заменить на private Token
        private static string Token = AppSettings.Token;

        // todo: В релизе public SecretWord заменить на private SecretWord
        private static string SecretWord = AppSettings.SecretWord;

        // todo: В релизе public SecretWord заменить на private SecretWord
        private static string ServiceUrl = AppSettings.ServiceUrl;

        public static void IsTest(bool isTest)
        {
            if (isTest)
            {
                ServiceUrl = "https://sandbox-api.express-pay.by/v1/";
                Token = "a75b74cbcfe446509e8ee874f421bd69";
                SecretWord = string.Empty;
            }
            else
            {
                ServiceUrl = "https://api.express-pay.by/v1/";
                Token = AppSettings.Token;
                SecretWord = AppSettings.SecretWord;
            }
        }

        public static void AddInvoice( string AccountNo = "123456")
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", Token},
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
            var signature = SignatureHelper.Compute(requestParams, SecretWord, "add-invoice"); // string.Empty
            using (var client = new WebClient())
            {
                var url = ServiceUrl + "invoices?token=" + Token + "&signature=" + signature;
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
                    {"ReturnInvoiceUrl", "1"},
                });
                var data = AppSettings.DefaultEncoding.GetString(response);
                //Console.WriteLine(data);
            }
        }

        public static string GetDetailsInvoice(string numberInvoice = "123458")
        {
            string result = "";
            TestNumberInvoice = numberInvoice;
            var requestParams = new Dictionary<string, string>
            {
                {"Token", Token},
                {"Id", numberInvoice}
            };

            var signature = SignatureHelper.Compute(requestParams, SecretWord, "get-details-invoice");

            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;

                string fullUrl = ServiceUrl + "invoices/" + TestNumberInvoice + "?token=" + Token + "&signature=" + signature;
                var data =
                    client.DownloadString(fullUrl);
                Console.WriteLine(data);
                result = data;
            }
            return result;
        }

        public static void CancelInvoice()
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token", Token},
                {"Id", TestNumberInvoice}
            };

            var signature = SignatureHelper.Compute(requestParams, SecretWord, "cancel-invoice");
            var url = ServiceUrl + "invoices/" + TestNumberInvoice + "?token=" + Token + "&signature=" + signature;
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
                {"Token", Token},
                {"InvoiceId", TestNumberInvoice}
            };

            var signature = SignatureHelper.Compute(requestParams, SecretWord, "status-invoice");
            var url = ServiceUrl + "invoices/" + TestNumberInvoice + "/status?token=" + Token + "&signature=" + signature;
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
                {"Token", Token},

                //Параметры фильтра являются опциональными, по умолчанию возврщает значения за последние 30 дней
                {"AccountNo", TestNumberInvoice},
                {"From", "20240101" },
                {"To", "21000101" },
                {"Status", "1" }
            };

            var signature = SignatureHelper.Compute(requestParams, SecretWord, "get-list-invoices");

            var url = ServiceUrl + "invoices?token=" + Token + "&signature=" + signature + "&From=20000101&To=21000101&AccountNo=" + TestNumberInvoice + "&Status=1";
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
                {"Token", Token},
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
            var signature = SignatureHelper.Compute(requestParams, SecretWord, "add-card-invoice");
            using (var client = new WebClient())
            {
                var url = ServiceUrl + "cardinvoices?token=" + Token + "&signature=" + signature;
                var response = client.UploadValues(url, new NameValueCollection
                {
                    {"Token", Token},
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
                {"Token", Token},
                {"CardInvoiceNo", CardNumberInvoice},
                {"Language", "ru"},
            };
            var signature = SignatureHelper.Compute(requestParams, SecretWord, "status-card-invoice");
            using (var client = new WebClient())
            {
                var url = ServiceUrl + "cardinvoices/" + CardNumberInvoice + "/status?token=" + Token + "&signature=" + signature;
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
                {"Token", Token},
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

            var signature = SignatureHelper.Compute(requestParams, SecretWord, "add-web-invoice");

            using (var client = new WebClient())
            {
                var url = ServiceUrl;
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
                {"Token", Token},
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
            var signature = SignatureHelper.Compute(requestParams, SecretWord, "add-webcard-invoice");
            using (var client = new WebClient())
            {
                var url = ServiceUrl;
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