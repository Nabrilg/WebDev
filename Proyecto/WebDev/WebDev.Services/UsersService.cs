using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using System.Net;
using RestSharp;

namespace WebDev.Services
{
    public class UsersService {

        private readonly RestClient _restClient;
        private string BaseUrl { get; }
        public TokenDto TokenDto { get; set; }

        private HttpClient _httpClient;

        private HttpClientHandler _httpClientHandler;

        public UsersService(string baseUrl, string token)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();
            TokenDto = new TokenDto();
            TokenDto.Token = token;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var usersList = new List<UserDto>();

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.GET);

            // Assign the Headers and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api
                usersList = JsonConvert.DeserializeObject<List<UserDto>>(responseContent);
            }

            return usersList;
        }


        public async Task<UserDto> GetUserById(int id)
        {
            UserDto user = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users/{id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.GET);

            // Assign the Header0s and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api
                user = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return user;

        }

        public async Task<UserDto> AddUser(UserDto user)
        {
            UserDto userDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.POST);

            // Assign the Headers and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");

            // Assign the Body
            var content = JsonConvert.SerializeObject(user);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.Created)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api
                userDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return userDtoResponse;
        }


        public async Task<UserDto> UpdateUser(UserDto user)
        {
            UserDto userDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users/{user.Id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.PUT);

            // Assign the Headers and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");

            // Assign the Body
            var content = JsonConvert.SerializeObject(user);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.Created)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api
                userDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }


            return userDtoResponse;
        }


        public async Task<UserDto> DeleteUser(int id)
        {
            UserDto userDtoResponse = null;


            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users/{id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.DELETE);

            // Assign the Headers and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                // Deserializing the response recieved from web api
                userDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return userDtoResponse;
        }


    }
}
