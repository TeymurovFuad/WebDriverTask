using Core.Browser;
using Core.WebDriver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Business.PageObjects.Gmail;
using BoDi;
using ILogger = Serilog.ILogger;
using Core.Utils.LogConfig;

namespace Tests.SpecflowTests
{
    [Binding]
    public class GmailHooks
    {

        private static BrowserType? _browserType { get; set; } = null;
        protected static IWebDriver webDriver { get; set; }
        protected static ILogger log { get { return MessageLogger.GetLogger(); } }

        private readonly IObjectContainer _objectContainer;
        private static ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext;
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
        //    onliner.loginPage.ToggleLanguageChooserDropDown();
        //    onliner.loginPage.ChangeLanguage(_page.Language);
        //    onliner.loginPage.Login(_user.Email, _user.Password);
        //}

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureContext ??= featureContext;
            log.Information($"Starting feature\n" +
                $"\tTitle: {_featureContext.FeatureInfo.Title}\n" +
                $"\tDescription:{_featureContext.FeatureInfo.Description}\n" +
                $"\tTags:{string.Join(",", _featureContext.FeatureInfo.Tags)}\n");
        }


        [BeforeScenario()]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenarioContext ??= scenarioContext;
            StartBrowser();
            log.Information($"Starting scenario\n" +
                $"\nTitle: {_scenarioContext.ScenarioInfo.Title}\n" +
                $"\tDescription:{_scenarioContext.ScenarioInfo.Description}\n" +
                $"\tTags:{string.Join(",", _scenarioContext.ScenarioInfo.Tags)}\n");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            ScenarioExecutionStatus status = _scenarioContext.ScenarioExecutionStatus;
            switch (status)
            {
                case ScenarioExecutionStatus.OK:
                case ScenarioExecutionStatus.Skipped:
                    log.Information($"End scenario with status => {status}");
                    break;
                case ScenarioExecutionStatus.TestError:
                case ScenarioExecutionStatus.BindingError:
                case ScenarioExecutionStatus.UndefinedStep:
                    log.Information($"End scenario with status => {status}");
                    break;
                default:
                    log.Information($"End scenario with status => {status}");
                    break;

            }
            driverManager.QuitDriver();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            log.Information($"End feature => {_featureContext.FeatureInfo.Title}");
        }
    }
}