using ClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Clients;

public static class AuthClient
{
    private static HttpClient? _httpClient;

    public static void CreateInstance()
    {
        _httpClient = new HttpClient();
    }

    public static async Task<AuthResponse> LoginAsync(AuthRequest request)
    {
        return await SendRequestAsync(Constants.Urls.Login, request);
    }

    public static async Task<AuthResponse> RegisterAsync(AuthRequest request)
    {
        return await SendRequestAsync(Constants.Urls.Register, request);
    }

    private static async Task<AuthResponse> SendRequestAsync(string url, AuthRequest request)
    {
        var serializedBody = JsonConvert.SerializeObject(request);
        var content = new StringContent(serializedBody, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync(url, content);

            var responseContent = await response.Content.ReadAsStringAsync();
            var authResponse = JsonConvert.DeserializeObject<AuthResponse>(responseContent);

            return authResponse ?? new AuthResponse();
        }
        catch (HttpRequestException ex) when (ex.InnerException is System.Net.Sockets.SocketException)
        {
            return new AuthResponse { Error = "The servers are down. Please try again later." };
        }
        catch (Exception ex)
        {
            return new AuthResponse { Error = $"An error occurred: {ex.Message}" };
        }
    }
}