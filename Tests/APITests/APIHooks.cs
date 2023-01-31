using Core.APIConfig.RestSharp;
using Core.Common.TestConfig;
using NUnit.Framework;

namespace Tests.APITests
{
    public class APIHooks: CommonHooks
    {
        protected ClientConfig httpMethod { get; set; }

        public APIHooks() { }

        [OneTimeSetUp]
        public void ClassSetup()
        {
            httpMethod = new ClientConfig(@"https://jsonplaceholder.typicode.com/");
        }
    }
}
