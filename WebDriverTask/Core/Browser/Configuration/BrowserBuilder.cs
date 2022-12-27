using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverTask.Core.CustomExceptions;

namespace WebDriverTask.Core.Browser.Configuration
{
    public abstract class BrowserBuilder : BrowserFactory
    {
        protected BrowserBuilder() { }

        protected void Build(BrowserType browserType)
        {
            CreateBrowser(browserType);
        }
    }
}
