using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTask.Tests.TestConfig
{
    public class TestData
    {
        private Dictionary<string, dynamic> keyValuePairs;

        public TestData()
        {
            keyValuePairs = new Dictionary<string, object>();
        }

        public void SetVariable<T>(string key, T value)
        {
            if (!keyValuePairs.ContainsKey(key))
            {
                keyValuePairs.Add(key, value!);
            }
            keyValuePairs[key] = value!;
        }

        public T GetVariable<T>(string key)
        {
            if (keyValuePairs.ContainsKey(key))
                return keyValuePairs[key];
            else
                throw new KeyNotFoundException(key);
        }
    }
}
