using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebDev.Services.Entities;
using Newtonsoft.Json;
using RestSharp;


namespace WebDev.Services
{
    public class ConceptsService
    {
        private readonly RestClient _restClient;
        public string BaseUrl { get; }
        public string Token { get; set; }

    public async Task<ConceptDto> GetConceptById(int id)
        {
            List<ConceptDto> concept = null;
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts");
            _restClient.Timeout = -1;            
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("concept_id", id);
            var request = new RestRequest(Method.GET);
            IRestResponse response = await _restClient.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = response.Content;
                concept = JsonConvert.DeserializeObject<List<ConceptDto>>(responseContent);
            }
            return concept[0];
        }

        public async Task<ConceptDto> UpdateConcept(ConceptDto concept)
        {
            ConceptDto conceptCreatedDtoResponse = null;
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts/{concept.Id}");
            _restClient.Timeout = -1;
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");            
            request.AddParameter("application/json", content, ParameterType.RequestBody);
            var request = new RestRequest(Method.PUT);            
            var content = JsonConvert.SerializeObject(concept);
            IRestResponse response = await _restClient.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var responseContent = response.Content;
                conceptCreatedDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }
            return conceptCreatedDtoResponse;
        }


        public ConceptsService(string baseUrl)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();
        }

        public async Task<List<ConceptDto>> GetConcepts()
        {
            var conceptsList = new List<ConceptDto>();            
            var request = new RestRequest(Method.GET);
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts");
            _restClient.Timeout = -1;
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = response.Content;
               conceptsList = JsonConvert.DeserializeObject<List<ConceptDto>>(responseContent);
            }

            return conceptsList;
        }

         public async Task<ConceptDto> DeleteConcept(int id)
        {
            ConceptDto conceptCreatedDtoResponse = null;
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts/{id}");
            _restClient.Timeout = -1;            
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                var responseContent = response.Content;
                conceptCreatedDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }

            return conceptCreatedDtoResponse;
        }

       

        public async Task<ConceptDto> AddConcept(ConceptDto concept)
        {
            ConceptDto conceptCreatedDtoResponse = null;
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts");
            _restClient.Timeout = -1;           
            request.AddParameter("application/json", content, ParameterType.RequestBody);
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");

            var content = JsonConvert.SerializeObject(concept);
            var request = new RestRequest(Method.POST);            
            IRestResponse response = await _restClient.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                var responseContent = response.Content;
                conceptCreatedDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }

            return conceptCreatedDtoResponse;
        }

    
    }
}
