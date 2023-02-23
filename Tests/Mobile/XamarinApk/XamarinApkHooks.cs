using NUnit.Framework;
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
