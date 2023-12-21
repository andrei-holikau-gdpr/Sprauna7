using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.SeleniumTests
{
    public class ReceiversComponentTests : BaseSeleniumTest, IDisposable
    {
        #region Private Fields

        private IWebDriver Driver => base.BaseDriver;
        private string SiteUrl => base.BaseSiteUrl;

        #endregion

        [Fact]
        public void ReceiversComponent_ViewPage()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);
            Driver.FindElement(By.ClassName("lnkReceivers")).Click();

            // Act
            var h1Text = Driver.FindElement(By.CssSelector("h1")).Text;

            // Assert
            Assert.Contains("Получатели", h1Text);
        }
    }
}
