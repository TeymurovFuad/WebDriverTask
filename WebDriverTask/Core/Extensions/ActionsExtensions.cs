using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WebDriverTask.Core.Extensions
{
    public static class ActionsExtensions
    {
        public static Actions CreateActions(this IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            return actions;
        }

        public static void MoveElementFromTo(this IWebDriver driver, IWebElement sourceElement, IWebElement targetElement)
        {
            CreateActions(driver).DragAndDrop(sourceElement, targetElement).Perform();
        }

        public static Actions SourceElement(this Actions actions, IWebElement sourceElement)
        {
            actions.MoveToElement(sourceElement).Perform();
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
