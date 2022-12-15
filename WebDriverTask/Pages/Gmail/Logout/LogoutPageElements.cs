using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Pages.Gmail.Logout
{
    public static class LogoutPageElements
    {
        [FindsBy(How = How.Id, Using = "//span[text()='Choose an account']")]
        public static IWebElement ChooseAnAccout { get; private set; }
    }
}
