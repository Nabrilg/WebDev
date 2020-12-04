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
    public class LoginService
    {
        private string BaseUrl { get; }
        private HttpClient _httpClient;
        // Agregar Vble a nivel de la clase del controlador
        private HttpClientHandler _httpClientHandler;

        private readonly RestClient _restClient;
        public LoginService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();

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

        public async Task<TokenDto> Login(LoginDto loginDto)
        {


            TokenDto tokenDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}/login");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.POST);

            // Assign the Body
            var content = JsonConvert.SerializeObject(loginDto);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

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

/*
           Console.WriteLine(loginDto.ToString());
           TokenDto tokenDtoResponse = null;
           StringContent content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

           //Sending the request
           HttpResponseMessage response = await _httpClient.PostAsync($"api/Login", content);
           if (response.IsSuccessStatusCode)
           {
               // Storing the content response recieved from web api
               var responseContent = response.Content.ReadAsStringAsync().Result;

               //Deserializing the response recieved from web api
               tokenDtoResponse = JsonConvert.DeserializeObject<TokenDto>(responseContent);
               Console.WriteLine(tokenDtoResponse.Token);
           }

           Console.WriteLine("Fue null");
           return tokenDtoResponse;
           */