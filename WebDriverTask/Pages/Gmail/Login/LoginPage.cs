using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.Login
{
    public class LoginPage: MainPage
    {
        public LoginPage()
        {
            //PageFactory
        }

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
            string? languageValue = LoginPageElements.CurrentLanguage.FindElement(By.XPath(LoginPageElements.subPathToRetreiveLanguageText)).Text;
            return languageValue ?? string.Empty;
        }

        public static string GetValueOfLanguage(IWebElement language)
        {
            return language.FindElement(By.XPath(LoginPageElements.subPathToRetreiveLanguageText)).Text;
        }

        public static void ChangeLanguage(string languageToChange)
        {
            if (!GetValueOfCurrentSelectedLanguage().Contains(languageToChange, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (IWebElement language in LoginPageElements.AllLanguagesFromDropDown)
                {
                    if (GetValueOfLanguage(language).Contains(languageToChange, StringComparison.InvariantCultureIgnoreCase))
                    {
                        language.Click();
                        break;
                    }
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
