using LabSession4_CodeFirst.Models;
using LabSession4_CodeFirst.Services.Abstractions;
using Newtonsoft.Json.Linq;

namespace LabSession4_CodeFirst.Services;

public class KeycloakAuthService : IKeycloakAuthService
{
    private readonly HttpClient _httpClient;
    private readonly string _tokenEndpoint;

    public KeycloakAuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _tokenEndpoint = "http://localhost:8080/realms/inmind_lab7/protocol/openid-connect/token";
    }

    public async Task<string> AuthenticateAsync(LoginDto request)
    {
        // Create the request content
        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", "myuniversity"),
            new KeyValuePair<string, string>("client_secret", "mySecretKey"),
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", request.Username),
            new KeyValuePair<string, string>("password", request.Password)
        });

        try
        {
            var response = await _httpClient.PostAsync(_tokenEndpoint, requestContent);

            // Check if the response was successful
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error from Keycloak: {errorContent}");
            }

            var content = await response.Content.ReadAsStringAsync();
            
            var jsonResponse = JObject.Parse(content);
            
            var accessToken = jsonResponse["access_token"]?.ToString();
            
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Authentication failed: Access token not found.");
            }

            return accessToken;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while authenticating: {ex.Message}", ex);
        }
    }
}