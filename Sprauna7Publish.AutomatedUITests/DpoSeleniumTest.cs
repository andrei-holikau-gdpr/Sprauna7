using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Sprauna7Publish.SeleniumTests
{
    public class DpoSeleniumTest : IDisposable
    {
        #region Private Fields

        private IWebDriver BaseDriver; // = new ChromeDriver("D://");

        #endregion

        public DpoSeleniumTest()
        {
            // System.setProperty("webdriver.chrome.driver", "<chromedriver path>");
            // Webdriver driver = new chromedriver();
            BaseDriver = new ChromeDriver(@"D:\chromedriver\chromedriver-win64");
            //https://googlechromelabs.github.io/chrome-for-testing/#stable

            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //ChromeDriver driver = new ChromeDriver();
        }

        public void Dispose()
        {
            BaseDriver.Quit();
            BaseDriver.Dispose();
        }

        [Fact]
        public void AddPost()
        {
            BaseDriver.Navigate().GoToUrl("https://chimstirka.by/wp-admin/");

            BaseDriver.FindElement(By.Id("user_login")).SendKeys("chimstirka.Admin");
            BaseDriver.FindElement(By.Id("user_pass")).SendKeys("cipaM_21042022");

            BaseDriver.FindElement(By.Id("wp-submit")).Click();

            BaseDriver.Navigate().GoToUrl("https://chimstirka.by/wp-admin/post-new.php?post_type=page");
            BaseDriver.FindElement(By.Id("title")).SendKeys(DateTime.Now.ToShortTimeString());
            // BaseDriver.FindElement(By.ClassName("edit-visibility")).Click();
            // BaseDriver.FindElement(By.XPath(@"//*[@id=\'post-visibility-select\']/label[3]")).Click();
            // BaseDriver.FindElement(By.CssSelector("#post-visibility-select > label:nth-child(11)")).Click();
            // BaseDriver.FindElement(By.Id("save-post-visibility")).Click();

            BaseDriver.FindElement(By.Id("publish")).Click();
        }
    }
}
