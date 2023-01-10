using System.Text.RegularExpressions;

namespace WebDriverTask.Utils.Helpers
{
    public static class StringHelper
    {
        public static string GenerateUUID()
        {
            string uuid = Guid.NewGuid().ToString();
            return uuid;
        }

        public static string GetCurrentDateInMilliseconds()
        {
            long epochTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            return epochTime.ToString();
        }

        /// <summary>
        /// Will replace placeholders in target with a provided values. 
        /// The number of values should not be less than number of placeholders.
        /// </summary>
        public static string FormatString(string target, params string[] vals)
        {
            string pattern = @"{\\d}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled);
            MatchCollection matchCollection = regex.Matches(target);
            if (matchCollection.Count > vals.Length)
                return string.Empty;
            return string.Format(target, vals);
        }
    }
}
