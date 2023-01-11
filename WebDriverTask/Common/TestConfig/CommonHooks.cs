using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using WebDriverTask.Core.Browser;
using WebDriverTask.Core.Extensions;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Common.TestConfig
{
    public abstract class CommonHooks
    {
        protected IWebDriver webDriver { get; private set; }

        public bool StopOnFail { private get; set; }

        protected CommonHooks() { }
        protected CommonHooks(BrowserType browserType) { }

        [OneTimeSetUp]
        public void ClassSetUp() { }

        [SetUp]
        public void TestSetup() { }

        [TearDown]
        public void TestTearDown() { }

        [OneTimeTearDown]
        public void ClassTearDown() { }
    }
}
