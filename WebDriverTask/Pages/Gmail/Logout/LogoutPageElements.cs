using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public static class LogoutPageElements
    {
        [FindsBy(How = How.Id, Using = "//span[text()='Choose an account']")]
        public static IWebElement ChooseAnAccout { get; private set; }
    }
}
