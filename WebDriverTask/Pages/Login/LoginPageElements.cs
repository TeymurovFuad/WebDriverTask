using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Login
{
    public abstract class LoginPageElements: BaseElements
    {
        private const string HelpToWorkBetterText = "If you’d like, take a few moments to help Google work better for you";

        [FindsBy(How = How.Id, Using = "identifierId")]
        public List<IWebElement> EmailField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='password' and @name='Passwd']")]
        public List<IWebElement> PasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = $"//div[text()={HelpToWorkBetterText}]")]
        public IWebElement HelpWorkBetterText { get; set; }

        [FindsBy(How = How.XPath, Using = $"//*[text()='Not Now']")]
        public IWebElement NotNowButtonOnHelpWorkBetterPage { get; set; }

        [FindsBy(How = How.Id, Using = "lang-chooser")]
        public IWebElement DropDownToChooseLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='lang-chooser']//ul/li]")]
        public List<IWebElement> AllLanguagesFromDropDown { get; set; }

        private IWebElement LanguageFromDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[span[contains(text(), 'Next')]]")]
        public List<IWebElement> NextButton { get; set; }

        public IWebElement FindSpecificLanguageFromDropDown(string language)
        {
            foreach (IWebElement element in AllLanguagesFromDropDown)
            {
                try
                {
                    if (element.FindElement(By.XPath($"//span[contains(text(), {language})]")).Displayed)
                    {
                        LanguageFromDropDown = element;
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    throw;
                }
            }
            return LanguageFromDropDown;
        }

        public void SkipHelpToWorkBetterPage()
        {
            //Temporary workaround
            DriverManager.WaitUntilElementDisplayed(HelpWorkBetterText);
            if (DriverManager.WaitUntilElementIsInteractable(HelpWorkBetterText))
            {
                try
                {
                    NotNowButtonOnHelpWorkBetterPage.Click();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
