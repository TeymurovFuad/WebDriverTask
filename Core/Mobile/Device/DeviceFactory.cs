using System.Diagnostics.CodeAnalysis;
using Xamarin.UITest;

namespace Core.Mobile.Device
{
    public sealed class DeviceFactory
    {
        private IApp _app { get; set; }

        public IApp StartApp([DisallowNull] Platform platform, string pathToApp)
        {
            switch (platform)
            {
                case Platform.Android:
                    _app = ConfigureApp.Android.ApkFile(pathToApp).StartApp();
                    break;
                case Platform.iOS:
                    _app = ConfigureApp.iOS.StartApp();
                    break;
                default:
                    throw new NotImplementedException($"{platform} not implemented yet");
            }
            return _app;
        }
    }
}
