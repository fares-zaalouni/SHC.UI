
using SHC.UI.Shared.Common;
using SHC.UI.Shared.DTOs.Responses;
using SHC.UI.Shared.Models.Records;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SHC.UI.Shared.Services;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;
    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<HttpResponse<T?>> PostAsync<T>(string endpoint, object data, string? accessToken = null)
    {

        var content = Serializer.ToStringContent(data);

        HttpRequestMessage request = new(HttpMethod.Post, endpoint)
        {
            Content = content
        };
        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);
        }

        using var response = await _httpClient.SendAsync(request);
        T? result = default;
        try
        {
            result = await Serializer.ReadFromHttpContentAsync<T>(response.Content);
            string debugJson = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            Debug.WriteLine(debugJson); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deserializing response: {ex.Message}");
        }
        return new HttpResponse<T?>(result, response.StatusCode);
    }
    public async Task<HttpResponse<T?>> GetAsync<T>(string endpoint, string? accessToken = null)
    {
        using var response = await _httpClient.GetAsync(endpoint);
        T? result = await Serializer.ReadFromHttpContentAsync<T>(response.Content);
        return new HttpResponse<T?>(result, response.StatusCode);
    }
}
