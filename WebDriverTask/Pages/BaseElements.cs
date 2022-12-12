using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebDriverTask.Pages
{
    public abstract class BaseElements: BasePage
    {
        [FindsBy(How = How.Id, Using = "lang-chooser")]
        public IWebElement DropDownToChooseLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='lang-chooser']//ul/li]")]
        public List<IWebElement> AllLanguagesFromDropDown { get; set; }

        private IWebElement LanguageFromDropDown { get; set; }

        public IWebElement FindSpecificLanguageFromDropDown(string language)
        {
            foreach (IWebElement element in AllLanguagesFromDropDown)
            {
                try
                {
                    if (element.FindElement(By.XPath($"//span[contains(text(), {language})]")).Displayed)
                    {
                        LanguageFromDropDown = element;
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    throw;
                }
            }
            return LanguageFromDropDown;
        }

        [FindsBy(How = How.XPath, Using = "//button[span[contains(text(), 'Next')]]")]
        public List<IWebElement> NextButton { get; set; }


    }
}
