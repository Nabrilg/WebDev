﻿using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using RestSharp;
using System.Net;

namespace WebDev.Services
{
    public class UsersService
    {
        private HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;
        private string BaseUrl { get; }
        private readonly RestClient _restClient;
        public TokenDto TokenDto { get; set; }
        public UsersService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(_httpClientHandler);
            SetupHttpConnection(baseUrl);
            _restClient = new RestClient();
        }

        private void SetupHttpConnection(string baseUrl)
        {
            //Passing service base url  
            _httpClient.BaseAddress = new Uri(baseUrl);

            _httpClient.DefaultRequestHeaders.Clear();

            //Define request data format  
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer123");
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var usersList = new List<UserDto>();

            //Rest with RestSharp
            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.GET);

            // Assign the Headers
            request.AddHeader("Authorization", "");
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);
            /// End Rest with RS
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                usersList = JsonConvert.DeserializeObject<List<UserDto>> (responseContent);
            }
            /*
            // Sending request to find web api REST service resource to Get All Users using HttpClient
            HttpResponseMessage response = await _httpClient.GetAsync($"users");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                usersList = JsonConvert.DeserializeObject<List<UserDto>>(responseContent);
            }
            */

            return usersList;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            UserDto user = null;

            //Rest with RestSharp
            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users/{id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.GET);

            // Assign the Headers
            request.AddHeader("Authorization", "");
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);
            /// End Rest with RS
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                user = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }
            /*
            // Sending request to find web api REST service resource to Get All Users using HttpClient
            HttpResponseMessage response = await _httpClient.GetAsync($"users/{id}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                user = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }
            */
            return user;
        }

        public async Task<UserDto> AddUser(UserDto user)
        {
            UserDto userDtoResponse = null;
            UserTransferDto _user = new UserTransferDto { id = user.Id, name = user.Name, email = user.Email, password = user.Password, username=user.Username };

            StringContent content = new StringContent(JsonConvert.SerializeObject(_user), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await _httpClient.PostAsync($"users", content);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                userDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return userDtoResponse;
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            UserDto userDtoResponse = null;
            UserTransferDto _user = new UserTransferDto { id = user.Id, name = user.Name, email = user.Email, password = user.Password, username = user.Username };

            StringContent content = new StringContent(JsonConvert.SerializeObject(_user), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await _httpClient.PutAsync($"users/{user.Id}", content);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api
                userDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return userDtoResponse;
        }

        public async Task<UserDto> DeleteUser(int id) {
            UserDto user = null;
            //Rest with RestSharp
            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}users/{id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.DELETE);

            // Assign the Headers
            request.AddHeader("Authorization", "");
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);
            /// End Rest with RS
            if (response.StatusCode == HttpStatusCode.OK)
            {
            // Storing the content response recieved from web api
                var responseContent = response.Content;
                //Deserializing the response recieved from web api and storing into the Employee list
                user = JsonConvert.DeserializeObject<UserDto>(responseContent);
             }
             return user;
        }
    }
}
