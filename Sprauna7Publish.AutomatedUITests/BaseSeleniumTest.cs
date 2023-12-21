using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprauna7Publish.SeleniumTests
{
    public abstract class BaseSeleniumTest: IDisposable
    {
        protected readonly IWebDriver BaseDriver;
        protected readonly string BaseSiteUrl = "https://localhost:7113";

        public BaseSeleniumTest()
        {
            BaseDriver = new ChromeDriver("D://chromedriver.exe");
        }

        public void Dispose()
        {
            BaseDriver.Quit();
            BaseDriver.Dispose();
        }
    }
}
