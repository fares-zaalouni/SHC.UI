using SHC.UI.Shared.Common;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.Shared.DTOs.Responses;
using SHC.UI.Shared.Models;
using SHC.UI.Shared.Models.Records;
using SHC.UI.Shared.Security;
using SHC.UI.Shared.Session;
using SHC.UI.Shared.Settings;
using System.Diagnostics;


namespace SHC.UI.Shared.Services;

public class UserService
{
    private readonly IHttpService _httpService;
    private readonly ApiSettings _apiSettings;
    private readonly ILocalSettingsManager _localSettingsManager;
    private readonly ICredentialStorage _credentialService;
    private readonly ISessionManager _sessionManager;

    public UserService(
        IHttpService httpService,
        ILocalSettingsManager localSettingsManager,
        ICredentialStorage credentialService,
        ISessionManager sessionManager
        )
    {
        _httpService = httpService;
        _apiSettings = ConfigProvider.ApiSettings;
        _localSettingsManager = localSettingsManager;
        _credentialService = credentialService;
        _sessionManager = sessionManager;
    }
    public async Task<Result<LoginInfo>> LoginAsync(string phoneNumber, string password, Roles role)
    {
        //The id should be generated first time the app runs and stored in local settings
        LocalSettings localSettings = _localSettingsManager.GetSettings()!;
        LoginRequestDTO loginRequest = new(phoneNumber, password, role, localSettings.DeviceId);
        try
        {
            HttpResponse<LoginResponseDTO?> result = await _httpService.PostAsync<LoginResponseDTO>(_apiSettings.LoginEndpoint, loginRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.OK && result.Content != null)
            {
                LoginResponseDTO resultContent = result.Content!;
                _credentialService.StoreToken(resultContent.RefreshToken.Token);
                _sessionManager.StartSession(resultContent.UserId, phoneNumber, resultContent.AccessToken.Token, resultContent.AccessToken.ExpiresAt);

            }
            return result.StatusCode switch
            {
                System.Net.HttpStatusCode.OK when result.Content != null => Result<LoginInfo>.Success(new LoginInfo(result.Content.Firstname, result.Content.Firstname)),
                System.Net.HttpStatusCode.NotFound => Result<LoginInfo>.Failure(new ErrorDetail(ErrorType.NotFound, "Invalid Credentials.")),
                System.Net.HttpStatusCode.InternalServerError => Result<LoginInfo>.Failure(new ErrorDetail(ErrorType.Server, "Server Issue.")),
                _ => Result<LoginInfo>.Failure(new ErrorDetail(ErrorType.Unexpected, "Some unexpected issue occured, please try again later."))
,
            };
        }
        catch (HttpRequestException)
        {
            return Result<LoginInfo>.Failure(new ErrorDetail(ErrorType.Network, "Network Issue."));
        }
        catch (TaskCanceledException)
        {
            return Result<LoginInfo>.Failure(new ErrorDetail(ErrorType.Network, "Network Issue."));
        }
        catch (Exception ex)
        {
            return Result<LoginInfo>.Failure(new ErrorDetail(ErrorType.Unexpected, "Some unexpected issue occured, please try again later."));
        }
    }   
}
