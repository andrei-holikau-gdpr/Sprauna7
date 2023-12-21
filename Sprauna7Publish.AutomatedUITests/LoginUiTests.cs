using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Sprauna7Publish.SeleniumTests
{
    public class LoginUITests : BaseSeleniumTest, IDisposable
    {
        #region Private Fields

        private IWebDriver Driver => base.BaseDriver;
        private string SiteUrl => base.BaseSiteUrl;

        #endregion

        /// <summary>
        /// Открывается страница приветствия
        /// </summary>
        [Fact]
        public void Login_WhenNotAuthorize_ReturnsCreateView()
        {
            Driver.Navigate()
                .GoToUrl(SiteUrl);

            Assert.Equal("Panel.Sprauna.by", Driver.Title); // 
            Assert.Contains("Вход", Driver.PageSource);
        }

        /// <summary>
        /// Получаем ошибку если введены неверные данне
        /// </summary>
        [Fact]
        public void Login_WrongModelData_ReturnsErrorMessage()
        {
            // Arrango
            FillLoginForm.FillNotCorrectlyLogin(SiteUrl, Driver);

            // Act
            var errorMessage = Driver.FindElement(By.ClassName("validation-summary-errors")).Text;

            // Assert
            Assert.Contains("Неверная попытка входа.", errorMessage);
        }


        [Fact]
        public void Login_FormIsFilledOutCorrectly_ReturnNavMenu()
        {
            // Arrango
            FillLoginForm.FillCorrectlyKudesnikNet(SiteUrl, Driver);
            var _webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            
            // Act
            var navMenuPokupki = _webDriverWait.Until(drvr => drvr.FindElement(By.Id("purchases-h1"))).Text;

            // Assert
            Assert.Contains("Покупки", navMenuPokupki);
        }
    }
}