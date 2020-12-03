﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using System;

namespace WebDev.Services
{
    public class UsersService
    {
        #region Properties
        private string BaseUrl { get; }
        private HttpClient httpClient;
        private HttpClientHandler httpClientHandler;
        #endregion

        #region Initialize
        public UsersService(string baseUrl)
        {
            BaseUrl = baseUrl;
            httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            httpClient = new HttpClient(httpClientHandler);
            SetupHttpConnection(httpClient, baseUrl);
        }
        #endregion

        #region Methods
        private void SetupHttpConnection(HttpClient httpClient, string baseUrl)
        {
            //Passing service base url  
            httpClient.BaseAddress = new Uri(baseUrl);

            //Define request data format
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void UpdateCurrentToken(string token)
        {
            if (token != null) 
            {
                // Clear all headers before updating the current token
                httpClient.DefaultRequestHeaders.Clear();

                // Set the current token
                httpClient.DefaultRequestHeaders.Add("authorization", token);
            }
        }

        public async Task<List<UserDto>> GetUsers(string token)
        {
            try
            {
                // Asuming the token change or expires every certain time
                UpdateCurrentToken(token);

                var usersList = new List<UserDto>();

                // Sending request to find web api REST service resource to Get All Users using HttpClient
                HttpResponseMessage response = await httpClient.GetAsync("users/getAllUsers");

                // Checking the response is successful or not which is sent using HttpClient
                if (response.IsSuccessStatusCode)
                {
                    // Storing the content response recieved from web api
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    usersList = JsonConvert.DeserializeObject<List<UserDto>>(responseContent);
                }

                return usersList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<UserDto> GetUserById(int id, string token)
        {
            UserDto user = null;
            try
            {
                // Asuming the token change or expires every certain time
                UpdateCurrentToken(token);

                // Sending request to find web api REST service resource to Get All Users using HttpClient
                HttpResponseMessage response = await httpClient.GetAsync($"users/getById/{id}");

                // Checking the response is successful or not which is sent using HttpClient
                if (response.IsSuccessStatusCode)
                {
                    // Storing the content response recieved from web api
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    user = JsonConvert.DeserializeObject<UserDto>(responseContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return user;
        }

        public async Task<IdResponseDto> AddUser(CreateUserDto user, string token)
        {
            IdResponseDto idResponseDto = null;
            try
            {
                // Asuming the token change or expires every certain time
                UpdateCurrentToken(token);

                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                // Sending request to find web api REST service resource to Add an User using HttpClient
                HttpResponseMessage response = await httpClient.PostAsync($"users/create", content);

                // Checking the response is successful or not which is sent using HttpClient
                if (response.IsSuccessStatusCode)
                {
                    // Storing the content response recieved from web api
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    idResponseDto = JsonConvert.DeserializeObject<IdResponseDto>(responseContent);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return idResponseDto;
        }

        public async Task<bool> UpdateUser(UpdateUserDto user, int id, string token)
        {
            // Asuming the token change or expires every certain time
            UpdateCurrentToken(token);

            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await httpClient.PutAsync($"users/edit/{id}", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUser(int id, string token)
        {
            // Asuming the token change or expires every certain time
            UpdateCurrentToken(token);

            // Sending request to find web api REST service resource to Delete the User using HttpClient
            HttpResponseMessage response = await httpClient.DeleteAsync($"users/delete/{id}");

            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
