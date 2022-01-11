using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Options;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Json;

namespace Infrastructure.Raindrops
{
    public class RaindropService : IRaindropService
    {
        private readonly HttpClient _httpClient;

        public RaindropService(HttpClient httpClient, IOptions<RaindropOptions> options)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.Value.TestToken}");
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
