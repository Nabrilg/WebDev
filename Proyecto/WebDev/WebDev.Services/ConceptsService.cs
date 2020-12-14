using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebDev.Services.Entities;


namespace WebDev.Services
{
    public class ConceptsService
    {
        private readonly RestClient _restClient;
        public string BaseUrl { get; }
        public string Token { get; set; }

        public ConceptsService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();
        }

        public async Task<List<ConceptDto>> GetConcepts()
        {
            var conceptsList = new List<ConceptDto>();

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.GET);

            // Assign the Headers
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
               conceptsList = JsonConvert.DeserializeObject<List<ConceptDto>>(responseContent);
            }

            return conceptsList;
        }

        public async Task<ConceptDto> GetConceptById(int id)
        {
            List<ConceptDto> concept = null;
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts");
            // Wait until to get a response
            _restClient.Timeout = -1;
            // Assign the Method Type
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("concept_id", id);
            IRestResponse response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                concept = JsonConvert.DeserializeObject<List<ConceptDto>>(responseContent);
            }
            return concept[0];
        }

        public async Task<ConceptDto> AddConcept(ConceptDto concept)
        {
            ConceptDto conceptCreatedDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.POST);

            // Assign the Headers
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");

            // Assign the Body
            var content = JsonConvert.SerializeObject(concept);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.Created)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                conceptCreatedDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }

            return conceptCreatedDtoResponse;
        }

        public async Task<ConceptDto> UpdateConcept(ConceptDto concept)
        {
            ConceptDto conceptCreatedDtoResponse = null;
            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts/{concept.Id}");
            // Wait until to get a response
            _restClient.Timeout = -1;
            // Assign the Method Type
            var request = new RestRequest(Method.PUT);
            // Assign the Headers
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");
            // Assign the Body
            var content = JsonConvert.SerializeObject(concept);
            request.AddParameter("application/json", content, ParameterType.RequestBody);
            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                conceptCreatedDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }
            return conceptCreatedDtoResponse;
        }

        public async Task<ConceptDto> DeleteConcept(int id)
        {
            ConceptDto conceptCreatedDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts/{id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api and storing into the Employee list
                conceptCreatedDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }

            return conceptCreatedDtoResponse;
        }
    }
}
