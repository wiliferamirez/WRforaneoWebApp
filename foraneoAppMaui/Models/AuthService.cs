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

    public async Task<(bool success, string message)> RegisterUserAsync(RegisterRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("http://localhost:7019/api/Auth/test", content);

        if (response.IsSuccessStatusCode)
        {
            return (true, "User registered successfully");
        }

        var errorResult = await response.Content.ReadAsStringAsync();
        return (false, errorResult);
    }


    public async Task<(bool success, string message, string userId)> LoginUserAsync(LoginRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7019/api/Auth/login", content);

        if (!response.IsSuccessStatusCode)
        {
            return (false, "Login failed. Please check your credentials.", null);
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        try
        {
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseBody);

            string message = "Login successful."; 
            string userId = null;

            if (jsonResponse.TryGetProperty("Message", out var messageProperty))
            {
                message = messageProperty.GetString();
            }

            if (jsonResponse.TryGetProperty("UserId", out var userIdProperty))
            {
                userId = userIdProperty.GetString(); 
            }

            return (true, message, userId); 
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error parsing response: {ex.Message}");
            return (false, "Error parsing the response. Please try again.", null);
        }
    }

    public async Task<bool> TestApiConnectivityAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://localhost:7019/api/Auth/test");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}
