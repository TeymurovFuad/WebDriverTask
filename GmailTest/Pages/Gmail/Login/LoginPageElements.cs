using OpenQA.Selenium;
using WebDriverTask.Common.Pages;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;

namespace GmailTest.Pages.Gmail.Login
{
    public class LoginPageElements: BasePage
    {
        IWebDriver webDriver { get; set; }
        public LoginPageElements(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        private readonly string HelpToWorkBetterText = "If you’d like, take a few moments to help Google work better for you";

        public readonly By EmailFieldId = By.Id("identifierId");
        public IWebElement EmailField => webDriver.GetElement(EmailFieldId);

        public readonly By PasswordFieldLocator = By.XPath("//input[@type='password' and @name='Passwd']");
        public IWebElement PasswordField => webDriver.GetElement(PasswordFieldLocator);

        public By HelpWorkBetterTextLocator => By.XPath($"//div[text()={HelpToWorkBetterText}]");
        public IWebElement HelpWorkBetterText => webDriver.GetElement(HelpWorkBetterTextLocator);

        public readonly By NotNowButtonOnHelpWorkBetterPageLocator = By.XPath($"//*[text()='Not Now']");
        public IWebElement NotNowButtonOnHelpWorkBetterPage => webDriver.GetElement(NotNowButtonOnHelpWorkBetterPageLocator);

        public readonly By DropDownToChooseLanguageId = By.Id("lang-chooser");
        public IWebElement DropDownToChooseLanguage => webDriver.GetElement(DropDownToChooseLanguageId);

        public readonly By AllLanguagesFromDropDownLocator = By.XPath("//ul[@role='listbox']/li");
        public List<IWebElement> AllLanguagesFromDropDown => webDriver.GetElements(AllLanguagesFromDropDownLocator).ToList();
        public IWebElement CurrentLanguage => webDriver.GetElement(By.XPath($"{AllLanguagesFromDropDownLocator.GetLocatorValue()}[@aria-selected='true']"));

        public readonly string NextButtonLocator = "//button[span[contains(text(), 'Next')]]";
        public IWebElement NextButton => webDriver.GetElement(By.XPath(NextButtonLocator));

        private IWebElement LanguageFromDropDown { get; set; }

        public readonly By pathToSpecificLanguageFromDropdown = By.XPath("//span[contains(text(), {0})]");
        public readonly By subPathToRetreiveLanguageText = By.XPath("./span/span");
        public readonly By subPathToCheckDropDownStatus = By.XPath("//div[@aria-expanded]");

        public IWebElement FindSpecificLanguageFromDropDown(string language)
        {
            string xpathToLanguage = StringHelper.FormatString(pathToSpecificLanguageFromDropdown.GetLocatorValue(), language.Capitalise())!;

            foreach (IWebElement element in AllLanguagesFromDropDown)
            {
                if (element.GetChild(By.XPath(xpathToLanguage)).Displayed)
                {
                    LanguageFromDropDown = element;
                    break;
                }
            }
            return LanguageFromDropDown;
        }
    }
}
