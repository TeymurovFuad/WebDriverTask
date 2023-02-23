using Business.PageObjects.OnlinerMobileApp.Catalog;
using Business.PageObjects.OnlinerMobileApp.Intro;
using Xamarin.UITest;

namespace Business.PageObjects.OnlinerMobileApp
{
    public class OnlinerMainPage: OnlinerMainPageElements
    {
        IApp _app;
        public IntroPage introPage;
        public CatalogPage catalogPage;

        public OnlinerMainPage(IApp app)
        {
            _app = app;
            introPage = new IntroPage(app);
            catalogPage = new CatalogPage(app);
        }

        public void GoBack()
        {
            _app.Tap(navigateUpElement);
        }

        public string GetHeaderValue()
        {
            _app.WaitForElement(headerTextElement);
            return _app.Query(headerTextElement).First().Text;
        }
    }
}
