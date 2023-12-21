using System.Xml.Linq;

namespace Plugins.Currencies
{
    public class Currency
    {
        #region Private fields

        public string UrlXmlSource = @"https://belgazprombank.by/upload/courses.xml";
        public string? currency { get; set; }
        public string? Units { get; set; }
        public string? buy { get; set; }
        public string? sell { get; set; }

        #endregion
        // ---
        #region Protectes Override Methods

        public Currency(string currency = "pln")
        {
            #pragma warning disable CS8602
            //todo: #pragma warning disable CS8602 

            this.currency = currency;
            XDocument xdoc = XDocument.Load(UrlXmlSource);

            var tom = xdoc.Element("branches")?   // получаем корневой узел people
            .Elements("branch")             // получаем все элементы person
            .FirstOrDefault(p => p.Attribute("name")?.Value == "Головной банк")
            .Elements("rate")
            .FirstOrDefault(p => p.Attribute("currency")?.Value == "pln");

            var attr = tom?.Attribute("currency");
            if (attr != null) {
                currency = attr.Value;
            }
            
            Units = tom?.Attribute("Units")?.Value;
            buy = tom?.Element("buy")?.Value;
            sell = tom?.Element("sell")?.Value;

            #pragma warning restore CS8602
        }

        #endregion
    }
}