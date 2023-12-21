using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.ExpressPay
{
    public static class QrCodeExample
    {
        private const string NumberInvoice = "10";
        private const string ViewType = "base64";
        private const string ImageWidth = "400";
        private const string ImageHeight = "400";

        public static void GetQrCode()
        {
            var requestParams = new Dictionary<string, string>
            {
                {"Token",  AppSettings.Token },
                {"InvoiceId",NumberInvoice },
                {"ViewType",ViewType },
                {"ImageWidth", ImageWidth },
                {"ImageHeight", ImageHeight }
            };

            var signature = SignatureHelper.Compute(requestParams, string.Empty, "get-qr-code");

            var url = string.Format("{0}qrcode/getqrcode/?token={1}&invoiceid={2}&viewtype={3}&imagewidth={4}&imageheight={5}&signature={6}"
                , AppSettings.ServiceUrl, AppSettings.Token, NumberInvoice, ViewType, ImageWidth, ImageHeight, signature);

            using (var client = new WebClient())
            {
                client.Encoding = AppSettings.DefaultEncoding;
                var data = client.DownloadString(url);
                Console.WriteLine(data);
            }
        }
    }
}
