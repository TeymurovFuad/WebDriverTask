using Business;
using Business.PageObjects.Gmail;
using Core.Browser;
using Core.Utils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.SpecflowTests.Gmail.Steps
{
    [Binding]
    public class LoginStepDefinitions: GmailBDDHooks
    {
        private MainPage _mainPage;
        private readonly FirefoxOptions _options = new();
        public LoginStepDefinitions(ScenarioContext context) : base(context)
        {
            _mainPage = new MainPage(webDriver);
        }

        [Given(@"user open gmail login page")]
        public void GivenUserOpenGmailLoginPage(Table table)
        {
            page = table.CreateInstance<Page>();
            driverManager.GetWebDriver().GoToUrl(page.Url);
        }

        [Then(@"verify that login page opened")]
        public void ThenVerifyThatLoginPageOpened()
        {
            bool pageOpened = webDriver.Title.Contains(page.Title, StringComparison.CurrentCultureIgnoreCase);
            Assert.IsTrue(pageOpened);
        }

        [When(@"change page language")]
        public void WhenChangePageLanguage()
        {
            _mainPage.loginPage.ToggleLanguageChooserDropDown();
            _mainPage.loginPage.ChangeLanguage(page.Language);
        }

        [Then(@"verify that page language set correctly")]
        public void ThenVerifyThatPageLanguageSetCorrectly()
        {
            string actualLanguage = _mainPage.loginPage.GetValueOfCurrentSelectedLanguage();
            Assert.IsTrue(actualLanguage.Contains(page.Language, StringComparison.CurrentCultureIgnoreCase));
        }

        [When(@"insert '([^']*)' into then email field")]
        public void WhenInsertIntoThenEmailField(string username)
        {
            _mainPage.loginPage.FillEmail(username);
        }

        [When(@"click next button")]
        public void WhenClickNextButton()
        {
            _mainPage.loginPage.ClickNext();
        }

        [Then(@"verify that page contains password field")]
        public void ThenVerifyThatPageContainsPasswordField()
        {
            bool isPasswordFieldDisplayed = webDriver.WaitUntilElementDisplayed(_mainPage.loginPage.PasswordField).isDisplayed;
            Assert.IsTrue(isPasswordFieldDisplayed);
        }

        [When(@"insert '([^']*)' into then password field")]
        public void WhenInsertIntoThenPasswordField(string password)
        {
            _mainPage.loginPage.FillPassword(password);
        }

        [Then(@"verify that main page opened successfully and title contains '([^']*)'")]
        public void ThenVerifyThatMainPageOpenedSuccessfullyAndTitleContains(string expectedTitle)
        {
            Assert.IsTrue(_mainPage.isTitleDisplayed(expectedTitle));
        }

    }
}
