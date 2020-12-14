using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebDev.Services.Entities;

namespace WebDev.Services
{
    public class UsersService
    {
        private readonly RestClient _restClient;
        public string BaseUrl { get; }
        public string Token { get; set; }

        public UsersService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();
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

            // Assign the Headers
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                usersList = JsonConvert.DeserializeObject<List<UserDto>>(responseContent);
            }

            return usersList;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            UserDto user = null;
            _restClient.BaseUrl = new Uri($"{BaseUrl}users/{id}");
            // Wait until to get a response
            _restClient.Timeout = -1;
            // Assign the Method Type
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = await _restClient.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                user = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }
            return user;
        }

        public async Task<UserDto> AddUser(UserDto user)
        {
            UserDto userCreatedDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.POST);

            // Assign the Headers
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");

            // Assign the Body
            var content = JsonConvert.SerializeObject(user);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.Created)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                userCreatedDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return userCreatedDtoResponse;
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            UserDto userCreatedDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users/{user.Id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.PUT);

            // Assign the Headers
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");

            // Assign the Body
            var content = JsonConvert.SerializeObject(user);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                userCreatedDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return userCreatedDtoResponse;
        }

        public async Task<UserDto> DeleteUser(int id)
        {
            UserDto userCreatedDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users/{id}");

            // Wait until to get a response
            _restClient.Timeout = -1;


            // Assign the Method Type
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.Created)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                userCreatedDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return userCreatedDtoResponse;
        }

    }
}