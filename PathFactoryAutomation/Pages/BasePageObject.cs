using OpenQA.Selenium;

namespace PathFactoryAutomation.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public string GetTitle => driver.Title;
    }
}
