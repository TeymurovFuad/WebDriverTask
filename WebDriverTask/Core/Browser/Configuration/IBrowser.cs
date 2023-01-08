using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Core.Browser.Configuration
{
    public interface IBrowser
    {
        IWebDriver GetDriver();
        IBrowser ConfigureRemoteDriver();
        IBrowser SetOptions(DriverOptions? options);
    }

}
