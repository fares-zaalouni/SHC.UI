using SHC.UI.Shared.Models.Records;

namespace SHC.UI.Shared.Services;

public interface IHttpService
{
    Task<HttpResponse<T?>> PostAsync<T>(string endpoint, object data, string? accessToken = null);
    Task<HttpResponse<T?>> GetAsync<T>(string endpoint, string? accessToken = null);
}
