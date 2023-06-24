using TechTalk.SpecFlow;
using UserTests.Clients;
using UserTests.Models.Requests;
using UserTests.Utils;

namespace UserTests.Steps
{
    [Binding]
    public sealed class UserSteps
    {

        private readonly IUserServiceClient _userServiceClient;
        private readonly UserGenerator _userGenerator;
        
        private readonly Context _context;

        public UserSteps(Context context, IUserServiceClient userServiceClient, UserGenerator userGenerator)
        {
            _context = context;
            _userServiceClient = userServiceClient;
            _userGenerator = userGenerator;
        }

        [Given(@"New user who has her/his firstname '(.*)' and surname '(.*)' will be created")]
        public async Task GivenNewUserWhoHasSpecificAttributeValues(string firstname, string lastname)
        {

            firstname = firstname.Equals("null") ? null : firstname;

            firstname = lastname.Equals("null") ? null : lastname;

            var request = _userGenerator.GenerateRegisterUserRequest(firstname, lastname);

            var response = await _userServiceClient.RegisterUser(request);

            _context.UserId = Convert.ToInt32(response.Body);

            _context.CreateUserResponce = response;

        }

        [Given(@"New user will be created as randomly")]
        public async Task GivenCreateNewUserAsRandomly ()
        {
            string name = _userGenerator.GetRandomString(120);
            string surname = _userGenerator.GetRandomString(120);

            var request = _userGenerator.GenerateRegisterUserRequest(name, surname);

            var response = await _userServiceClient.RegisterUser(request);

            _context.UserId = Convert.ToInt32(response.Body);

            _context.CreateUserResponce = response;
        }

        [Given(@"New user will be created")]
        public async Task GivenCreateNewUser ()
        {
            var request = _userGenerator.GenerateRegisterUserRequest(_userGenerator.GetRandomString(8), _userGenerator.GetRandomString(8));

            var response = await _userServiceClient.RegisterUser(request);

            _context.UserId = Convert.ToInt32(response.Body);

            _context.CreateUserResponce = response;
        }

        [When(@"Status value of user will be taken")]
        public async Task WhenGetUserStatus ()
        {

            var response = await _userServiceClient.GetUserStatus(_context.UserId);

            _context.UserStatusResponce = response;

        }

        [When(@"Status will be updated as '(.*)'")]
        public async Task WhenSetUserStatus (string status)
        {
            var response = await _userServiceClient.UpdateUser(_context.UserId, Convert.ToBoolean(status));

            _context.UserStatusResponce = response;
        }

        [Given(@"The user who is already exist will be taken")]
        public async Task GetUserWhoHasTrueStatus()
        {
            _context.UserId = 166071;
        }

        [Given(@"The user who is not exist will be initiliazed")]
        public async Task initNotExistUser ()
        {
            _context.UserId = 000000;
        }

        [When(@"The user who was created will be deleted")]
        public async Task deleteNotExistUser ()
        {
            var response = await _userServiceClient.DeleteUser(_context.UserId);

            _context.DeleteUserResponse = response;
        }


        [Given(@"The users count which has been created so far will be gotten")]
        public async Task GivenGetTotalUsersCount()
        {
            var request = _userGenerator.GetAllUsersRequests(1, _userGenerator.GenerateRegisterUserRequest("", ""));

            var response = await _userServiceClient.GetAllUsers(request);

            _context.TotalUserCount = response.Body.PageTotal;

        }

        [When(@"Last two user will be gotten")]
        public async Task WhenGetLastTwoUsers ()
        {
            var request = _userGenerator.GetAllUsersRequests(_context.TotalUserCount, _userGenerator.GenerateRegisterUserRequest("", ""));

            var response = await _userServiceClient.GetAllUsers(request);

            _context.GetUserResponse = response;
        }

    }
}