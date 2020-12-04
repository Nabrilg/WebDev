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
using RestSharp;
using System.Net;

namespace WebDev.Services
{
    public class LoginService
    {
        private readonly RestClient _restClient;
        private string BaseUrl { get; }
        public LoginService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();

        }

        public async Task<TokenDto> LoginUsers(LoginDto login)
        {
            TokenDto tokenDtoResponse = null;
            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}login");
            // Wait until to get a response
            _restClient.Timeout = -1;
            // Assign the Method Type
            var request = new RestRequest(Method.POST);
            var objectJson = JsonConvert.SerializeObject(login);
            request.AddParameter("application/json", objectJson, ParameterType.RequestBody);
            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;
                //Deserializing the response recieved from web api and storing into the Employee list
                tokenDtoResponse = JsonConvert.DeserializeObject<TokenDto>(responseContent);
            }

            return tokenDtoResponse;
        }
    }
}
