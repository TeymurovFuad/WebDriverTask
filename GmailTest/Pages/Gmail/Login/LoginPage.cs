using OpenQA.Selenium;
using WebDriverTask.Common.Pages;
using WebDriverTask.Utils.Extensions;

namespace GmailTest.Pages.Gmail.Login
{
    public class LoginPage : LoginPageElements, IPage
    {
        IWebDriver webDriver { get; set; }
        public LoginPage(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public void SkipHelpToWorkBetterPage()
        {
            //Temporary workaround
            webDriver.WaitAndReturnUntilElementIsInteractable(HelpWorkBetterText);
            NotNowButtonOnHelpWorkBetterPage.Click();
        }

        public bool isLanguageChooserDropDownExpanded()
        {
            IWebElement dropDownElement = DropDownToChooseLanguage.GetChild(subPathToCheckDropDownStatus);
            string attributeValue = dropDownElement.GetAttribute("aria-expanded");
            return bool.TryParse(attributeValue, out bool isExpanded) && isExpanded;
        }

        public void ToggleLanguageChooserDropDown()
        {
            webDriver.WaitAndReturnUntilElementIsInteractable(DropDownToChooseLanguage);
            DropDownToChooseLanguage.Click();
        }

        public string GetValueOfCurrentSelectedLanguage()
        {
            webDriver.WaitUntilElementDisplayed(CurrentLanguage);
            return CurrentLanguage.GetChild(subPathToRetreiveLanguageText).Text;
        }

        public string GetValueOfLanguage(IWebElement language)
        {
            return language.GetChild(subPathToRetreiveLanguageText).Text;
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
            webDriver.WaitAndReturnUntilElementIsInteractable(EmailField);
            EmailField.SendKeys(email);
        }

        public void FillPassword(string password)
        {
            webDriver.WaitAndReturnUntilElementIsInteractable(PasswordField);
            PasswordField.SendKeys(password);
        }

        public void ClickNext()
        {
            NextButton.Click();
            webDriver.WaitPageToLoad();
        }

        public void Login(string email, string password)
        {
            FillEmail(email);
            ClickNext();
            FillPassword(password);
            ClickNext();
            webDriver.WaitPageToLoad();
        }
    }
}
