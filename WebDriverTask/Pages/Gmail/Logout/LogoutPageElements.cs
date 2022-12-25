using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.WebDriver;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public class LogoutPageElements: BaseElements
    {
        public const string ChooseAnAccoutXPath =  "//span[text()='Choose an account']";
        public static IWebElement ChooseAnAccout => GetDriver().FindElements(By.XPath(ChooseAnAccoutXPath)).First();
    }
}
