using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public class LogoutPageElements: BasePage
    {
        IWebDriver webDriver { get; set; }
        public LogoutPageElements(IWebDriver driver): base(driver)
        {
            webDriver = driver;
        }

        public readonly string ChooseAnAccoutXPath =  "//span[text()='Choose an account']";
        public IWebElement ChooseAnAccout => webDriver.FindElements(By.XPath(ChooseAnAccoutXPath)).First();
    }
}
