using Core.Common.TestConfig;
using Core.Mobile.Device;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Shared.iOS.Queries;
using System.IO;
using Business.PageObjects.OnlinerMobileApp.Intro;
using Business.PageObjects.OnlinerMobileApp;

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

    }
}
