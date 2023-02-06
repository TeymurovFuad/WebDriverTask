using Business.PageObjects.Gmail;
using Business.PageObjects.OnlinerMobileApp.Catalog;
using Business.PageObjects.OnlinerMobileApp.Intro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

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
