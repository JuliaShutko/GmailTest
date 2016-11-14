using OpenQA.Selenium;
using System.Threading;

namespace SimpleProject.Pages
{
    class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UserNameInput
        {
            get { return _driver.FindElement(By.Id("Email")); }
        }

        private IWebElement PasswordInput
        {
            get { return _driver.FindElement(By.Id("Passwd")); }
        }

        private IWebElement NextButton
        {
            get { return _driver.FindElement(By.Id("next")); }
        }

        private IWebElement LoginButton
        {
            get { return _driver.FindElement(By.Id("signIn")); }
        }

        private IWebElement LogOutButton
        {
            get { return _driver.FindElement(By.XPath("//*[text()='Sign out']")); }
        }

        public InboxPage Login(string user, string pass)
        {
            UserNameInput.SendKeys(user);
            NextButton.Click();
            Thread.Sleep(1000);
            PasswordInput.SendKeys(pass);
            LoginButton.Click();
            return new InboxPage(_driver);
        }
    }
}
