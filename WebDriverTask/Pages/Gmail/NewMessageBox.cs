using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail
{
    public class NewMessageBox: GmailBaseElements
    {
        [FindsBy(How = How.XPath, Using = "//div[@name='to']//input")]
        private IWebElement To { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        private IWebElement Subject { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Message Body']")]
        private IWebElement Body { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='button' and text()='Send']")]
        private IWebElement SendButton { get; set; }

        public NewMessageBox ComposeNewMail()
        {
            string style = NewMessageDialogBox.GetAttribute("style");
            string pattern = @".*height(.){1,3}\d+";
            if (!Regex.IsMatch(style, pattern))
                ComposeButton.Click();
            DriverManager.WaitUntilElementIsInteractable(SendButton);
            return this;
        }
        public NewMessageBox AddReceiver(params string[] addressTo)
        {
            string receivers = String.Join(",", addressTo);
            To.SendKeys(receivers);
            return this;
        }

        public NewMessageBox AddSubject(string addressTo)
        {

            Subject.SendKeys(addressTo);
            return this;
        }

        public NewMessageBox AddBody(string addressTo)
        {

            Body.SendKeys(addressTo);
            return this;
        }

        public void SendMail()
        {
            SendButton.Click();
            CloseNewMailBox();
        }

        private void CloseNewMailBox()
        {
            string style = NewMessageDialogBox.GetAttribute("style");
            string pattern = @".*height(.){1,3}\d+";
            if (Regex.IsMatch(style, pattern))
                ComposeButton.Click();
        }
    }
}
