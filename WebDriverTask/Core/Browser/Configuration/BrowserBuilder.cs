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
