using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleProject.Pages;
using System.Threading;

namespace SimpleProject.Test
{
    [TestFixture]
    class EmailTest
    {

        IWebDriver driver;
        private const string BaseUrl = "http://www.gmail.com";
        private readonly string User = "testuserservemn@gmail.com";
        private readonly string Pass = "TestUserServeMNPassword";

        private readonly string To = "testuserservemn@gmail.com";
        private readonly string Subject = "Test Email";
        private readonly string Message = "The message of the test email";



        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SimpleLoginTest()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var loginPage = new LoginPage(driver);
            InboxPage inboxPage = loginPage.Login(User, Pass);
            Thread.Sleep(1000);
            inboxPage.SendEmail(To, Subject, Message);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
