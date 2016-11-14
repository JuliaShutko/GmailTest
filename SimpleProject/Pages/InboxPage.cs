using OpenQA.Selenium;
using System.Threading;

namespace SimpleProject.Pages
{
    class InboxPage
    {
        private readonly IWebDriver _driver;

        public InboxPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement NewEmailButton
        {
            get { return _driver.FindElement(By.XPath("//*[text()='COMPOSE']")); }
        }

        private IWebElement ToInput
        {
            get { return _driver.FindElement(By.Name("to")); }
        }

        private IWebElement SubjectInput
        {
            get { return _driver.FindElement(By.Name("subjectbox")); }
        }

//        private IWebElement MessageInput
//        {
//            get { return _driver.FindElement(By.Id(":fg")); }
//        }

        private IWebElement SendButton
        {
            get { return _driver.FindElement(By.XPath("//*[text()='Send']")); }
        }

        public void SendEmail(string to, string subject, string message)
        {
            NewEmailButton.Click();
            Thread.Sleep(1000);
            ToInput.SendKeys(to);
            SubjectInput.SendKeys(subject + Keys.Tab + message);
            SendButton.Click();
        }
    }
}
