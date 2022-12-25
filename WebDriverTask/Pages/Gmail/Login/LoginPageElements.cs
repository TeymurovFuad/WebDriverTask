using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Login
{
    public class LoginPageElements: BaseElements
    {
        private const string HelpToWorkBetterText = "If you’d like, take a few moments to help Google work better for you";

        public const string EmailFieldId = "identifierId";
        public static IWebElement EmailField => GetDriver().FindElements(By.Id(EmailFieldId)).First();

        public const string PasswordFieldXPath = "//input[@type='password' and @name='Passwd']";
        public static IWebElement PasswordField => GetDriver().FindElements(By.XPath(PasswordFieldXPath)).First();

        public const string HelpWorkBetterTextXPath = $"//div[text()={HelpToWorkBetterText}]";
        public static IWebElement HelpWorkBetterText => GetDriver().FindElements(By.XPath(HelpWorkBetterTextXPath)).First();

        public const string NotNowButtonOnHelpWorkBetterPageXPath = $"//*[text()='Not Now']";
        public static IWebElement NotNowButtonOnHelpWorkBetterPage => GetDriver().FindElements(By.XPath(NotNowButtonOnHelpWorkBetterPageXPath)).First();

        public const string DropDownToChooseLanguageId = "lang-chooser";
        public static IWebElement DropDownToChooseLanguage => GetDriver().FindElements(By.Id(DropDownToChooseLanguageId)).First();

        public const string AllLanguagesFromDropDownXPath = "//ul[@role='listbox']/li";
        public static List<IWebElement> AllLanguagesFromDropDown => GetDriver().FindElements(By.XPath(AllLanguagesFromDropDownXPath)).ToList();
        public static IWebElement CurrentLanguage => GetDriver().FindElements(By.XPath($"{AllLanguagesFromDropDownXPath}[@aria-selected='true']")).First();

        public const string NextButtonXPath = "//button[span[contains(text(), 'Next')]]";
        public static IWebElement NextButton => GetDriver().FindElements(By.XPath(NextButtonXPath)).First();

        private static IWebElement LanguageFromDropDown { get; set; }

        public const string pathToSpecificLanguageFromDropdown = "//span[contains(text(), {0})]";
        public const string subPathToRetreiveLanguageText = "./span/span";
        public const string subPathToCheckDropDownStatus = "//div[@aria-expanded]";

        public static IWebElement FindSpecificLanguageFromDropDown(string language)
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
