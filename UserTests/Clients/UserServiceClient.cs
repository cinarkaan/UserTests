using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTests.Extensions;
using UserTests.Models.Requests;
using UserTests.Models.Responces;
using UserTests.Models.Responces.Base;

namespace UserTests.Clients
{
    public class UserServiceClient : BaseClientService
    {

        public UserServiceClient ()
        {
            _baseUrl = "https://userservice-uat.azurewebsites.net";
        }

        public async Task<CommonResponse<Object>> RegisterUser(RegisterUserRequest request)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_baseUrl}/Register/RegisterNewUser"),
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);

            return await response.ToCommonResponse<Object>();
        }

        public async Task<CommonResponse<object>> GetUserStatus(int id)
        {
            var getProductInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/UserManagement/GetUserStatus?userId={id}")
            };

            HttpResponseMessage response = await _httpClient.SendAsync(getProductInfoRequest);

            return await response.ToCommonResponse<object>();
        }

        public async Task<CommonResponse<object>> DeleteUser(int id)
        {
            var getProductInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_baseUrl}/Register/DeleteUser?userId={id}")
            };

            HttpResponseMessage response = await _httpClient.SendAsync(getProductInfoRequest);

            return await response.ToCommonResponse<object>();
        }

        public async Task<CommonResponse<object>> UpdateUser(int id,bool status)
        {
            var getProductInfoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_baseUrl}/UserManagement/SetUserStatus?userId={id}&newStatus={status}")
            };

            HttpResponseMessage response = await _httpClient.SendAsync(getProductInfoRequest);

            return await response.ToCommonResponse<object>();
        }
    }
}
