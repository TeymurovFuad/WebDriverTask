using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Core.Extensions
{
    public static class StringExtension
    {
        public static string Capitalise(this string target)
        {
            if(string.IsNullOrEmpty(target))
            {
                return target;
            }
            return char.ToUpper(target[0]) + target.Substring(1);
        }
    }
}
