using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace UserTests.Steps
{
    [Binding]
    internal class UserAssertSteps
    {
        private readonly Context _context;

        public UserAssertSteps (Context context)
        {
            this._context = context;
        }

        [Then(@"Get create user response http code is '(.*)'")]
        public void ThenGetCreateUserStatusResponse(string statusCode)
        {
            var httpcode = Enum.Parse(typeof(HttpStatusCode), statusCode);
            var response = _context;
            Assert.AreEqual(httpcode, response.CreateUserResponce.Status);
        }

        [Then(@"User status response will be gotten http code is '(.*)'")]
        public void ThenGetUserStatusResponse(string statusCode)
        {
            var httpcode = Enum.Parse(typeof(HttpStatusCode), statusCode);
            var response = _context;
            Assert.AreEqual(httpcode, response.UserStatusResponce.Status);
        }

        [Then(@"Create User response will be gotten http code is '(.*)'")]
        public void ThenGetCreateStatusResponse(string statusCode)
        {
            var httpcode = Enum.Parse(typeof(HttpStatusCode), statusCode);
            var response = _context;
            Assert.AreEqual(httpcode, response.CreateUserResponce.Status);
        }

        [Then(@"User status will be validated as '(.*)'")]
        public void ThenGetUserStatusAndValidate (string status)
        {
            var response = _context;
            Assert.AreEqual(Convert.ToBoolean(status), response.UserStatusResponce.Body);
        }

        [Then(@"Delete user response will be gotten as '(.*)'")]
        public void ThenGetDeleteResponseStatus(string statusCode)
        {
            var httpcode = Enum.Parse(typeof(HttpStatusCode), statusCode);
            var response = _context;
            Assert.AreEqual(httpcode, response.DeleteUserResponse.Status);
        }


        [Then(@"User ids will be checked out whether is consecutive")]
        public void ThenCheckUserIds ()
        {
            var lastUserId = _context.GetUserResponse.Body.result.Last().Id;
            var penultimateUser = _context.GetUserResponse.Body.result.Length - 2;
            var penultimateId = _context.GetUserResponse.Body.result[penultimateUser].Id;
            Assert.AreEqual(1, lastUserId - penultimateId);
        }

    }

}