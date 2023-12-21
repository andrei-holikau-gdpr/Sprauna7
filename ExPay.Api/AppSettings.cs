using System.Text;

namespace ExPay.Api
{
    public static class AppSettings
    {
        public const string ServiceUrl = "https://api.express-pay.by/v1/";
        public const string Token = "6d1f6e66c55e49438216143c2ec36f64"; // API-ключ
        public static readonly Encoding DefaultEncoding = Encoding.UTF8;
        public static int ServiceId = 2;
    }
}
