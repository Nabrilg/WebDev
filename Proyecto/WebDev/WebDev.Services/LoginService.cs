using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebDev.Services
{
    public class LoginService
    {
        private HttpClient _httpClient;
        private string BaseUrl { get; }
        public LoginService(string baseUrl)
        {
            BaseUrl = baseUrl;

            _httpClient = new HttpClient();

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
        public async Task<TokenDto> LoginUsers(LoginDto login)
        {
            TokenDto tokenDtoResponse = null;
            var objectJson = JsonConvert.SerializeObject(login);
           // var stringJson = JsonConvert.SerializeObject(objectJson);
          //  StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            // StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await _httpClient.PostAsync($"login", new StringContent(objectJson, Encoding.UTF8, "application/json"));
            //HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"login", login);

            // Checking the response is successful or not which is sent using HttpClient
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
