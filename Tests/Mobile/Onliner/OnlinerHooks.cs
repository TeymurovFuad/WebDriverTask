using Core.Common.TestConfig;
using Core.Mobile.Device;
using NUnit.Framework;
using Xamarin.UITest;
using Business.PageObjects.OnlinerMobileApp;
using NUnit.Framework.Interfaces;

namespace Tests.Mobile.Onliner
{
    public class OnlinerHooks: CommonHooks
    {
        protected IApp app; 
        protected OnlinerMainPage onliner;
        protected Platform platform=Platform.Android;
        protected string apkName;
        DeviceFactory _deviceFactory;

        public OnlinerHooks()
        {
            _deviceFactory = new DeviceFactory();
        }

        [SetUp]
        public void SetUpDevice()
        {
            string pathToApk = $@"{Environment.CurrentDirectory}\PageObjects\OnlinerMobileApp\{apkName}.apk";
            app = _deviceFactory.StartApp(platform, pathToApk);
            onliner = new OnlinerMainPage(app);
        }

        [TearDown]
        public void MakeAScreenshotOnFail()
        {
            bool isFailed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed;
            string logDirectory = Directory.GetCurrentDirectory() + "\\Log";
            if (isFailed)
            {
                string className = TestContext.CurrentContext.Test.ClassName;
                string methodName = TestContext.CurrentContext.Test.MethodName;
                string arguments = String.Join("_", TestContext.CurrentContext.Test.Arguments);
                string dateTimeNow = DateTimeOffset.Now.Ticks.ToString();
                string fileName = $"{className}_{methodName}_{arguments}_{dateTimeNow}";
                var screenShot = app.Screenshot("");
                string imageFullPath = Path.Combine(logDirectory, fileName+screenShot.Extension);
                screenShot.MoveTo(imageFullPath);
            }
        }
    }
}
