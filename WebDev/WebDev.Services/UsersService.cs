using System;
using RestSharp;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using Newtonsoft.Json;
using System.Net;
using WebDev.Services.Helpers;

namespace WebDev.Services
{
    public class UsersService
    {
        #region Atributos
        private readonly RestClient _restClient;
        public string BaseUrl { get; }
        #endregion

        #region Constructores
        public UsersService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();
        }
        #endregion

        #region Get Users
        public async Task<List<UserDto>> GetUsers()
        {
            try
            {
                List<UserDto> listUser = null;

                _restClient.BaseUrl = new Uri($"{BaseUrl}users");
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.GET);

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("authorization", GlobalVariables.tokenDto.Token);

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if(response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    listUser = JsonConvert.DeserializeObject<List<UserDto>>(responseContent);
                }

                return listUser;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Excepcion obteniendo los usuarios: " + ex.Message);
                return null;
            }
        }
        #endregion

        #region get User by Id
        public async Task<UserDto> GetUserById(int id)
        {
            try
            {
                UserDto user = null;

                _restClient.BaseUrl = new Uri($"{BaseUrl}users/" + id);
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.GET);

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("authorization", GlobalVariables.tokenDto.Token);

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    user = JsonConvert.DeserializeObject<UserDto>(responseContent);
                }

                return user;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Se presento una excepción en Get User by Id: " + ex.Message);
                return null;
            }
        }
        #endregion

        #region Add User
        public async Task<UserDto> AddUser(UserDto user)
        {
            try
            {
                UserDto userDtoResponse = null;

                _restClient.BaseUrl = new Uri($"{BaseUrl}users");
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.POST);
                var content = JsonConvert.SerializeObject(user);

                request.AddParameter("application/json", content, ParameterType.RequestBody);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("authorization", GlobalVariables.tokenDto.Token);

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    userDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
                }

                return userDtoResponse;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Excepción creando usuarios: " + ex.Message);
                return null;
            }
        }
        #endregion

        #region Update User
        public async Task<UserDto> UpdateUser(UserDto user)
        {
            try
            {
                UserDto userDtoResponse = null;

                _restClient.BaseUrl = new Uri($"{BaseUrl}users/" + user.id);
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.PUT);
                var content = JsonConvert.SerializeObject(user);

                request.AddParameter("application/json", content, ParameterType.RequestBody);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("authorization", GlobalVariables.tokenDto.Token);

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    userDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
                }

                return userDtoResponse;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Excepción actualizando usuarios: " + ex.Message);
                return null;
            }
            
        }
        #endregion

        #region Delete User
        public async Task<UserDto> DeleteUser(int id)
        {
            try
            {
                UserDto userDtoResponse = null;

                _restClient.BaseUrl = new Uri($"{BaseUrl}users/" + id);
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.DELETE);

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("authorization", GlobalVariables.tokenDto.Token);

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    userDtoResponse = JsonConvert.DeserializeObject<UserDto>(responseContent);
                }

                return userDtoResponse;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Excepción actualizando usuarios: " + ex.Message);
                return null;
            }   
        }
        #endregion
    }
}
