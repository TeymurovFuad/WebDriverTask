using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverTask.Core.Browser;

namespace WebDriverTask.Tests.TestConfig
{
    public class TestClassDataProvider
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestFixtureData(BrowserType.Chrome);
                yield return new TestFixtureData(BrowserType.RemoteFirefox);
                yield return new TestFixtureData(BrowserType.RemoteFirefox);
            }
        }
    }
}
