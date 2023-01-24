﻿using Core.Common.Pages;
using Core.Extensions;
using Core.Utils.Extensions;
using Core.Utils.Helpers;
using OpenQA.Selenium;

namespace Business.PageObjects.Gmail.ContextMenu.Dialogs.Account
{
    public class AccountDialogElements : BasePage
    {
        IWebDriver webDriver { get; set; }
        public AccountDialogElements(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public readonly By AccountIFrameLocator = By.XPath("//iframe[@name='account']");
        public IWebElement AccountIFrame => webDriver.GetElement(AccountIFrameLocator);

        public readonly By SingOutButtonLocator = By.XPath("//a[contains(@href, 'Logout')]");
        public IWebElement SignOutButton => webDriver.GetElement(SingOutButtonLocator);

        private readonly By _openAccountDialogButtonLocator = By.XPath("//a[contains(@aria-label, '{0}') and contains(@href, 'SignOut')]");

        public IWebElement OpenAccountDialogButton(string email)
        {
            string formattedPath = StringHelper.FormatString(_openAccountDialogButtonLocator.GetLocatorValue(), email)!;
            return webDriver.GetElement(By.XPath(formattedPath));
        }
    }
}
