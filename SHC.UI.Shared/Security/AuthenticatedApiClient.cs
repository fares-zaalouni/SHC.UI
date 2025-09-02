

using SHC.UI.Shared.Common;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.Shared.DTOs.Responses;
using SHC.UI.Shared.Models.Records;
using SHC.UI.Shared.Services;
using SHC.UI.Shared.Session;
using SHC.UI.Shared.Settings;

namespace SHC.UI.Shared.Security;

public class AuthenticatedApiClient : IAuthenticatedApiClient
{
    private readonly ISessionManager _sessionManager;
    private readonly IHttpService _httpService;
    private readonly ICredentialStorage _credentialStorage;
    private readonly string _refreshEndpoint = ConfigProvider.ApiSettings.RenewTokensEndpoint;
    private readonly ILocalSettingsManager _localSettingsManager;

    public AuthenticatedApiClient(
        ISessionManager sessionManager,
        IHttpService httpService,
        ICredentialStorage credentialStorage,
        ILocalSettingsManager localSettingsManager
        )
    {
        _sessionManager = sessionManager;
        _httpService = httpService;
        _credentialStorage = credentialStorage;
        _localSettingsManager = localSettingsManager;
    }

    public async Task<HttpResponse<TResponse?>> PostAsync<TResponse>(string endpoint, object data)
    {
        IReadOnlySession readOnlySession = _sessionManager.GetCurrentSession();
        HttpResponse<TResponse?> httpResponse = await _httpService.PostAsync<TResponse>(endpoint, data, readOnlySession.AccessToken);
        if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            var tokens = await RenewTokensAsync(readOnlySession);
            if (tokens == null)
                return new HttpResponse<TResponse?>(default, System.Net.HttpStatusCode.Unauthorized);

            IReadOnlySession freshSession = _sessionManager.GetCurrentSession();
            httpResponse = await _httpService.PostAsync<TResponse>(endpoint, data, freshSession.AccessToken);
        }

        return httpResponse;

    }

    private async Task<RenewTokensResponseDTO?> RenewTokensAsync(IReadOnlySession readOnlySession)
    {
        string? refreshToken = _credentialStorage.GetToken();
        if (refreshToken != null)
        {
            RenewTokensRequestDTO renewTokensDTO = new(
                readOnlySession.UserId,
                _localSettingsManager.GetSettings()!.DeviceId,
                readOnlySession.UserPhoneNumber,
                refreshToken
                );
            var renewTokensResponse = await _httpService.PostAsync<RenewTokensResponseDTO>(_refreshEndpoint, renewTokensDTO);
            if (renewTokensResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var tokens = renewTokensResponse.Content!;
                _credentialStorage.StoreToken(tokens.RefreshToken.Token);
                _sessionManager.RefreshSession(tokens.AccessToken.Token, tokens.AccessToken.ExpiresAt);
                return tokens;
            }
        }
        _credentialStorage.ClearToken();
        _sessionManager.ClearSession();
        return null;
    }

    public Task DeleteAsync(string endpoint)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetAsync<T>(string endpoint)
    {
        throw new NotImplementedException();
    }

    public Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        throw new NotImplementedException();
    }
}
