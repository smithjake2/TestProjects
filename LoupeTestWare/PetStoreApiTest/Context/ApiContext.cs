using System.Net.Http.Json;
using PetStoreApiTest.ApiHelper;

namespace PetStoreApiTest.Context
{
    public class ApiContext
    {
        public ApiContext(EnvironmentContext environmentContext)
        {
            Client = new HttpClient();
            Responses = new List<HttpResponseMessage>();
            EnvironmentContext = environmentContext;
        }
        public HttpClient Client { get; }
        public IList<HttpResponseMessage> Responses { get; }
        public EnvironmentContext EnvironmentContext { get; }

        public async Task<IList<Pet>> FindByStatusAsync(string status)
        {
            return await GetPetsAsync(HttpMethod.Get, $"pet/findByStatus?status={status}");
        }

        public async Task<IList<Pet>> FindByTagAsync(string tag)
        {
            return await GetPetsAsync(HttpMethod.Get, $"pet/findByTags?tags={tag}");
        }

        public async Task<Pet> AddPet(Pet petToAdd)
        {
            //var request = new HttpRequestMessage(HttpMethod.Post, Path.Combine(EnvironmentContext.Server, "pet"));

            //request.Headers.Add("Accept", "*/*");

            //var bodyContent = new StringContent(petToAdd.ToJson(), null, "application/json");

            //request.Content = bodyContent;
            //var response = await Client.SendAsync(request);
            //Responses.Add(response);

            //return await response.Content.ReadFromJsonAsync<Pet>();

            return await SendPetToApi(HttpMethod.Post, petToAdd);

        }

        public async Task<Pet> UpdatePet(Pet petToUpdate)
        {
            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Put, Path.Combine(EnvironmentContext.Server, "pet"));
            //request.Headers.Add("Accept", "*/*");
            //var content = new StringContent("{\r\n  \"id\": 115465825487333,\r\n  \"category\": {\r\n    \"id\": 115465825487333,\r\n    \"name\": \"updatedNamePut\"\r\n  },\r\n  \"name\": \"updatedNamePut\",\r\n  \"photoUrls\": [\r\n    \"photoUrls34Upade\"\r\n  ],\r\n  \"tags\": [\r\n    {\r\n      \"id\": 889999,\r\n      \"name\": \"updatedNamePut\"\r\n    }\r\n  ],\r\n  \"status\": \"pending\"\r\n}", null, "application/json");
            //request.Content = content;
            //var response = await client.SendAsync(request);

            return await SendPetToApi(HttpMethod.Put, petToUpdate);


        }

        private async Task<Pet> SendPetToApi(HttpMethod method, Pet petToSend)
        {
            var request = new HttpRequestMessage(method, Path.Combine(EnvironmentContext.Server, "pet"));

            request.Headers.Add("Accept", "*/*");

            var bodyContent = new StringContent(petToSend.ToJson(), null, "application/json");

            request.Content = bodyContent;
            var response = await Client.SendAsync(request);
            Responses.Add(response);

            return await response.Content.ReadFromJsonAsync<Pet>();
        }

        public async Task<IApiResponse> GetPetById(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Path.Combine(EnvironmentContext.Server, $"pet/{id}"));
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);

            Responses.Add(response);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Pet>();
            }
            else
            {
                return await response.Content.ReadFromJsonAsync<ErrorResponseMessage>();
            }
        }

        public async Task<ErrorResponseMessage> DeletePetById(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, Path.Combine(EnvironmentContext.Server, $"pet/{id}"));
            request.Headers.Add("api_key", "api_key39");
            request.Headers.Add("Accept", "*/*");
            var content = new StringContent("", null, "text/plain");
            request.Content = content;
            var response = await Client.SendAsync(request);

            Responses.Add(response);

            if (response.Content.Headers.ContentLength > 0)
            {
                return await response.Content.ReadFromJsonAsync<ErrorResponseMessage>();
            }
            else
            {
                return null;
            }
        }

        public async Task<ErrorResponseMessage> UpdatePetWithForm(string id, string updatedName, string updatedStatus)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Path.Combine(EnvironmentContext.Server, $"pet/{id}"));
            request.Headers.Add("Accept", "*/*");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("name", updatedName));
            collection.Add(new("status", updatedStatus));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await Client.SendAsync(request);

            Responses.Add(response);

            return await response.Content.ReadFromJsonAsync<ErrorResponseMessage>();
        }

        private async Task<IList<Pet>> GetPetsAsync(HttpMethod method, string filter)
        {
            var request = new HttpRequestMessage(method, Path.Combine(EnvironmentContext.Server, filter));
            request.Headers.Add("Accept", "application/json");
            var response = await Client.SendAsync(request);

            Responses.Add(response);

            return await response.Content.ReadFromJsonAsync<IList<Pet>>();
        }
    }
}
