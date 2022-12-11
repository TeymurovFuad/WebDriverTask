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
        public IWebElement NotNowButtonOnHelpWorkBetterView { get; set; }

        public void SkipHelpToWorkBetterPage()
        {
            //Temporary workaround
            DriverManager.WaitUntilElementDisplayed(HelpWorkBetterText);
            if (DriverManager.WaitUntilElementIsInteractable(HelpWorkBetterText))
            {
                try
                {
                    NotNowButtonOnHelpWorkBetterView.Click();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
