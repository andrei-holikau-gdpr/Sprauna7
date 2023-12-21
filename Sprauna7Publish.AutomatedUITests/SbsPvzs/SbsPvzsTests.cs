using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.SeleniumTests.SbsPvzs
{
    public class SbsPvzsTests : BaseSeleniumTest, IDisposable
    {

        #region Private Fields

        private IWebDriver Driver => base.BaseDriver;
        private string SiteUrl => base.BaseSiteUrl;

        #endregion


        [Fact]
        public void SbsPvz_GetPage()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);
            Driver.FindElement(By.CssSelector(".AdminPanel")).Click();
            Driver.FindElement(By.ClassName("SbsPvzsLink")).Click();

            // Act
            var h1Text = Driver.FindElement(By.CssSelector("h1")).Text;

            // Assert
            Assert.Contains("Pvz", h1Text);
        }
    }
}
