using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.Helpers;

namespace WebDriverTask.Pages.Gmail.Login
{
    public class LoginPageElements
    {
        private const string HelpToWorkBetterText = "If you’d like, take a few moments to help Google work better for you";

        [FindsBy(How = How.Id, Using = "identifierId")]
        public static IWebElement EmailField { get; private set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='password' and @name='Passwd']")]
        public static IWebElement PasswordField { get; private set; }

        [FindsBy(How = How.XPath, Using = $"//div[text()={HelpToWorkBetterText}]")]
        public static IWebElement HelpWorkBetterText { get; private set; }

        [FindsBy(How = How.XPath, Using = $"//*[text()='Not Now']")]
        public static IWebElement NotNowButtonOnHelpWorkBetterPage { get; private set; }

        [FindsBy(How = How.Id, Using = "lang-chooser")]
        public static IWebElement DropDownToChooseLanguage { get; private set; }

        [FindsBy(How = How.XPath, Using = "//ul[@aria-label='Change language']/li")]
        public static List<IWebElement> AllLanguagesFromDropDown { get; private set; }

        [FindsBy(How = How.XPath, Using = "//button[span[contains(text(), 'Next')]]")]
        public static IWebElement NextButton { get; private set; }

        private IWebElement LanguageFromDropDown { get; set; }

        public const string pathToSpecificLanguageFromDropdown = "//span[contains(text(), {0})]";
        public const string subPathToRetreiveLanguageText = "/span/span";
        public const string subPathToCheckDropDownStatus = "//div[@aria-expanded]";

        public IWebElement FindSpecificLanguageFromDropDown(string language)
        {
            string xpathToLanguage = StringHelper.FormatString(LoginPageElements.pathToSpecificLanguageFromDropdown, language)!;

            foreach (IWebElement element in LoginPageElements.AllLanguagesFromDropDown)
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
