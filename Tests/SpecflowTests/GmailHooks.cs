﻿using Business.Gmail;
using Business;
using Core.Browser;
using Core.Business;
using Core.Common.TestConfig;
using Core.WebDriver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Business.PageObjects.Gmail;
using Tests.SpecflowTests.Features;
using Core.Utils.Extensions;
using OpenQA.Selenium.Firefox;
using BoDi;
using NUnit.Framework;

namespace Tests.SpecflowTests
{
    [Binding]
    public class GmailHooks
    {

        private static BrowserType? _browserType { get; set; } = null;
        protected static IWebDriver webDriver { get; set; }

        private readonly IObjectContainer _objectContainer;
        //protected static User _user;
        //protected static Mail mail;
        //protected static Page _page;
        protected static DriverManager driverManager;
        protected static DriverOptions driverOptions;
        protected static MainPage mainPage;

        protected GmailHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            driverManager = new DriverManager();
        }

        private void StartBrowser()
        {
            driverManager.BuildDriver(_browserType ?? BrowserType.Firefox, driverOptions);
            webDriver = driverManager.GetWebDriver();
            mainPage = new(webDriver);
            _objectContainer.RegisterInstanceAs(driverManager);
        }

        //public void LoginToGmail()
        //{
        //    driverManager.GetWebDriver().GoToUrl(_page.Url);
        //    mainPage.loginPage.ToggleLanguageChooserDropDown();
        //    mainPage.loginPage.ChangeLanguage(_page.Language);
        //    mainPage.loginPage.Login(_user.Email, _user.Password);
        //}

        [BeforeFeature]
        public static void BeforeFeature() { }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario() => StartBrowser();

        [BeforeScenario("@UI", Order = 1)]
        public void BeforeScenarioUI() { }

        [BeforeScenario("@LoginRequired", Order = 1)]
        public void BeforeScenarioLogin() { }

        [BeforeScenario]
        public void FirstBeforeScenario() { }

        [AfterScenario]
        public void AfterScenario() => driverManager.QuitDriver();

        [AfterFeature]
        public static void AfterFeature() { }
    }
}