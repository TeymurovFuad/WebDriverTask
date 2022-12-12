using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail
{
    public static class NewMessageBox
    {
        [FindsBy(How = How.XPath, Using = "//div[@aria-label='New Message']")]
        public static IWebElement NewMessageDialogBox { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@name='to']//input")]
        public static IWebElement To { get; private set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        public static IWebElement Subject { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Message Body']")]
        public static IWebElement Body { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='button' and text()='Send']")]
        public static IWebElement SendButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//img[@aria-label='Save & close']")]
        public static IWebElement SaveAndCloseButton_KnownAsX { get; private set; }

        public static void AddReceiver(params string[] addressTo)
        {
            string receivers = String.Join(",", addressTo);
            To.SendKeys(receivers);
        }

        public static void AddSubject(string addressTo)
        {

            Subject.SendKeys(addressTo);
        }

        public static void AddBody(string addressTo)
        {

            Body.SendKeys(addressTo);
        }

        public static void SendMail()
        {
            SendButton.Click();
            CloseNewMailBox();
        }

        private static void CloseNewMailBox()
        {
            if (DriverManager.WaitUntilElementIsInteractable(SaveAndCloseButton_KnownAsX))
                SaveAndCloseButton_KnownAsX.Click();
        }
    }
}
