﻿using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail.Login
{
    public class LoginPageElements: BasePage
    {
        IWebDriver webDriver { get; set; }
        public LoginPageElements(IWebDriver driver)
        {
            webDriver = driver;
        }

        private readonly string HelpToWorkBetterText = "If you’d like, take a few moments to help Google work better for you";

        public readonly string EmailFieldId = "identifierId";
        public IWebElement EmailField => webDriver.FindElements(By.Id(EmailFieldId)).First();

        public readonly string PasswordFieldXPath = "//input[@type='password' and @name='Passwd']";
        public IWebElement PasswordField => webDriver.FindElements(By.XPath(PasswordFieldXPath)).First();

        public string HelpWorkBetterTextXPath => $"//div[text()={HelpToWorkBetterText}]";
        public IWebElement HelpWorkBetterText => webDriver.FindElements(By.XPath(HelpWorkBetterTextXPath)).First();

        public readonly string NotNowButtonOnHelpWorkBetterPageXPath = $"//*[text()='Not Now']";
        public IWebElement NotNowButtonOnHelpWorkBetterPage => webDriver.FindElements(By.XPath(NotNowButtonOnHelpWorkBetterPageXPath)).First();

        public readonly string DropDownToChooseLanguageId = "lang-chooser";
        public IWebElement DropDownToChooseLanguage => webDriver.FindElement(By.Id(DropDownToChooseLanguageId));

        public readonly string AllLanguagesFromDropDownXPath = "//ul[@role='listbox']/li";
        public List<IWebElement> AllLanguagesFromDropDown => webDriver.FindElements(By.XPath(AllLanguagesFromDropDownXPath)).ToList();
        public IWebElement CurrentLanguage => webDriver.FindElements(By.XPath($"{AllLanguagesFromDropDownXPath}[@aria-selected='true']")).First();

        public readonly string NextButtonXPath = "//button[span[contains(text(), 'Next')]]";
        public IWebElement NextButton => webDriver.FindElements(By.XPath(NextButtonXPath)).First();

        private IWebElement LanguageFromDropDown { get; set; }

        public readonly string pathToSpecificLanguageFromDropdown = "//span[contains(text(), {0})]";
        public readonly string subPathToRetreiveLanguageText = "./span/span";
        public readonly string subPathToCheckDropDownStatus = "//div[@aria-expanded]";

        public IWebElement FindSpecificLanguageFromDropDown(string language)
        {
            string xpathToLanguage = StringHelper.FormatString(pathToSpecificLanguageFromDropdown, language.Capitalise())!;

            foreach (IWebElement element in AllLanguagesFromDropDown)
            {
                if (element.FindElement(By.XPath(xpathToLanguage)).Displayed)
                {
                    LanguageFromDropDown = element;
                    break;
                }
            }
            return LanguageFromDropDown;
        }
    }
}
