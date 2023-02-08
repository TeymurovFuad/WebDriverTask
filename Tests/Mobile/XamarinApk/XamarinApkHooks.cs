using Business.PageObjects.OnlinerMobileApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace Tests.Mobile.XamarinApk
{
    public class XamarinApkHooks: CommonMobileHooks
    {
        protected Platform platform = Platform.Android;
        protected string apkName;

        public XamarinApkHooks()
        {
        }

        [SetUp]
        public void SetUpDevice()
        {
            string pathToApk = $@"{Environment.CurrentDirectory}\PageObjects\OnlinerMobileApp\{apkName}.apk";
            app = deviceFactory.StartApp(platform, pathToApk);
        }
    }
}
