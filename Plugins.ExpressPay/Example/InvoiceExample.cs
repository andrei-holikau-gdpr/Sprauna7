using CoreBusiness.ExpressPay;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.CompilerServices;

#pragma warning disable SYSLIB0014

namespace Plugins.ExpressPay
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

        public static InvoiceJson? AddInvoice( 
            InvoiceDataForCreate newInvoice)
        {
            InvoiceJson? result;
            string ExpirationDate = (DateTime.Now).AddDays(14).ToString("yyyyMMdd");
            newInvoice.Expiration = ExpirationDate;

            var requestParams = new Dictionary<string, string>
            {
                {"Token", Token},
                {"AccountNo", newInvoice.AccountNo},
                {"Amount", newInvoice.Amount},
                {"Currency", newInvoice.Currency},
                {"Expiration", newInvoice.Expiration},
                {"Info", newInvoice.Info},
                {"Surname", newInvoice.Surname},
                {"FirstName", newInvoice.FirstName},
                {"Patronymic", newInvoice.Patronymic},
                {"City", newInvoice.City},
                {"Street", newInvoice.Street},
                {"House", newInvoice.House},
                {"Building", newInvoice.Building},
                {"Apartment", newInvoice.Apartment},
                {"IsNameEditable", newInvoice.IsNameEditable},
                {"IsAddressEditable", newInvoice.IsAddressEditable},
                {"IsAmountEditable", newInvoice.IsAmountEditable},
                {"EmailNotification", newInvoice.EmailNotification}
            };
            var signature = SignatureHelper.Compute(requestParams, SecretWord, "add-invoice"); // string.Empty

            
            using (var client = new WebClient())
            {
                var url = ServiceUrl + "invoices?token=" + Token + "&signature=" + signature;
                var response = client.UploadValues(url, new NameValueCollection
                {
                    {"Token", Token},
                    {"AccountNo", newInvoice.AccountNo},
                    {"Amount", newInvoice.Amount},
                    {"Currency", newInvoice.Currency},
                    {"Expiration", newInvoice.Expiration},
                    {"Info", newInvoice.Info},
                    {"Surname", newInvoice.Surname},
                    {"FirstName", newInvoice.FirstName},
                    {"Patronymic", newInvoice.Patronymic},
                    {"City", newInvoice.City},
                    {"Street", newInvoice.Street},
                    {"House", newInvoice.House},
                    {"Building", newInvoice.Building},
                    {"Apartment", newInvoice.Apartment},
                    {"IsNameEditable", newInvoice.IsNameEditable},
                    {"IsAddressEditable", newInvoice.IsAddressEditable},
                    {"IsAmountEditable", newInvoice.IsAmountEditable},
                    {"EmailNotification", newInvoice.EmailNotification},
                    {"ReturnInvoiceUrl", newInvoice.ReturnInvoiceUrl},
                });
                var data = AppSettings.DefaultEncoding.GetString(response);
                //Console.WriteLine(data);
                result = JsonConvert.DeserializeObject<InvoiceJson>(data);
            }
            return result;
        }

        public static string GetDetailsInvoice(string numberInvoice = "123458")
        {
            var result = "";
            TestNumberInvoice = numberInvoice;
            var requestParams = new Dictionary<string, string>
            {
                {"Token", Token},
                {"Id", numberInvoice}
            };

            var signature = SignatureHelper.Compute(
                                requestParams, 
                                SecretWord, 
                                "get-details-invoice");

            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;

                string fullUrl = ServiceUrl + "invoices/" + numberInvoice + "?token=" + Token + "&signature=" + signature;
                var data =
                    client.DownloadString(fullUrl);
                // Console.WriteLine(data);
                result = data;
            }
            return result;
        }

        public static string CancelInvoice(string numberInvoice = "123458")
        {
            var result = "";
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
                // Console.WriteLine(data);
                result = data;
            }
            return result;
        }

        public static string GetStatusInvoice(string numberInvoice = "123458")
        {
            var result = "";
            var requestParams = new Dictionary<string, string>
            {
                {"Token", Token},
                {"InvoiceId", numberInvoice}
            };

            var signature = SignatureHelper.Compute(requestParams, SecretWord, "status-invoice");
            var url = ServiceUrl + "invoices/" + numberInvoice + "/status?token=" + Token + "&signature=" + signature;
            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;
                var data = client.DownloadString(url);
                // Console.WriteLine(data);
                result = data;
            }
            return result;
        }

        public static string GetListInvoices()
        {
            var result = "";
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
                // Console.WriteLine(data);
                result = data;
            }
            return result;
        }

        public static string AddCardInvoice()
        {
            var result = "";
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
                // Console.WriteLine(data);
                result = data;
            }
            return result;
        }

        public static string StatusCardInvoice()
        {
            var result = "";
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
                    // Console.WriteLine(data);
                    result = data;
                }
            }
            return result;
        }

        public static string AddWebInvoice()
        {
            var result = "";
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
                // Console.WriteLine(data);
                result = data;
            }
            return result;
        }

        public static string AddWebCardInvoice()
        {
            var result = "";
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
                // Console.WriteLine(data);
                result = data;
            }
            return result;
        }
    }
}