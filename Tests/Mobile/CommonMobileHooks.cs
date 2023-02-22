using Core.Common.TestConfig;
using Core.Mobile.Device;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Xamarin.UITest;

namespace Tests.Mobile
{
    public class CommonMobileHooks: CommonHooks
    {
        protected IApp app { get; set; }
        protected DeviceFactory deviceFactory;

        protected CommonMobileHooks()
        {
            deviceFactory = new DeviceFactory();
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
                string imageFullPath = Path.Combine(logDirectory, fileName + screenShot.Extension);
                screenShot.MoveTo(imageFullPath);
            }
        }
    }
}
