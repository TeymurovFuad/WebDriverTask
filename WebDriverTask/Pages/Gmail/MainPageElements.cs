using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebDriverTask.Core.WebDriverConfigs;

namespace WebDriverTask.Pages.Gmail
{
    public class MainPageElements: BaseElements
    {
        [FindsBy(How = How.XPath, Using = "//div[h2[text()='Labels'] and //a[text()='Inbox']][1]")]
        public IWebElement FoldersButtonContainer { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Compose']")]
        public static IWebElement ComposeButton { get; private set; }

        public IWebElement GetFolderByFolderName(string folderName)
        {
            IWebElement folder;
            try
            {
                folder = Driver.GetDriver().FindElement(By.XPath(folderName)).FindElement(By.XPath($"//a[contains(translate(text(), {folderName.ToLower()}, {folderName.ToUpper()}), {folderName})]"));
            }
            catch (NoSuchElementException)
            {
                throw;
            }
            return folder;
        }
    }
}
