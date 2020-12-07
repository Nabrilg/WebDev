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
    public class LoginService
    {
        private HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;
        private string BaseUrl { get; }
        public LoginService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(_httpClientHandler);

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
        public async Task<TokenDto> ValidateUser(UserDto user)
        {
            TokenDto tokenDtoResponse = null;
            UserLoginDto userLogin = new UserLoginDto { email = user.Email, password = user.Password };
            var jsq = JsonConvert.SerializeObject(userLogin);

            StringContent content = new StringContent(jsq, Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to validate an User using HttpClient
            HttpResponseMessage response = await _httpClient.PostAsync($"login", content);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list
                tokenDtoResponse = JsonConvert.DeserializeObject<TokenDto>(responseContent);
            }

            return tokenDtoResponse;
        }
    }
}