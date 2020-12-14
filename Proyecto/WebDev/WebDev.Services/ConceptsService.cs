using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using System;

namespace WebDev.Services
{
    public class ConceptsService
    {
        #region Properties
        private string BaseUrl { get; }
        private readonly HttpClient httpClient;
        #endregion

        #region Initialize
        public ConceptsService(string baseUrl)
        {
            BaseUrl = baseUrl;
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Clear();
            SetupHttpConnection(httpClient, baseUrl);
        }
        #endregion

        #region Methods
        private void SetupHttpConnection(HttpClient httpClient, string baseUrl)
        {
            //Passing service base url  
            httpClient.BaseAddress = new Uri(baseUrl);

            //Define request data format
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void UpdateCurrentToken(string token)
        {
            if (token != null)
            {
                // Clear all headers before updating the current token
                httpClient.DefaultRequestHeaders.Clear();

                // Set the current token
                httpClient.DefaultRequestHeaders.Add("authorization", token);
            }
        }

        public async Task<List<ConceptDto>> GetConcepts(string token)
        {
            try
            {
                // Asuming the token change or expires every certain time
                UpdateCurrentToken(token);

                var conceptsList = new List<ConceptDto>();

                // Building a request with an empty json so the api can consume it
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                };

                // Sending request to find web api REST service resource to Get All Users using HttpClient
                HttpResponseMessage response = await httpClient.SendAsync(request);

                // Checking the response is successful or not which is sent using HttpClient
                if (response.IsSuccessStatusCode)
                {
                    // Storing the content response recieved from web api
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    conceptsList = JsonConvert.DeserializeObject<List<ConceptDto>>(responseContent);
                }

                return conceptsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<ConceptDto> GetConceptById(int id, string token)
        {
            ConceptDto conceptDto = null;
            try
            {
                // Re-fetchs all the concepts
                List<ConceptDto> conceptDtos = await GetConcepts(token);

                foreach (ConceptDto c in conceptDtos)
                {
                    // Asigns the concept that matches the given id
                    if (c.Id == id)
                    {
                        conceptDto = c;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return conceptDto;
        }

        public async Task<IdResponseDto> AddConcept(ConceptDto concept, string token)
        {
            IdResponseDto idResponseDto = null;
            try
            {
                // Asuming the token change or expires every certain time
                UpdateCurrentToken(token);

                // Building the request
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{httpClient.BaseAddress}"),
                    Content = new StringContent(JsonConvert.SerializeObject(concept), Encoding.UTF8, "application/json")
                };

                // Sending request to find web api REST service resource to Add an User using HttpClient
                HttpResponseMessage response = await httpClient.SendAsync(request);

                // Checking the response is successful or not which is sent using HttpClient
                if (response.IsSuccessStatusCode)
                {
                    // Storing the content response recieved from web api
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list
                    idResponseDto = JsonConvert.DeserializeObject<IdResponseDto>(responseContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return idResponseDto;
        }

        public async Task<bool> UpdateConcept(ConceptDto concept, int id, string token)
        {
            // Asuming the token change or expires every certain time
            UpdateCurrentToken(token);

            // Building the request
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{httpClient.BaseAddress}/{id}"),
                Content = new StringContent(JsonConvert.SerializeObject(concept), Encoding.UTF8, "application/json")
            };

            // Sending request to find web api REST service resource to Add an User using HttpClient
            HttpResponseMessage response = await httpClient.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteConcept(int id, string token)
        {
            // Asuming the token change or expires every certain time
            UpdateCurrentToken(token);

            // Building a request with an empty json so the api can consume it
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{httpClient.BaseAddress}/{id}"),
                Content = new StringContent("{}", Encoding.UTF8, "application/json")
            };

            // Sending request to find web api REST service resource to Get All Users using HttpClient
            HttpResponseMessage response = await httpClient.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}
