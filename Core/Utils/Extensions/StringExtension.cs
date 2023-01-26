using System.Runtime.CompilerServices;

namespace Core.Utils.Extensions
{
    public static class StringExtension
    {
        public static string Capitalise(this string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                return target;
            }
            return char.ToUpper(target[0]) + target.Substring(1);
        }

        public static bool isEmpty(this string source)
        {
            return source == string.Empty;
        }
    }
}
