using OpenQA.Selenium;
using WebDriverTask.Core.Helpers;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail.Login
{
    public class LoginPage: MainPage
    {
        public void SkipHelpToWorkBetterPage()
        {
            //Temporary workaround
            WaitUntilElementDisplayed(LoginPageElements.HelpWorkBetterText);
            if (WaitUntilElementIsInteractable(LoginPageElements.HelpWorkBetterText))
            {
                try
                {
                    LoginPageElements.NotNowButtonOnHelpWorkBetterPage.Click();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static IWebElement? GetCurrentSelectedLanguageElement()
        {
            foreach (IWebElement language in LoginPageElements.AllLanguagesFromDropDown)
            {
                if (language.GetAttribute("aria-selected") == "true")
                {
                    return language;
                }
            }
            return null;
        }

        public static bool isLanguageChooserDropDownExpanded()
        {
            IWebElement dropDownElement = LoginPageElements.DropDownToChooseLanguage.FindElement(By.XPath(LoginPageElements.subPathToCheckDropDownStatus));
            string attributeValue = dropDownElement.GetAttribute("aria-expanded");
            return bool.TryParse(attributeValue, out bool isExpanded) && isExpanded;
        }

        public static void ToggleLanguageChooserDropDown()
        {
            WaitUntilElementIsInteractable(LoginPageElements.DropDownToChooseLanguage);
            LoginPageElements.DropDownToChooseLanguage.Click();
        }

        public static string GetValueOfCurrentSelectedLanguage()
        {
            if(GetCurrentSelectedLanguageElement() != null)
            {
                return GetCurrentSelectedLanguageElement()!.FindElement(By.XPath(LoginPageElements.subPathToRetreiveLanguageText)).Text;
            }
            return string.Empty;
        }

        public static string GetValueOfLanguage(IWebElement language)
        {
            return language.FindElement(By.XPath(LoginPageElements.subPathToRetreiveLanguageText)).Text;
        }

        public static void ChangeLanguage(string languageToChange)
        {
            foreach(IWebElement language in LoginPageElements.AllLanguagesFromDropDown)
            {
                if (GetValueOfLanguage(language).Contains(languageToChange, StringComparison.InvariantCultureIgnoreCase))
                {
                    language.Click();
                }
            }
        }

        public static void FillEmail(string email)
        {
            WaitUntilElementIsInteractable(LoginPageElements.EmailField);
            LoginPageElements.EmailField.SendKeys(email);
        }

        public static void FillPassword(string password)
        {
            WaitUntilElementIsInteractable(LoginPageElements.PasswordField);
            LoginPageElements.PasswordField.SendKeys(password);
        }

        public static void ClickNext()
        {
            LoginPageElements.NextButton.Click();
            WaitPageToLoad();
        }
    }
}
