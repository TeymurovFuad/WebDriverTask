using FluentAssertions;
using NUnit.Framework;
using Xamarin.UITest;

namespace Tests.Mobile.Onliner
{
    [TestFixture]
    public class OnlinerTest: OnlinerHooks
    {
        public OnlinerTest()
        {
            platform = Platform.Android;
            apkName = "test";
        }

        [Test]
        public void OpenApp()
        {
            Assert.IsTrue(onliner.introPage.isOpened());
        }

        [TestCase("Электроника")]
        public void OpenCategory(string categoryName)
        {
            onliner.introPage.SkipIntro();
            onliner.catalogPage.ClickCatalogCategory(categoryName);
            string headerValue = onliner.GetHeaderValue();
            Assert.AreEqual(headerValue, categoryName, $"Header value ({headerValue}) not equal to category name ({categoryName})");
        }

        [TestCase("Электроника", "Смартфоны")]
        public void VerifyCategoryContainsSubCategory(string category, string subCategory)
        {
            onliner.introPage.SkipIntro();
            onliner.catalogPage.ClickCatalogCategory(category);
            onliner.catalogPage.GetSubCategories().Should().Contain(sc => sc.Text == subCategory, because: $"given category {category} does not contain a subcategory {subCategory}");
        }
    }
}
