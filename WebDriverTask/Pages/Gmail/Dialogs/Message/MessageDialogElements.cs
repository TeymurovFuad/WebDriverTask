﻿using OpenQA.Selenium;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail.Dialogs.Message
{
    public class MessageDialogElements : BasePage
    {
        IWebDriver webDriver { get; set; }
        public MessageDialogElements(IWebDriver driver)
        {
            webDriver = driver;
        }

        private const string _newMailDialogHeader = "New Message";
        private const string _mailDialogXPath = "//h2[div[text()='Compose:'] and div/span[text()='{0}']]";

        public const string ToXPath = "//div[@name='to']//input";
        public IWebElement To => webDriver.FindElements(By.XPath(ToXPath)).First();

        public const string SubjectXPath = "//input[@name='subjectbox']";
        public IWebElement Subject => webDriver.FindElements(By.XPath(SubjectXPath)).First();

        public const string BodyXPath = "//div[@aria-label='Message Body']";
        public IWebElement Body => webDriver.FindElements(By.XPath(BodyXPath)).First();

        public const string SendButtonXPath = "//div[@role='button' and text()='Send']";
        public IWebElement SendButton => webDriver.FindElements(By.XPath(SendButtonXPath)).First();

        public const string SaveAndCloseButtonsXPath = "//img[@aria-label='Save & close']";
        public List<IWebElement> SaveAndCloseButtons => webDriver.FindElements(By.XPath(SaveAndCloseButtonsXPath)).ToList();


        public List<IWebElement> MailDialogs(string dialogHeader)
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogXPath, dialogHeader)!;
            return webDriver.FindElements(By.XPath(pathToDialog)).ToList();
        }

        public List<IWebElement> MailDialogs()
        {
            string pathToDialog = StringHelper.FormatString(_mailDialogXPath, _newMailDialogHeader)!;
            return webDriver.FindElements(By.XPath(pathToDialog)).ToList();
        }

        public IWebElement GetMailDialog(string? mailSubject=null)
        {
            string pathToSpecifiedMessageDialog = StringHelper.FormatString(_mailDialogXPath, mailSubject ?? _newMailDialogHeader)!;
            return webDriver.FindElement(By.XPath(pathToSpecifiedMessageDialog));
        }
    }
}
