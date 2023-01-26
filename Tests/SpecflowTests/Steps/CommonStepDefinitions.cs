using Business;
using Business.PageObjects.Gmail;
using Core.Business;
using Core.Utils.Extensions;
using Core.WebDriver;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Tests.SpecflowTests.Steps
{
    [Binding]
    public class CommonStepDefinitions
    {
        MainPage _mainPage;
        Page _page;
        User _user;
        DriverManager _driverManager;

        private CommonStepDefinitions(DriverManager driverManager, ScenarioContext scenarioContext)
        {
            _driverManager = driverManager;
            _mainPage = new(_driverManager.GetDriver());
            _page = new(title: "Gmail", language: "English", url: "https://mail.google.com/");
            _user = new(email: "qy54313@gmail.com", password: "Aa123456_");
            scenarioContext.Add("user", _user);
            scenarioContext.Add("page", _page);
        }

        [Given(@"user logs in to Gmail as '([^']*)'")]
        public void GivenUserLogsInToGmailAs(string email)
        {
            _driverManager.GetDriver().GoToUrl(_page.Url);
            _mainPage.loginPage.ToggleLanguageChooserDropDown();
            _mainPage.loginPage.ChangeLanguage(_page.Language);
            _mainPage.loginPage.Login(email, _user.Password);
        }

        [Given(@"user logs in to Gmail")]
        public void GivenUserLogsInToGmail()
        {
            _driverManager.GetDriver().GoToUrl(_page.Url);
            _mainPage.loginPage.ToggleLanguageChooserDropDown();
            _mainPage.loginPage.ChangeLanguage(_page.Language);
            _mainPage.loginPage.Login(_user.Email, _user.Password);
        }
    }
}
