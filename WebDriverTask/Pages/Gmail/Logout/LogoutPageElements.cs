using OpenQA.Selenium;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public class LogoutPageElements: BaseElements
    {
        public readonly string ChooseAnAccoutXPath =  "//span[text()='Choose an account']";
        public IWebElement ChooseAnAccout => DriverInstance().FindElements(By.XPath(ChooseAnAccoutXPath)).First();
    }
}
