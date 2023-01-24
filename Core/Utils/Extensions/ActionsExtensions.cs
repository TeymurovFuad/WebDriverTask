using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Extensions
{
    public static class ActionsExtensions
    {
        private static IWebDriver _webDriver;

        public static Actions CreateActions(this IWebDriver driver)
        {
            _webDriver = driver;
            Actions actions = new Actions(driver);
            return actions;
        }

        public static void MoveElementFromTo(this IWebDriver driver, IWebElement sourceElement, IWebElement targetElement)
        {
            CreateActions(driver).DragAndDrop(sourceElement, targetElement).Perform();
        }

        public static Actions MoveTo(this Actions actions, IWebElement target)
        {
            actions.MoveToElement(target).Perform();
            return actions;
        }

        public static Actions MoveTo(this Actions actions, int x, int y)
        {
            actions.MoveByOffset(x, y).Perform();
            return actions;
        }

        /// <summary>
        /// First moves mouse to the viewport's 0 position (top left), then moves to the given coordinates
        /// </summary>
        public static Actions MoveTo(this Actions actions, (int top, int left) target, (int top, int left) source)
        {
            int x = target.top - source.top;
            int y = target.left - source.left;
            actions.MoveByOffset(x, y).Perform();
            return actions;
        }

        public static Actions SourceElement(this Actions actions, IWebElement sourceElement)
        {
            actions.ClickAndHold(sourceElement).Perform();
            return actions;
        }

        public static Actions MoveToCoordinates(this Actions actions, int x, int y)
        {
            actions.MoveByOffset(x, y).Perform();
            return actions;
        }

        public static Actions ReleaseElement(this Actions actions)
        {
            actions.Release().Perform();
            return actions;
        }

        public static Actions ClickAndHoldElement(this Actions actions)
        {
            actions.ClickAndHold().Perform();
            return actions;
        }

        public static Actions ClickElement(this Actions actions)
        {
            actions.Click().Perform();
            return actions;
        }
    }
}
