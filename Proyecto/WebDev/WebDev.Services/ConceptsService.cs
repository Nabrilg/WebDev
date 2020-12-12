using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using WebDev.Services.Entities;


namespace WebDev.Services
{
   public class ConceptsService
   {
        private readonly RestClient _restClient;
        private string BaseUrl { get; }
        public TokenDto TokenDto { get; set; }

        public ConceptsService(string baseUrl, string token)
        {
            BaseUrl = baseUrl;
            _restClient = new RestClient();
            TokenDto = new TokenDto();
            TokenDto.Token = token;
        }


        public async Task<List<ConceptDto>> GetConcepts()
        {
            var conceptsList = new List<ConceptDto>();

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}api/concepts");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.GET);

            // Assign the Headers and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api 
                conceptsList = JsonConvert.DeserializeObject<List<ConceptDto>>(responseContent);
            }

            return conceptsList;
        }


        public async Task<ConceptDto> GetConceptById(int id)
        {
            List<ConceptDto> concept = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}api/concepts");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.GET);

            // Assign the Headers and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("concept_id", id);

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api
                concept = JsonConvert.DeserializeObject<List<ConceptDto>>(responseContent);
            }

            return concept[0];

        }


        public async Task<ConceptDto> AddConcept(ConceptDto concept)
        {
            ConceptDto conceptDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}api/concepts");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.POST);

            // Assign the Headers and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");

            // Assign the Body
            var content = JsonConvert.SerializeObject(concept);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.Created)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api
                conceptDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }

            return conceptDtoResponse;
        }



        public async Task<ConceptDto> UpdateConcept(ConceptDto concept)
        {
            ConceptDto conceptDtoResponse = null;

            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}api/concepts/{concept.Id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.PUT);

            // Assign the Headers and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");

            // Assign the Body
            var content = JsonConvert.SerializeObject(concept);
            request.AddParameter("application/json", content, ParameterType.RequestBody);

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                //Deserializing the response recieved from web api 
                conceptDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }
            return conceptDtoResponse;
        }


        public async Task<ConceptDto> DeleteConcept(int id)
        {
            ConceptDto conceptDtoResponse = null;


            // Assign the URL
            _restClient.BaseUrl = new Uri($"{BaseUrl}api/concepts/{id}");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.DELETE);

            // Assign the Headers and Parameters
            request.AddHeader("Authorization", TokenDto.Token);
            request.AddHeader("Content-Type", "application/json");

            // Execute the Call
            IRestResponse response = await _restClient.ExecuteAsync(request);

            // Checking the response is successful or not which is sent using RestSharp
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                // Storing the content response recieved from web api
                var responseContent = response.Content;

                // Deserializing the response recieved from web api
                conceptDtoResponse = JsonConvert.DeserializeObject<ConceptDto>(responseContent);
            }

            return conceptDtoResponse;
        }


    }

}
