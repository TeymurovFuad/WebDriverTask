using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public class LogoutPageElements: BaseElements
    {
        public readonly string ChooseAnAccoutXPath =  "//span[text()='Choose an account']";
        public IWebElement ChooseAnAccout => GetDriver().FindElements(By.XPath(ChooseAnAccoutXPath)).First();
    }
}
