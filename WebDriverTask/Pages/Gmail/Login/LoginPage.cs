using OpenQA.Selenium;
using WebDriverTask.Core.Extensions;

namespace WebDriverTask.Pages.Gmail.Login
{
    public class LoginPage: LoginPageElements
    {
        IWebDriver webDriver { get; set; }
        public LoginPage(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        public void SkipHelpToWorkBetterPage()
        {
            //Temporary workaround
            webDriver.WaitUntilElementIsInteractable(HelpWorkBetterText);
            NotNowButtonOnHelpWorkBetterPage.Click();
        }

        public bool isLanguageChooserDropDownExpanded()
        {
            IWebElement dropDownElement = DropDownToChooseLanguage.FindElement(By.XPath(subPathToCheckDropDownStatus));
            string attributeValue = dropDownElement.GetAttribute("aria-expanded");
            return bool.TryParse(attributeValue, out bool isExpanded) && isExpanded;
        }

        public void ToggleLanguageChooserDropDown()
        {
            webDriver.WaitUntilElementIsInteractable(DropDownToChooseLanguage);
            DropDownToChooseLanguage.Click();
        }

        public string GetValueOfCurrentSelectedLanguage()
        {
            string? languageValue = CurrentLanguage.FindElement(By.XPath(subPathToRetreiveLanguageText)).Text;
            return languageValue ?? string.Empty;
        }

        public string GetValueOfLanguage(IWebElement language)
        {
            return language.FindElement(By.XPath(subPathToRetreiveLanguageText)).Text;
        }

        public void ChangeLanguage(string languageToChange)
        {
            if (!GetValueOfCurrentSelectedLanguage().Contains(languageToChange, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (IWebElement language in AllLanguagesFromDropDown)
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
            webDriver.WaitUntilElementIsInteractable(EmailField);
            EmailField.SendKeys(email);
        }

        public void FillPassword(string password)
        {
            webDriver.WaitUntilElementIsInteractable(PasswordField);
            PasswordField.SendKeys(password);
        }

        public void ClickNext()
        {
            NextButton.Click();
            webDriver.WaitPageToLoad();
        }
    }
}
