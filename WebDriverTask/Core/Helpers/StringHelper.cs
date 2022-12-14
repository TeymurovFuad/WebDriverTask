using System;
using System.Text;

namespace WebDriverTask.Core.Helpers
{
    public static class StringHelper
    {public static string GenerateUUID()
        {
            string uuid = Guid.NewGuid().ToString();
            return uuid;
        }

        public static string GetCurrentDateInMilliseconds()
        {
            long epochTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            return epochTime.ToString();
        }
    }
}
