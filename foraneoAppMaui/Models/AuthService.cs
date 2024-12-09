using foraneoAppMaui.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Register a new user
    public async Task<bool> RegisterUserAsync(RegisterRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7019/api/auth/register", content);

        return response.IsSuccessStatusCode;
    }

    // Login user and return user details or error message
    public async Task<(bool success, string message, string userId)> LoginUserAsync(LoginRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7019/api/auth/login", content);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<JsonElement>();

            // Use TryGetProperty to safely access the properties
            string message = null;
            string userId = null;

            if (result.TryGetProperty("Message", out var messageProperty))
            {
                message = messageProperty.GetString();
            }

            if (result.TryGetProperty("UserId", out var userIdProperty))
            {
                userId = userIdProperty.GetString();
            }

            return (true, message, userId);
        }

        // If login fails, read the error message
        var errorResult = await response.Content.ReadAsStringAsync();
        return (false, errorResult, null);
    }
}
