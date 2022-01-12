using Application.Common.Dtos;
using Application.Common.Interfaces;
using Domain.Options;
using MediatR;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace Application.Auth.Commands
{
    public partial class RegisterClientCommand : IRequest<Unit>
    {
        public long ChatId { get; set; }
        public string Code { get; set; }

        public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand>
        {
            private readonly IBotService _bot;
            private readonly HttpClient _httpClient;
            private readonly IAuthTokenStorage _storage;
            private readonly IOptions<RaindropOptions> _options;

            public RegisterClientCommandHandler(IBotService bot, HttpClient httpClient, IAuthTokenStorage storage, IOptions<RaindropOptions> options)
            {
                _bot = bot;
                _httpClient = httpClient;
                _storage = storage;
                _options = options;
            }

            public async Task<Unit> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
            {
                var body = new
                {
                    code = request.Code,
                    client_id = _options.Value.ClientId,
                    redirect_uri = _options.Value.RedirectUrl,
                    client_secret = _options.Value.ClientSecret,
                    grant_type = "authorization_code"
                };

                var content = JsonContent.Create(body);
                var response = await _httpClient.PostAsync("https://raindrop.io/oauth/access_token", content);

                var tokenObj = await ParseOrDefault(response);
                if (tokenObj == default)
                {
                    await _bot.Send("An error occured during processing the response", request.ChatId);
                    return Unit.Value;
                }

                await _storage.AssignTo(request.ChatId, tokenObj.Token);

                await _bot.Send("Auth completed successfully!", request.ChatId);               
                return Unit.Value;
            }

            private static async Task<AuthResponse?> ParseOrDefault(HttpResponseMessage response)
            {
                try
                {
                    return JsonSerializer.Deserialize<AuthResponse>(await response.Content.ReadAsStringAsync());
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
