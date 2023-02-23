using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Business.PageObjects.OnlinerMobileApp.Intro
{
    public class IntroPageElements
    {
        public string introTestTitleId => "text_title";
        public Query introTestTitleElement => x => x.Id(introTestTitleId);

        public string skipButtonId => "text_title";
        public Query skipButtonElement => x => x.Id(skipButtonId);

        public string nextContainerButtonId => "nextContainer";
        public Query nextContainerButtonElement => x => x.Id(nextContainerButtonId);
    }
}
