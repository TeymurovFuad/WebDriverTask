using Core.Common.Pages;
using Core.Extensions;
using OpenQA.Selenium;

namespace Business.PageObjects.Gmail.Logout
{
    public class LogoutPage : LogoutPageElements, IPage
    {
        IWebDriver webDriver { get; set; }

        public LogoutPage(IWebDriver driver) : base(driver)
        {
            webDriver = driver;
        }

        public bool isLogoutPageDisplayed()
        {
            return ChooseAnAccoutLabel.isElementDisplayed();
        }
    }
}
