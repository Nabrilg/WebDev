using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using System;
using System.Text;

namespace WebDev.Services
{
    public class LoginService
    {
        #region Properties
        private string BaseUrl { get; }
        private HttpClient httpClient;
        private HttpClientHandler httpClientHandler;
        #endregion

        #region Initialize
        public LoginService(string baseUrl)
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

            httpClient.DefaultRequestHeaders.Clear();

            //Define request data format  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TokenDto> Login(LoginDto login)
        {
            TokenDto tokenDtoResponse = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await httpClient.PostAsync($"login", content);

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
        #endregion
    }
}
