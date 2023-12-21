using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.SeleniumTests.ExchangeRates
{
    public class AdminExchangeRatesTests : BaseSeleniumTest, IDisposable
    {
        #region Private Fields
        private IWebDriver Driver => BaseDriver;
        private string SiteUrl => BaseSiteUrl;
        #endregion

        /// <summary>
        /// Проверяем открытие страницы
        /// </summary>
        [Fact]
        public void ExpressPay_GetPage_ReturnsPage()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);

            // Act
            Driver.FindElement(By.Id("lnkAdminExchangeRates")).Click();
            var h1Text = Driver.FindElement(By.CssSelector("h1")).Text;

            // Assert
            Assert.Contains("Курс Газпромбанка", h1Text);
        }

        [Fact]
        public void ExpressPay_GetPage_ReturnsValues()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);
            // Act
            Driver.FindElement(By.Id("lnkAdminExchangeRates")).Click();
            var _webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            var currencyValue   = _webDriverWait.Until(drvr => drvr.FindElement(By.ClassName("currencyValue"))).Text;
            var unitsValue      = _webDriverWait.Until(drvr => drvr.FindElement(By.ClassName("unitsValue"))).Text;
            var buyValue        = _webDriverWait.Until(drvr => drvr.FindElement(By.ClassName("buyValue"))).Text;
            var sellValue       = _webDriverWait.Until(drvr => drvr.FindElement(By.ClassName("sellValue"))).Text;

            // Assert
            Assert.NotEmpty(currencyValue);
            Assert.NotEmpty(unitsValue);
            Assert.NotEmpty(buyValue);
            Assert.NotEmpty(sellValue);
        }
    }
}
