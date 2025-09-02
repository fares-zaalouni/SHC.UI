
using SHC.UI.Shared.Models.Records;

namespace SHC.UI.Shared.Security;

public interface IAuthenticatedApiClient
{
    Task<T> GetAsync<T>(string endpoint);
    Task<HttpResponse<TResponse?>> PostAsync<TResponse>(string endpoint, object data);
    Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest data);
    Task DeleteAsync(string endpoint);
}
