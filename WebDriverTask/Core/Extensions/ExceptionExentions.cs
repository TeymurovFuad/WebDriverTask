using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Core.Extensions
{
    public static class ExceptionExentions
    {
        public static WebDriverWait IgnoreExceptionType(this WebDriverWait wait, params Type[] exceptionTypes)
        {
            if (exceptionTypes == null)
            {
                throw new ArgumentNullException("exceptionTypes", "exceptionTypes cannot be null");
            }

            foreach (Type c in exceptionTypes)
            {
                if (!typeof(Exception).IsAssignableFrom(c))
                {
                    throw new ArgumentException("All types to be ignored must derive from System.Exception", "exceptionTypes");
                }
            }
            return wait;
        }

        public static Action Try(this Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return action;
        }
    }
}
