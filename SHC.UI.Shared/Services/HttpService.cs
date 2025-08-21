
using SHC.UI.Shared.Common;
using SHC.UI.Shared.Models.Records;

namespace SHC.UI.Shared.Services;

public class HttpService
{
    private readonly HttpClient _httpClient;
    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(Common.ConfigProvider.ApiSettings.BaseUrl);
    }
    public async Task<HttpResponse<T?>> PostAsync<T>(string endpoint, object data)
    {
        var content = Serializer.ToStringContent(data);
        using var response = await _httpClient.PostAsync(endpoint, content);
        T? result = default;
        try
        {
            result = await Serializer.ReadFromHttpContentAsync<T>(response.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deserializing response: {ex.Message}");
        }
        return new HttpResponse<T?>(result, response.StatusCode);
    }
    public async Task<HttpResponse<T?>> GetAsync<T>(string endpoint)
    {
        using var response = await _httpClient.GetAsync(endpoint);
        T? result = await Serializer.ReadFromHttpContentAsync<T>(response.Content);
        return new HttpResponse<T?>(result, response.StatusCode);
    }
}
