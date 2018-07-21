using OpenQA.Selenium;
using PathFactoryAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace PathFactoryAutomation.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private IWebDriver driver;
        private const string validEmail = "test@pathFactory.com";
        private const string invalidEmailFormat = "blablabla";
        private const string validPassword = "pathFactory123";
        private const string invalidPassword = "invalidPassword";

        [SetUp]
        public void Prerequisites()
        {
            //Arrange
            //This logic can be improved, by extracting browser driver creation to some factory
            //if we do that, it will be posible to use different browsers to run tests
            driver = new ChromeDriver();

            // Act
            driver.Navigate().GoToUrl(WebSiteConfiguration.BaseUrl);
            homePage = new HomePage(driver);
            loginPage = homePage.PressSignInButton();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void LoginIsSuccessful_WhenEmailAndPasswordAreCorrect()
        {
            //Act
            loginPage.TypeEmail = validEmail;
            loginPage.TypePassword = validPassword;
            MyAccountPage myAccountPage = loginPage.PressSubmitLoginPositive();

            //Assert
            Assert.That(myAccountPage.GetTitle, Is.EqualTo("My account - My Store"));
        }

        [Test]
        public void ForgotMyPassword_Link_Redirects_To_ForgotPasswordPage()
        {
            //Act
            ForgotPasswordPage forgotPasswordPage = loginPage.PressForgotMyPasswordLink();

            //Assert
            Assert.That(forgotPasswordPage.GetTitle, Is.EqualTo("Forgot your password - My Store"));
        }

        [Test]
        public void LoginFails_WhenPasswordIsIncorrect()
        {
            //Act
            loginPage.TypeEmail = validEmail;
            loginPage.TypePassword = invalidPassword;
            loginPage.PressSubmitLoginNegative();

            //Assert
            Assert.That(loginPage.GetAlertMessage, Is.EqualTo("Authentication failed."));
        }

        [Test]
        public void LoginFails_WhenEmailHadIncorrectFormat()
        {
            //Act
            loginPage.TypeEmail = invalidEmailFormat;
            loginPage.TypePassword = validPassword;
            loginPage.PressSubmitLoginNegative();

            //Assert
            Assert.That(loginPage.GetAlertMessage, Is.EqualTo("Invalid email address."));
        }

        [TestCase("", validPassword, "An email address required.")]
        [TestCase(validEmail, "", "Password is required.")]
        [TestCase("", "", "An email address required.")]
        public void LoginFails_WhenCredentialsEmpty(string email, string password, string alertMessage)
        {
            //Act
            loginPage.TypeEmail = email;
            loginPage.TypePassword = password;
            loginPage.PressSubmitLoginNegative();

            //Assert
            Assert.That(loginPage.GetAlertMessage, Is.EqualTo(alertMessage));
        }
    }
}
