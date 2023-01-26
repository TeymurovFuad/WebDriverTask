using Business.PageObjects.Gmail;
using Business;
using Core.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Core.Utils.Extensions;
using Core.Common.TestConfig;
using Core.Business;

namespace Tests.SpecflowTests.Steps.Gmail
{
    [Binding]
    public class LoginStepDefinitions
    {
        MainPage _mainPage;
        DriverManager _driverManager;
        Page _page;
        public LoginStepDefinitions(ScenarioContext context, DriverManager driverManager)
        {
            _driverManager = driverManager;
            _mainPage = new(_driverManager.GetDriver());
        }

        [Given(@"user open gmail login page")]
        public void GivenUserOpenGmailLoginPage(Table table)
        {
            _page = table.CreateInstance<Page>();
            _driverManager.GetDriver().GoToUrl(_page.Url);
        }

        [Then(@"verify that login page opened")]
        public void ThenVerifyThatLoginPageOpened()
        {
            bool pageOpened = _driverManager.GetDriver().Title.Contains(_page.Title, StringComparison.CurrentCultureIgnoreCase);
            Assert.IsTrue(pageOpened);
        }

        [When(@"change page language")]
        public void WhenChangePageLanguage()
        {
            _mainPage.loginPage.ToggleLanguageChooserDropDown();
            _mainPage.loginPage.ChangeLanguage(_page.Language);
        }

        [Then(@"verify that page language set correctly")]
        public void ThenVerifyThatPageLanguageSetCorrectly()
        {
            string actualLanguage = _mainPage.loginPage.GetValueOfCurrentSelectedLanguage();
            Assert.IsTrue(actualLanguage.Contains(_page.Language, StringComparison.CurrentCultureIgnoreCase));
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
            bool isPasswordFieldDisplayed = _driverManager.GetDriver().WaitUntilElementDisplayed(_mainPage.loginPage.PasswordField).isDisplayed;
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
