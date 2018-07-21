using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PathFactoryAutomation.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement EmailField => driver.FindElementWithWait(By.Id("email"));

        public IWebElement PasswordField => driver.FindElementWithWait(By.Id("passwd"));

        public IWebElement SubmitLogin => driver.FindElementWithWait(By.Id("SubmitLogin"));

        public IWebElement ForgotMyPasswordLink => driver.FindElementWithWait(By.CssSelector(".lost_password.form-group > a"));

        public IWebElement AlertLocator => driver.FindElementWithWait(By.CssSelector(".alert > ol > li"));

        public string TypeEmail
        {
            set => EmailField.SendKeys(value);
        }

        public string TypePassword
        {
            set => PasswordField.SendKeys(value);
        }

        public MyAccountPage PressSubmitLoginPositive()
        {
            SubmitLogin.Click();
            var myAccount = new MyAccountPage(driver);
            PageFactory.InitElements(driver, myAccount);
            return myAccount;
        }

        public LoginPage PressSubmitLoginNegative()
        {
            SubmitLogin.Click();
            return this;
        }

        public ForgotPasswordPage PressForgotMyPasswordLink()
        {
            ForgotMyPasswordLink.Click();
            var forgotpassword = new ForgotPasswordPage(driver);
            PageFactory.InitElements(driver, forgotpassword);
            return forgotpassword;
        }

        public string GetAlertMessage => AlertLocator.Text;
    }
}
