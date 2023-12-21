using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
//using System.Web.Http;

namespace SpraunaApi2.Controllers
{
    public class EripNotify
    {
        public string Data { get; set; }
        public string Signature { get; set; }
    }

    [ApiController]
    [Route("express-pay")]
    public class EripNotifyController : ControllerBase
    {
        private static readonly Encoding HashEncoding = Encoding.UTF8;
        private string _secretWord = "blazor";
        private bool _useSignature = false;

        private readonly IWebHostEnvironment env;

        public EripNotifyController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpGet]
        public string Get()
        {
            try
            {
                var path = Path.Combine(env.ContentRootPath,
                                "log.txt");

                // запись в файл
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    // преобразуем строку в байты
                    byte[] input = Encoding.Default.GetBytes("model.Data: ");
                    // запись массива байтов в файл
                    fstream.Write(input, 0, input.Length);
                }
                return "Test";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        [HttpPost]        
        public string Test(EripNotify model)
        {
            try
            {
                if (_useSignature)
            {
                // Проверяем цифровую подпись
                if (model.Signature != ComputeSignature(model.Data, _secretWord))
                {
                    // ToDo: NOTE: Добавить обработку ошибки
                    // ...
                    // return InternalServerError();
                    throw new Exception("Цифровую подпись is bad. ");
                }
            }
            // Преобразуем из JSON в Object
            var obj = JObject.Parse(model.Data);
            // NOTE: Выполняем действия с полученным объектом

            var path = Path.Combine(env.ContentRootPath,
                            "log.txt");

            // запись в файл
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] input = Encoding.Default.GetBytes("model.Data: "+ model.Data);
                // запись массива байтов в файл
                fstream.Write(input, 0, input.Length);
            }


            return "Ok"; // Ok();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // Функция генерации и проверки цифровой подписи
        public string ComputeSignature(string json, string secretWord)
        {
            var hmac = string.IsNullOrWhiteSpace(secretWord) ?
                new HMACSHA1(HashEncoding.GetBytes(string.Empty)) :
                new HMACSHA1(HashEncoding.GetBytes(secretWord));
            var hash = hmac.ComputeHash(HashEncoding.GetBytes(json));
            var result = new StringBuilder();
            foreach (var item in hash)
                result.Append(item.ToString("X2"));
            return result.ToString();
        }
    }
}
