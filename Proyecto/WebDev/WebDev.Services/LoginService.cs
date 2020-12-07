using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using WebDev.Services.Helpers;

namespace WebDev.Services
{
    public class LoginService
    {
        #region Atributos
        private readonly RestClient _restClient;
        private string BaseUrl { get; }
        #endregion

        #region Constructores
        public LoginService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();
        }
        #endregion

        #region Métodos
        public async Task<TokenDto> ValideUser(LoginDto login)
        {
            try
            {
                TokenDto tokenDto = null;

                _restClient.BaseUrl = new Uri($"{BaseUrl}login");
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.POST);
                var content = JsonConvert.SerializeObject(login);

                request.AddParameter("application/json", content, ParameterType.RequestBody);
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    tokenDto = JsonConvert.DeserializeObject<TokenDto>(responseContent);
                }

                GlobalVariables.tokenDto = tokenDto;
                return tokenDto;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Excepción en el login: " + ex.Message);
                return null;
            }
            
        }
        #endregion
    }
}
