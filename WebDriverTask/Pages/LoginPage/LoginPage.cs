using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core;
using WebDriverTask.WebDriverConfigs;

namespace WebDriverTask.Pages.LoginPage
{
    public class LoginPage: BasePage
    {
        IWebDriver _driver;
        public LoginPage(): base(Browser.Chrome)
        {
            //_driver = 
        }
    }
}
