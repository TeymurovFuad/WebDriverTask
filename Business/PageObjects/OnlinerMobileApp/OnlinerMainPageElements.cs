using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Business.PageObjects.OnlinerMobileApp
{
    public class OnlinerMainPageElements
    {
        public string toolBarId => "toolbar";
        public Query toolBarElement => x => x.Id(toolBarId);

        public string navigateUpValue => "Navigate up";
        public Query navigateUpElement => x => x.Id(navigateUpValue);

        public string headerTextClass => "android.widget.TextView";
        public Query headerTextElement => x => x.Class(headerTextClass);

        public string searchButtonId => "menu_search";
        public Query searchButtonElement => x => x.Id(searchButtonId);
    }
}
