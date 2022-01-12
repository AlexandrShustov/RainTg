using System.Text.Json.Serialization;

namespace Application.Common.Dtos;

public class AuthResponse
{
    [JsonPropertyName("access_token")]
    public string Token { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("expires_in")]
    public long ExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
}
