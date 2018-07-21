using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PathFactoryAutomation
{
    public static class WebDriverExtensions
    {
        private const int TimeOutInSecondsDefault = 2;

        public static IWebElement FindElementWithWait(this IWebDriver driver, By by, int timeoutInSeconds = TimeOutInSecondsDefault)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }  
    }
}
