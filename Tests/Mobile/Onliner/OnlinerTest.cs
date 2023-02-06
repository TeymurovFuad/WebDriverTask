using Core.Mobile.Device;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace Tests.Mobile.Onliner
{
    [TestFixture]
    public class OnlinerTest: OnlinerHooks
    {
        public OnlinerTest()
        {
            platform = Platform.Android;
            apkName = "test";
        }

        [Test]
        public void OpenApp()
        {
            app.Repl();
        }
    }
}
