using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using System.Net;
using System.Net.Http.Json;

namespace Infrastructure.Raindrops
{
    public class RaindropService : IRaindropService
    {
        private readonly HttpClient _httpClient;

        public RaindropService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Post(Raindrop @new)
        {
            var content = JsonContent.Create(@new);
            var result = await _httpClient.PostAsync("https://api.raindrop.io/rest/v1/raindrop", content);

            if (result.IsSuccessStatusCode)
                return;

            Exception exception = result.StatusCode switch
            {
                HttpStatusCode.Unauthorized => throw new NotAuthorizedException(),
                _ => throw new Exception(),
            };
        }
    }
}
