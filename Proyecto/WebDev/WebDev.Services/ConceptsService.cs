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
            _restClient.BaseUrl = new Uri($"{BaseUrl}concepts");

            // Wait until to get a response
            _restClient.Timeout = -1;

            // Assign the Method Type
            var request = new RestRequest(Method.GET);

            // Assign the Headers
            request.AddHeader("Authorization", TokenDto.Token);
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
    }
}
