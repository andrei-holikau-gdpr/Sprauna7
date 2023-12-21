using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ExpressPay
{
    public static class SignatureHelper
    {
        private static readonly Encoding HashEncoding = Encoding.UTF8;

        // Порядок следования полей при вычислении цифровой подписи.
        // Внимание! Для корректной работы порядок изменять нельзя
        private static readonly Dictionary<string, string[]> Mapping = new Dictionary<string, string[]>
        {
            {
                "add-invoice", new[]
                {
                    "token",
                    "accountno",
                    "amount",
                    "currency",
                    "expiration",
                    "info",
                    "surname",
                    "firstname",
                    "patronymic",
                    "city",
                    "street",
                    "house",
                    "building",
                    "apartment",
                    "isnameeditable",
                    "isaddresseditable",
                    "isamounteditable"
                }
            },
            {
                "get-details-invoice", new[]
                {
                    "token",
                    "id"
                }
            },
            {
                "cancel-invoice", new[]
                {
                    "token",
                    "id"
                }
            },
            {
                "status-invoice", new[]
                {
                    "token",
                    "invoiceid"
                }
            },
            {
                "get-list-invoices", new[]
                {
                    "token",
                    "from",
                    "to",
                    "accountno",
                    "status"
                }
            },
            {
                "get-list-payments", new[]
                {
                    "token",
                    "from",
                    "to",
                    "accountno"
                }
            },
            {
                "get-details-payment", new[]
                {
                    "token",
                    "id"
                }
            },
            {
                "add-card-invoice", new[]
                {
                    "token",
                    "accountno",
                    "expiration",
                    "amount",
                    "currency",
                    "info",
                    "returnurl",
                    "failurl",
                    "language",
                    "pageview",
                    "sessiontimeoutsecs",
                    "expirationdate"
                }
            },
            {
                "card-invoice-form", new[]
                {
                    "token",
                    "cardinvoiceno"
                }
            },
            {
                "status-card-invoice", new[]
                {
                    "token",
                    "cardinvoiceno",
                    "language"
                }
            },
            {
                "reverse-card-invoice", new[]
                {
                    "token",
                    "cardinvoiceno"
                }
            },
            {
                "get-qr-code", new[]
                {
                    "token",
                    "invoiceid",
                    "viewtype",
                    "imagewidth",
                    "imageheight"
                }
            },
            {
                "add-web-invoice",new[]
                {
                    "token",
                    "serviceid",
                    "accountno",
                    "amount",
                    "currency",
                    "expiration",
                    "info",
                    "surname",
                    "firstname",
                    "patronymic",
                    "city",
                    "street",
                    "house",
                    "building",
                    "apartment",
                    "isnameeditable",
                    "isaddresseditable",
                    "isamounteditable",
                    "emailnotification",
                    "smsphone",
                    "returntype",
                    "returnurl",
                    "failurl"
                }
            },
            {
                "add-webcard-invoice",new[]
                {
                    "token",
                    "serviceid",
                    "accountno",
                    "expiration",
                    "amount",
                    "currency",
                    "info",
                    "returnurl",
                    "failurl",
                    "language",
                    "sessiontimeoutsecs",
                    "expirationdate",
                    "returntype"
                }
            }
        };


        public static string Compute(Dictionary<string, string> requestParams, string secretWord, string action)
        {
            var normalizedParams = requestParams
                .ToDictionary(k => k.Key.ToLower(), v => v.Value);

            var cmdFields = Mapping[action];

            var builder = new StringBuilder();
            foreach (var cmdField in cmdFields)
            {
                if (normalizedParams.ContainsKey(cmdField))
                    builder.Append(normalizedParams[cmdField]);
            }

            HMACSHA1 hmac;
            if (string.IsNullOrWhiteSpace(secretWord))
            {
                // в алгоритме всегда должно быть задан ключ шифрования. Если исп. конструктор по умолчанию, то ключ генерится автоматически,
                // что нам не подходит
                hmac = new HMACSHA1(HashEncoding.GetBytes(string.Empty));
            }
            else
            {
                hmac = new HMACSHA1(HashEncoding.GetBytes(secretWord));
            }

            var hash = hmac.ComputeHash(
                HashEncoding.GetBytes(builder.ToString()));

            var result = new StringBuilder();
            foreach (var item in hash)
            {
                result.Append(item.ToString("X2"));
            }

            return result.ToString();
        }
    }
}
