using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Business.PageObjects.OnlinerMobileApp.Catalog
{
    public class CatalogPageElements
    {
        public string searchButtonId => "menuSearch";
        public Query searchButtonElement => x => x.Id(searchButtonId);

        public string searchButtonValueId => "search_src_text";
        public Query searchButtonValueElement => x => x.Id(searchButtonValueId);

        public string catalogCategoryId => "view";
        public Query catalogCategoryElement => x => x.Id(catalogCategoryId);

        public string catalogCategoryTextId => "name";
        public Query catalogCategoryText => x => x.Id(catalogCategoryTextId);

        public string catalogSubCategoryId => "text";
        public Query catalogSubCategoryElement => x => x.Id(catalogSubCategoryId);
    }
}
