using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.SeleniumTests
{
    public class ShopByShopTests : BaseSeleniumTest, IDisposable
    {
        #region Private Fields

        private IWebDriver Driver => BaseDriver;
        private string SiteUrl => BaseSiteUrl;

        #endregion

        /// <summary>
        /// Проверяем открытие страницы
        /// </summary>
        [Fact]
        public void ShopByShopp_GetPage_ReturnsPage()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);

            // Act
            Driver.FindElement(By.Id("lnkShopByShop")).Click();
            var h1Text = Driver.FindElement(By.CssSelector("h1")).Text;

            // Assert
            Assert.Contains("Белка", h1Text);
        }
    }
}
