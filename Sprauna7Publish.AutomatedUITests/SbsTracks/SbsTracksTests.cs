using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.SeleniumTests.SbsTracks
{
    public class SbsTracksTests : BaseSeleniumTest, IDisposable
    {

        #region Private Fields

        private IWebDriver Driver => base.BaseDriver;
        private string SiteUrl => base.BaseSiteUrl;

        #endregion

        [Fact]
        public void SbsTracks_GetPage()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);
            Driver.FindElement(By.CssSelector(".AdminPanel")).Click();
            Driver.FindElement(By.ClassName("SbsTracksLink")).Click();

            // Act
            var h1Text = Driver.FindElement(By.CssSelector("h1")).Text;

            // Assert
            Assert.Contains("Посылки", h1Text);
        }

    }
}
