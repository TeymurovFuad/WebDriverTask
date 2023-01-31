using FluentAssertions;
using NUnit.Framework;
using System.Net;
using Tests.APITests.Models;

namespace Tests.APITests.Tests
{
    [TestFixture]
    public class TestUsers: APIHooks
    {
        private UserDTO _user;
        private List<UserDTO> _users;
        public TestUsers() { }

        [TestCase(HttpStatusCode.OK)]
        public async Task VerifyStatusCode(HttpStatusCode expectedStatusCode)
        {
            var response = await httpMethod.GET<List<UserDTO>>("users");
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
        }

        [TestCase("Content-Type", "application/json; charset=utf-8")]  
        public async Task VerifyHeader(string expectedHeaderName, string expectedHEaderValue)
        {
            var response = await httpMethod.GET<List<UserDTO>>("users");
            response.ContentHeaders?.Should().Contain(header => 
                header.Name.ToLower() == (expectedHeaderName.ToLower()) && header.Value.ToString().ToLower() == expectedHEaderValue.ToLower());
        }

        [TestCase(10)]
        public async Task VerifyNumberOfUsers(int expectedNumberOfUsers)
        {
            var response = await httpMethod.GET<List<UserDTO>>("users");
            _users = response.Data;
            _users?.Count.Should().Be(expectedNumberOfUsers);
        }
    }
}
