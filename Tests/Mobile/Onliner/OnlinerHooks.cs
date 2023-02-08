using Core.Common.TestConfig;
using Core.Mobile.Device;
using NUnit.Framework;
using Xamarin.UITest;
using Business.PageObjects.OnlinerMobileApp;
using NUnit.Framework.Interfaces;

namespace Tests.Mobile.Onliner
{
    public class OnlinerHooks: CommonMobileHooks
    {
        protected OnlinerMainPage onliner;
        protected Platform platform=Platform.Android;
        protected string apkName;

        public OnlinerHooks()
        {
        }

        [SetUp]
        public void SetUpDevice()
        {
            string pathToApk = $@"{Environment.CurrentDirectory}\PageObjects\OnlinerMobileApp\{apkName}.apk";
            app = deviceFactory.StartApp(platform, pathToApk);
            onliner = new OnlinerMainPage(app);
        }
    }
}
