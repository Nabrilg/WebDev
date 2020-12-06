using System;
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
        private string BaseUrl { get; }
        public string TokenDto { get; set; }
        private HttpClient _httpClient;
        private readonly RestClient _restClient;
        // Agregar Vble a nivel de la clase del controlador
        private HttpClientHandler _httpClientHandler;



        public UsersService(string baseUrl)


        {
            BaseUrl = baseUrl;
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(_httpClientHandler);

            SetupHttpConnection(_httpClient, baseUrl);
            _restClient = new RestClient();


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

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}/users");

            //Wait until get a response
            _restClient.Timeout = -1;

            //Assign the Method Type
            var request = new RestRequest(Method.GET);

            //Assign the Headers
            request.AddHeader("Authorization", TokenDto);
            request.AddHeader("Content-Type", "application/json");

            //Execute the call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            //Checking if the response is successful or not with HttpClient
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the users List
                usersList = JsonConvert.DeserializeObject<List<UserDto>>(responseContent);
            }
            return usersList;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            UserDto user = null;


            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}/users/{id}");

            //Wait until get a response
            _restClient.Timeout = -1;

            //Assign the Method Type
            var request = new RestRequest(Method.GET);

            //Assign the Headers
            request.AddHeader("Authorization", TokenDto);
            request.AddHeader("Content-Type", "application/json");

            //Execute the call
            IRestResponse response = await _restClient.ExecuteAsync(request);


            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                user = JsonConvert.DeserializeObject<UserDto>(responseContent);
            }

            return user;
        }

        public async Task<ResponseCreatedDto> AddUser(CreateUserDto user)
        {
            ResponseCreatedDto userCreatedDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}/users");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.POST);

            // Assign the Headers
            request.AddHeader("Authorization", TokenDto);
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
                userCreatedDtoResponse = JsonConvert.DeserializeObject<ResponseCreatedDto>(responseContent);
            }

            return userCreatedDtoResponse;
        }

        public async Task UpdateUser(UserDto user)
        {

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}/users/{user.id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.PUT);

            // Assign the Headers
            request.AddHeader("Authorization", TokenDto);
            request.AddHeader("Content-Type", "application/json");

            // Assign the Body
            var content = JsonConvert.SerializeObject(user);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

            }

        }
        public async Task DeleteUser(UserDto user)
        {
            UserDto userDtoResponse = null;




            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}/users/{user.id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

                // Assign the Method Type
                var request = new RestRequest(Method.DELETE);

            // Assign the Headers
            request.AddHeader("Authorization", TokenDto);
            request.AddHeader("Content-Type", "application/json");

           // Assign the Body
            var content = JsonConvert.SerializeObject(user);
            request.AddParameter("application/json", content, ParameterType.RequestBody);


            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

            }

        }
    }
}