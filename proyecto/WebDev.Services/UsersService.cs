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
        private readonly RestClient _restClient;
 
        private string BaseUrl { get; }
        public static TokenDto TokenDto { get; set; }

        public UsersService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();
        }

        public async Task<bool> ValidateUser(LoginDto login)
        {
            _restClient.BaseUrl = new Uri($"{BaseUrl}login");
            _restClient.Timeout = -1;

            var request = new RestRequest(Method.POST);

            var content = JsonConvert.SerializeObject(login);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            IRestResponse response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = response.Content;
                TokenDto = JsonConvert.DeserializeObject<TokenDto>(responseContent);
                return true;
            }
            return false;
        }


        public async Task<List<UserDto>> GetUsers()
        {
            try
            {
                var usersList = new List<UserDto>();

                _restClient.BaseUrl = new Uri($"{BaseUrl}users");
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.GET);

                request.AddHeader("Authorization", TokenDto.token);
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    usersList = JsonConvert.DeserializeObject<List<UserDto>>(responseContent); //Mapea el json a la lista de user list de useer dto
                }
                else
                {
                    throw new System.ArgumentException("Se presento una excepción", "original");
                }

                return usersList;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Se presento un error obteniendo todos los usuarios:  " + ex.Message);
                return null;
            }
            
        }
        public async Task<bool> AddUser(UserDto user)
        {

            try
            {
                

                _restClient.BaseUrl = new Uri($"{BaseUrl}users");
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.POST);

                var content = JsonConvert.SerializeObject(user);
                request.AddParameter("application/json", content, ParameterType.RequestBody);

                request.AddHeader("Authorization", TokenDto.token);
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    return true;
                }
                else
                {
                    throw new System.ArgumentException("Se presento una excepción", "original");

                }
                return false;   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se presento un error creando el usuario:  " + ex.Message);
                return false;
            }

        }

        public async Task<bool> DeleteUserById(int id)
        {

            try
            {

                _restClient.BaseUrl = new Uri($"{BaseUrl}users/" + id);
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.DELETE);


                request.AddHeader("Authorization", TokenDto.token);
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    return true;
                }
                else
                {
                    throw new System.ArgumentException("Se presento una excepción", "original");
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se presento un error eliminando el usuario:  " + ex.Message);
                return false;
            }

        }

        public async Task<UserDto> GetUserById(int id)
        {

            try
            {
                UserDto userReturn = new UserDto();

                _restClient.BaseUrl = new Uri($"{BaseUrl}users/" + id);
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.GET);


                request.AddHeader("Authorization", TokenDto.token);
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                    userReturn = JsonConvert.DeserializeObject<UserDto>(responseContent); //Mapea el json a la lista de user list de useer dto
                }
                else
                {
                    throw new System.ArgumentException("Se presento una excepción", "original");
                }
                return userReturn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se presento un error obteniendo el usuario:  " + ex.Message);
                return null;
            }

        }


        public async Task<UserDto> UpdateUserById(UserDto user)
        {

            try
            {
                UserDto userReturn = new UserDto();

                _restClient.BaseUrl = new Uri($"{BaseUrl}users/" + user.id);
                _restClient.Timeout = -1;

                var request = new RestRequest(Method.PUT);
                var content = JsonConvert.SerializeObject(user);
                request.AddParameter("application/json", content, ParameterType.RequestBody);

                request.AddHeader("Authorization", TokenDto.token);
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = await _restClient.ExecuteAsync(request);


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = response.Content;
                }
                else
                {
                    throw new System.ArgumentException("Se presento una excepción", "original");
                }
                return userReturn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se presento un error actualizando el usuario:  " + ex.Message);
                return null;
            }

        }


    }
}
