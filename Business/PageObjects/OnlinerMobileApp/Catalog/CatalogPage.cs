using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Business.PageObjects.OnlinerMobileApp.Catalog
{
    public class CatalogPage: CatalogPageElements
    {
        IApp _app;
        public CatalogPage(IApp app)
        {
            _app = app;
        }

        public void ClickCatalogCategory(string categoryName)
        {
            _app.WaitForElement(catalogCategoryElement);
            _app.Tap(e => e.Id(catalogCategoryId).Child().Marked(categoryName));
        }

        public void ClickCatalogSubCategory(string subCategoryName)
        {
            _app.WaitForElement(catalogSubCategoryElement);
            _app.Tap(e => e.Id(catalogSubCategoryId).Child().Marked(subCategoryName));
        }

        public List<AppResult> GetCategories()
        {
            return _app.Query(catalogCategoryElement).ToList();
        }

        public List<AppResult> GetSubCategories()
        {
            _app.WaitForElement(catalogSubCategoryElement);
            return _app.Query(catalogSubCategoryElement).ToList();
        }
    }
}
