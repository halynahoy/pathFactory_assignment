using OpenQA.Selenium;

namespace PathFactoryAutomation.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement SignInButton => driver.FindElementWithWait(By.ClassName("login"));

        public LoginPage PressSignInButton()
        {
            SignInButton.Click();
            var loginPage = new LoginPage(driver);
            return loginPage;
        }
    }
}
