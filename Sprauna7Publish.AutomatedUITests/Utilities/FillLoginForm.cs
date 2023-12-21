using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.SeleniumTests
{
    public static class FillLoginForm
    {
        public static void FillNotCorrectlyLogin(string _siteUrl, IWebDriver _driver)
        {
            _driver.Navigate().GoToUrl(_siteUrl + "/Identity/Account/Login");
            _driver.FindElement(By.Id("Input_Email")).SendKeys("no-kudesnik@gmail.com");
            _driver.FindElement(By.Id("Input_Password")).SendKeys("Qwe/321");
            _driver.FindElement(By.Id("login-submit")).Click();
        }

        public static void FillNotCorrectlyPassword(string _siteUrl, IWebDriver _driver)
        {
            _driver.Navigate().GoToUrl(_siteUrl + "/Identity/Account/Login");
            _driver.FindElement(By.Id("Input_Email")).SendKeys("kudesnik.Net@gmail.com");
            _driver.FindElement(By.Id("Input_Password")).SendKeys("123");
            _driver.FindElement(By.Id("login-submit")).Click();
        }

        public static void FillCorrectlyKudesnikNet(string _siteUrl, IWebDriver _driver)
        {
            _driver.Navigate().GoToUrl(_siteUrl + "/Identity/Account/Login");
            _driver.FindElement(By.Id("Input_Email")).SendKeys("kudesnik.Net@gmail.com");
            _driver.FindElement(By.Id("Input_Password")).SendKeys("Qwe/321");
            _driver.FindElement(By.Id("login-submit")).Click();
        }

        public static void FillCorrectlyKudesnik7(string _siteUrl, IWebDriver _driver)
        {
            _driver.Navigate().GoToUrl(_siteUrl + "/Identity/Account/Login");
            _driver.FindElement(By.Id("Input_Email")).SendKeys("kudesnik.7@gmail.com");
            _driver.FindElement(By.Id("Input_Password")).SendKeys("Qwe/321");
            _driver.FindElement(By.Id("login-submit")).Click();
        }
    }
}
