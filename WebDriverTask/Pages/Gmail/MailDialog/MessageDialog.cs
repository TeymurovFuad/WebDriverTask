using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Text.RegularExpressions;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail.MailDialog
{
    public static class MessageDialog
    {
        private static string mailBoxHeader { get; set; } = "New Message";

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='New Message']")]
        public static List<IWebElement> MailDialogs { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@name='to']//input")]
        public static IWebElement To { get; private set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        public static IWebElement Subject { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Message Body']")]
        public static IWebElement Body { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='button' and text()='Send']")]
        public static IWebElement SendButton { get; private set; }

        [FindsBy(How = How.XPath, Using = "//img[@aria-label='Save & close']")]
        public static List<IWebElement> SaveAndCloseButtons { get; private set; }

        private static string SetPathToMailDialog(string dialogHeader)
        {
            return $"//h2[div[text()='Compose:'] and div/span[text()='{dialogHeader}']]";
        }

        public static MainPage MainPageInstance()
        {
            MainPage instance = new MainPage();
            return instance;
        }

        public static void AddReceiver(params string[] addressTo)
        {
            string receivers = string.Join(",", addressTo);
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
            CloseMailDialog();
        }


        public static void CloseMailDialog()
        {
            if (SaveAndCloseButtons.Count == 1 && DriverManager.WaitUntilElementIsInteractable(SaveAndCloseButtons.First()))
                SaveAndCloseButtons.First().Click();
            else if (SaveAndCloseButtons.Count > 1)
                CloseAllMailDialogs();
        }

        public static void CloseAllMailDialogs()
        {
            foreach (IWebElement saveAndCloseButton in SaveAndCloseButtons)
            {
                saveAndCloseButton.Click();
            }
        }

        public static void CollapseMailDialog()
        {
            if (MailDialogs.Count > 0)
            {
                foreach (IWebElement mailDialog in MailDialogs)
                {
                    string style = mailDialog.GetAttribute("style");
                    string pattern = @".*height(.){1,3}\d+";
                    if (Regex.IsMatch(style, pattern))
                    {
                        mailDialog.Click();
                    }
                }
            }
        }

        public static void ExpandMailDialog()
        {
            if (MailDialogs.Count > 0)
            {
                foreach (IWebElement mailDialog in MailDialogs)
                {
                    string style = mailDialog.GetAttribute("style");
                    string pattern = @".*height(.){1,3}\d+(px|%)?";
                    if (!Regex.IsMatch(style, pattern))
                    {
                        mailDialog.Click();
                    }
                }
            }
        }

        public static List<IWebElement> GetMailDialogByMailSubject(string mailSubject)
        {
            string pathToDialog = SetPathToMailDialog(mailSubject);
            if (MainPageInstance().isElementDisplayed(By.XPath(pathToDialog)))
            {
                MailDialogs = Driver.GetDriver().FindElements(By.XPath(pathToDialog)).ToList();
            }
            return MailDialogs;
        }
    }
}
