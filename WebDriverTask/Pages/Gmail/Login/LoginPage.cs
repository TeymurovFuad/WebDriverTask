using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.Login
{
    public class LoginPage: MainPage
    {
        readonly LoginPageElements _loginPageElements;
        public LoginPage()
        {
            _loginPageElements= new LoginPageElements();
        }

        public void SkipHelpToWorkBetterPage()
        {
            //Temporary workaround
            WaitUntilElementDisplayed(_loginPageElements.HelpWorkBetterText);
            if (WaitUntilElementIsInteractable(_loginPageElements.HelpWorkBetterText))
            {
                try
                {
                    _loginPageElements.NotNowButtonOnHelpWorkBetterPage.Click();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool isLanguageChooserDropDownExpanded()
        {
            IWebElement dropDownElement = _loginPageElements.DropDownToChooseLanguage.FindElement(By.XPath(_loginPageElements.subPathToCheckDropDownStatus));
            string attributeValue = dropDownElement.GetAttribute("aria-expanded");
            return bool.TryParse(attributeValue, out bool isExpanded) && isExpanded;
        }

        public void ToggleLanguageChooserDropDown()
        {
            WaitUntilElementIsInteractable(_loginPageElements.DropDownToChooseLanguage);
            _loginPageElements.DropDownToChooseLanguage.Click();
        }

        public string GetValueOfCurrentSelectedLanguage()
        {
            string? languageValue = _loginPageElements.CurrentLanguage.FindElement(By.XPath(_loginPageElements.subPathToRetreiveLanguageText)).Text;
            return languageValue ?? string.Empty;
        }

        public string GetValueOfLanguage(IWebElement language)
        {
            return language.FindElement(By.XPath(_loginPageElements.subPathToRetreiveLanguageText)).Text;
        }

        public void ChangeLanguage(string languageToChange)
        {
            if (!GetValueOfCurrentSelectedLanguage().Contains(languageToChange, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (IWebElement language in _loginPageElements.AllLanguagesFromDropDown)
                {
                    if (GetValueOfLanguage(language).Contains(languageToChange, StringComparison.InvariantCultureIgnoreCase))
                    {
                        language.Click();
                        break;
                    }
                }
            }
        }

        public void FillEmail(string email)
        {
            WaitUntilElementIsInteractable(_loginPageElements.EmailField);
            _loginPageElements.EmailField.SendKeys(email);
        }

        public void FillPassword(string password)
        {
            WaitUntilElementIsInteractable(_loginPageElements.PasswordField);
            _loginPageElements.PasswordField.SendKeys(password);
        }

        public void ClickNext()
        {
            _loginPageElements.NextButton.Click();
            WaitPageToLoad();
        }
    }
}
