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
    public class ConceptsService
    {
        private HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;
        public String TokenUser { get; set; }
        private string BaseUrl { get; }
        public ConceptsService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(_httpClientHandler);

            SetupHttpConnection(_httpClient, baseUrl);

        }

        private void SetupHttpConnection(HttpClient httpClient, string baseUrl)
        {
            //Passing service base url (api-gateaway)
            httpClient.BaseAddress = new Uri(baseUrl);

            httpClient.DefaultRequestHeaders.Clear();
            //Define request data format  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ConceptDto>> GetConcepts()
        {
            var conceptsList = new List<ConceptDto>();
            _httpClient.DefaultRequestHeaders.Add("Authorization", this.TokenUser);
            // Sending request to find web api REST service resource to Get All Concepts using HttpClient
            HttpResponseMessage response = await _httpClient.GetAsync($"concepts");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the concepts list
                conceptsList = JsonConvert.DeserializeObject<List<ConceptDto>>(responseContent);
            }

            return conceptsList;
        }

        public async Task<ConceptDto> FindConcept(int concept_id)
        {
            var conceptsList = new List<ConceptDto>();
            ConceptDto concept = null;
            _httpClient.DefaultRequestHeaders.Add("Authorization", this.TokenUser);
            // Sending request to find web api REST service resource to Get the concept with a certain concept_id using HttpClient
            HttpResponseMessage response = await _httpClient.GetAsync($"concepts?concept_id={concept_id}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the concept list
                conceptsList = JsonConvert.DeserializeObject<List<ConceptDto>>(responseContent);
                concept = conceptsList[0];
            }

            return concept;
        }
          
        public async Task<ConceptDto> AddConcept(ConceptDto concept)
        {
            ConceptDto conceptDtoResponse = null;
            _httpClient.DefaultRequestHeaders.Add("Authorization", this.TokenUser);
            StringContent content = new StringContent(JsonConvert.SerializeObject(concept), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to Add an concept using HttpClient
            HttpResponseMessage response = await _httpClient.PostAsync($"concepts", content);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the concept list
                conceptDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }

            return conceptDtoResponse;
        }

        public async Task<ConceptDto> UpdateConcept(ConceptDto concept)
        {
            ConceptDto conceptDtoResponse = null;
            _httpClient.DefaultRequestHeaders.Add("Authorization", this.TokenUser);
            StringContent content = new StringContent(JsonConvert.SerializeObject(concept), Encoding.UTF8, "application/json");

            // Sending request to find web api REST service resource to update an concept using HttpClient
            HttpResponseMessage response = await _httpClient.PutAsync($"concepts/{concept.id}", content);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api
                conceptDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }

            return conceptDtoResponse;
        }

        public async Task<ConceptDto> DeleteConcept(int id)
        {
            ConceptDto conceptDtoResponse = null;
            _httpClient.DefaultRequestHeaders.Add("Authorization", this.TokenUser);
            // Sending request to find web api REST service resource to Delete the concept using HttpClient
            HttpResponseMessage response = await _httpClient.DeleteAsync($"concepts/{id}");

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessStatusCode)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content.ReadAsStringAsync().Result;

                // Deserializing the response recieved from web api
                conceptDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }

            return conceptDtoResponse;
        }
    }
}
