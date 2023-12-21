using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.SeleniumTests
{
    public class AddPurchasePageTestsTests : BaseSeleniumTest, IDisposable
    {
        #region Private Fields

        private IWebDriver Driver => base.BaseDriver;
        private string SiteUrl => base.BaseSiteUrl;

        #endregion

        [Fact]
        public void AddPurchaseComponent_ViewPage()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);

            // Act
            Driver.FindElement(By.Id("btnAddPurchase")).Click();
            var h1Text = Driver.FindElement(By.CssSelector("h1")).Text;

            // Assert
            Assert.Contains("Новая покупка", h1Text);
        }

        [Fact]
        public void AddPurchaseComponent_AddPurchase()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);

            // Act
            Driver.FindElement(By.Id("btnAddPurchase")).Click();
            var h1Text = Driver.FindElement(By.CssSelector("h1")).Text;

            Driver.FindElement(By.Id("Surname")).SendKeys("Иванов");
            Driver.FindElement(By.Id("name")).SendKeys("Иван");
            Driver.FindElement(By.Id("Shop")).SendKeys(@"https://allegro.pl/");
            Driver.FindElement(By.Id("AgreeWithTools")).Click();

            Driver.FindElement(By.Id("btnAddPurchase")).Click();

            // Assert
            Assert.Contains("Изменить покупку", h1Text);
        }
    }
}
