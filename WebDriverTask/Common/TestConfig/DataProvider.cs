using NUnit.Framework;
using System.Collections;
using WebDriverTask.Core.Browser;

namespace WebDriverTask.Common.TestConfig
{
    public class DataProvider
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
