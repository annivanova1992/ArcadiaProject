using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace CrudUnitTest.Pages
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _title = "Index";
            _uri = "/";
            Configure();
        }
    }
}
