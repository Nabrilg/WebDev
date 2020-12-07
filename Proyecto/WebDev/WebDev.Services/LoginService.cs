using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WebDev.Services.Entities;
using System.Net;

namespace WebDev.Services
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Servicelogin
    {
        private string UrlBase { get; }
        private HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;
        private readonly RestClient ClienteRest;
        public Servicelogin(string UrlBase)
        {
            UrlBase = UrlBase;
            ClienteRest = new RestClient();

            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(_httpClientHandler);

            httpConneccion(_httpClient, UrlBase);
        }
        private void httpConneccion(HttpClient httpClient, string UrlBase)
        { 
            httpClient.RequestHeaders.Clear();
            httpClient.RequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Dtocontent> Login(LoginDto loginDto)
        { 
            Dtocontent
 Token_Response = null;
            var Request = new RestRequest(Method.POST);
            var contenido = JsonConvert.SerializeObject(loginDto);
            Request.AddParameter("application/json", contenido, ParameterType.RequestBody);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responsecontenido = response.contenido;
            }else{
                return null;
            }
        }
    }
}