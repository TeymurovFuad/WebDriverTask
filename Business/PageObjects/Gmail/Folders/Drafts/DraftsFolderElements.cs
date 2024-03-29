﻿using Business.PageObjects.Gmail.ContextMenu.Dialogs.Message;
using Core.Extensions;
using Core.Utils.Extensions;
using OpenQA.Selenium;

namespace Business.PageObjects.Gmail.Folders.Drafts
{
    public class DraftsFolderElements : MessageDialog
    {
        IWebDriver webDriver;
        public DraftsFolderElements(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        protected readonly string FolderName = "Drafts";

        public By NoMailsInDraftLocator => By.XPath("td[text()=\"You don't have any saved drafts.\"]");
        public IWebElement NoMailsInDraft => webDriver.GetElement(NoMailsInDraftLocator);

        public By DraftMailsLocator { get; private set; } = By.XPath("//span[text()='Draft']/ancestor::tr");
        public List<IWebElement> DraftMails => webDriver.GetElements(DraftMailsLocator);

        public By GetDraftMailsByValueLocator(string subjectOrBody) => By.XPath($"{DraftMailsLocator.GetLocatorValue()}//span[text()='{subjectOrBody}' and parent::span]");
        public List<IWebElement> GetDraftMailsByValue(string subjectOrBody) => webDriver.GetElements(GetDraftMailsByValueLocator(subjectOrBody));
        public IWebElement GetDraftMailByValue(string subjectOrBody) => webDriver.JsGetElement(GetDraftMailsByValueLocator(subjectOrBody));
    }
}
