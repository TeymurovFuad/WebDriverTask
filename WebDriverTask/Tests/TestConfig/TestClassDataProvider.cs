using NUnit.Framework;
using System.Collections;
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
