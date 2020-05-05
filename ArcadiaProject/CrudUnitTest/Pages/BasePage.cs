using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace CrudUnitTest.Pages
{
    abstract class BasePage
    {
        protected IWebDriver _driver;
        protected string _url;
        protected string _title;
        protected string _uri;
        
        protected IWebElement TitleElement
        {
            get { return _driver.FindElement(By.CssSelector("h1")); }
        }
        protected void Configure()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(System.IO.Path.GetDirectoryName(
                    System.Reflection.Assembly.
                    GetExecutingAssembly().Location) + "/dev-config.json")
                .Build();

            _url = config["baseUrl"] + _uri;
        }

        public BasePage Open()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }

        public bool IsPageOpen()
        {
            return TitleElement.Text == _title;
        }
    }
}
