using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDev.Services.Entities;

namespace WebDev.Services
{
    public class UsersService
    {
        private HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;
        private string BaseUrl { get; }
        public UsersService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer123");
            SetupHttpConnection(_httpClient, baseUrl);
        }

        private void SetupHttpConnection(HttpClient httpClient, string baseUrl)
        {
            //Passing service base url  
            httpClient.BaseAddress = new Uri(baseUrl);

            httpClient.DefaultRequestHeaders.Clear();

            //Define request data format  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var usersList = new List<UserDto>();

            // Sending request to find web api REST service resource to Get All Users using HttpClient
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer");
            HttpResponseMessage response = await _httpClient.GetAsync($"users");

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

        public async Task<UserDto> GetUserById(int id)
        {
            UserDto user = null;

            // Sending request to find web api REST service resource to Get All Users using HttpClient
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer");
            HttpResponseMessage response = await _httpClient.GetAsync($"users/{id}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                user = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return user;
        }

        public async Task<UserDto> AddUser(UserDto user)
        {
            UserDto userDtoResponse = null;
            UserTransferDto _user = new UserTransferDto { id = user.Id, name = user.Name, email = user.Email, password = user.Password, username=user.Username };

            StringContent content = new StringContent(JsonConvert.SerializeObject(_user), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an User using HttpClient
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer");
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
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer");
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

        public async Task<UserDto> DeleteUser(int id)
        {
            UserDto userDtoResponse = null;

            // Sending request to find web api REST service resource to Delete the User using HttpClient
            //_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer");
            HttpResponseMessage response = await _httpClient.DeleteAsync($"users/{id}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                // Deserializing the response recieved from web api
                userDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return userDtoResponse;
        }
    }
}
