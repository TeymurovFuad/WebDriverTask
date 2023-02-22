using Xamarin.UITest;

namespace Business.PageObjects.OnlinerMobileApp.Intro
{
    public class IntroPage: IntroPageElements
    {
        IApp _app;
        public IntroPage(IApp app)
        {
            _app = app;
        }

        public void ClickNext()
        {
            _app.Tap(nextContainerButtonElement);
        }

        public void SkipIntro()
        {
            int introImages = 5;
            do
            {
                ClickNext();
                introImages--;
            }while(introImages > 0);
        }

        public bool isOpened()
        {
            return introTestTitleElement != null;
        }
    }
}
