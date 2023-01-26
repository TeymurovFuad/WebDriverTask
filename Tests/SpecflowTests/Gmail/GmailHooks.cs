using Business.Gmail;
using Business;
using Core.Browser;
using Core.Business;
using Core.Common.TestConfig;
using Core.WebDriver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Business.PageObjects.Gmail;
using Tests.SpecflowTests.Gmail.Features;
using Core.Utils.Extensions;

namespace Tests.SpecflowTests.Gmail
{
    [Binding]
    public class GmailHooks
    {

        protected static ScenarioContext scenarioContext;
        private static BrowserType? _browserType { get; set; } = null;
        protected static IWebDriver webDriver { get; set; }
        protected static bool isChained;
        protected static bool _isFailed;
        public static bool StopOnFail { private get; set; }

        protected static User user;
        protected static Mail mail;
        protected static Page page;
        protected static TestData testData = new();
        protected static DriverManager driverManager = new();
        protected static DriverOptions driverOptions;
        protected static MainPage mainPage;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private static void StartBrowser()
        {
            driverManager.BuildDriver(_browserType ?? BrowserType.Firefox, driverOptions);
            webDriver = driverManager.GetWebDriver();
            mainPage = new(webDriver);
        }

        public static void LoginToGmail()
        {
            driverManager.GetWebDriver().GoToUrl(page.Url);
            mainPage.loginPage.ToggleLanguageChooserDropDown();
            mainPage.loginPage.ChangeLanguage(page.Language);
            mainPage.loginPage.Login(user.Email, user.Password);
        }

        public static void BeforeTestRun(ScenarioContext context)
        {
            scenarioContext = context;
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {

        }

        //[BeforeScenario]
        //public void BeforeScenario()
        //{
        //    StartBrowser();
        //}

        [BeforeScenario("@LoginRequired")]
        public void BeforeScenarioWithTag()
        {
            StartBrowser();
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driverManager.QuitDriver();
        }

        [AfterScenario("@LoginRequired")]
        public void AfterScenarioQuit()
        {
        }

        [AfterFeature] 
        public static void AfterFeature()
        {
        }
    }
}