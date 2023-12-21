using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.SeleniumTests
{
    public class PurchasesComponentTestsTests : BaseSeleniumTest, IDisposable
    {
        #region Private Fields

        private IWebDriver Driver => base.BaseDriver;
        private string SiteUrl => base.BaseSiteUrl;
        private const string PageUrl = "/purchases";

        #endregion

        [Fact]
        public void PurchasesComponent_ViewPage()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);
            Driver.Navigate().GoToUrl(SiteUrl + PageUrl);

            // Act
            var h1Text = Driver.FindElement(By.CssSelector("h1")).Text;
            //var allPackages = _driver.FindElement(By.ClassName("all-packages"));

            // Assert
            Assert.Contains("Покупки", h1Text);
            //Assert.NotNull(allPackages);
        }
    }
}
