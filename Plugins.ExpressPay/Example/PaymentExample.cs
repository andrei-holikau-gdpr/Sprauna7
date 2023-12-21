using System;
using System.Collections.Generic;
using System.Net;

namespace Plugins.ExpressPay
{
    public static class PaymentExample
    {
        private const string NumberPayment = "1022";
        private const string CardNumberInvoice = "1674";

        public static string GetListPayments()
        {
            var result = "";
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},

                // Параметры фильтра являются опциональными. По умолчанию возвращает значения за последние 30 дней
                {"AccountNo", NumberPayment},
                {"From", "20000101" },
                {"To", "21000101" }
            };

            var signature = SignatureHelper.Compute(requestParams, string.Empty, "get-list-payments");

            var url = AppSettings.ServiceUrl + "payments?token=" + AppSettings.Token +
                "&signature=" + signature + "&From=20000101&To=21000101&AccountNo=" + NumberPayment;

            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;
                var data = client.DownloadString(url);
                // Console.WriteLine(data);
                result = data;
            }
            return result;
        }

        public static string GetDetailsPayment()
        {
            var result = "";
            var requestParams = new Dictionary<string, string>
            {
                {"Token", AppSettings.Token},
                {"Id", NumberPayment}
            };

            var signature = SignatureHelper.Compute(requestParams, string.Empty, "get-details-payment");

            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;
                var data =
                    client.DownloadString(AppSettings.ServiceUrl + "payments/" + NumberPayment + "?token=" + AppSettings.Token + "&signature=" +
                                          signature);

                //Console.WriteLine(data);
                result = data;
            }
            return result;
        }

        public static string PaymentCardInvoice()
        {
            var result = "";
            var requestParams = new Dictionary<string, string>
            {
                {"CardInvoiceNo", CardNumberInvoice},
            };
            using (var client = new WebClient())
            {
                var url = AppSettings.ServiceUrl + "cardinvoices/" + CardNumberInvoice + "/payment";
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
    }
}