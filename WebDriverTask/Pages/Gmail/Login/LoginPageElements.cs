using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail.Login
{
    public class LoginPageElements: BaseElements
    {
        private readonly string HelpToWorkBetterText = "If you’d like, take a few moments to help Google work better for you";

        public readonly string EmailFieldId = "identifierId";
        public IWebElement EmailField => DriverInstance().FindElements(By.Id(EmailFieldId)).First();

        public readonly string PasswordFieldXPath = "//input[@type='password' and @name='Passwd']";
        public IWebElement PasswordField => DriverInstance().FindElements(By.XPath(PasswordFieldXPath)).First();

        public string HelpWorkBetterTextXPath => $"//div[text()={HelpToWorkBetterText}]";
        public IWebElement HelpWorkBetterText => DriverInstance().FindElements(By.XPath(HelpWorkBetterTextXPath)).First();

        public readonly string NotNowButtonOnHelpWorkBetterPageXPath = $"//*[text()='Not Now']";
        public IWebElement NotNowButtonOnHelpWorkBetterPage => DriverInstance().FindElements(By.XPath(NotNowButtonOnHelpWorkBetterPageXPath)).First();

        public readonly string DropDownToChooseLanguageId = "lang-chooser";
        dynamic x => DriverInstance().FindElement(By.Id(DropDownToChooseLanguageId));
        public IWebElement DropDownToChooseLanguage => DriverInstance().FindElement(By.Id(DropDownToChooseLanguageId));

        public readonly string AllLanguagesFromDropDownXPath = "//ul[@role='listbox']/li";
        public List<IWebElement> AllLanguagesFromDropDown => DriverInstance().FindElements(By.XPath(AllLanguagesFromDropDownXPath)).ToList();
        public IWebElement CurrentLanguage => DriverInstance().FindElements(By.XPath($"{AllLanguagesFromDropDownXPath}[@aria-selected='true']")).First();

        public readonly string NextButtonXPath = "//button[span[contains(text(), 'Next')]]";
        public IWebElement NextButton => DriverInstance().FindElements(By.XPath(NextButtonXPath)).First();

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
