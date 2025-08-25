using SHC.UI.Shared.Common;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.Shared.DTOs.Responses;
using SHC.UI.Shared.Models.Records;
using SHC.UI.Shared.Settings;


namespace SHC.UI.Shared.Services;

public class UserService
{
    private readonly HttpService _httpService;
    private readonly ApiSettings _apiSettings;
    private readonly ILocalSettingsManager _localSettingsManager;

    public UserService(
        HttpService httpService,
        ILocalSettingsManager localSettingsManager
        )
    {
        _httpService = httpService;
        _apiSettings = ConfigProvider.ApiSettings;
        _localSettingsManager = localSettingsManager;
    }
    public async Task<Result<LoginInfo>> LoginAsync(string phoneNumber, string password)
    {
        //The id should be generated first time the app runs and stored in local settings
        LocalSettings localSettings = _localSettingsManager.GetSettings()!;
        LoginRequestDTO loginRequest = new(phoneNumber, password, "Patient", localSettings.DeviceId);
        try
        {
            HttpResponse<LoginResponseDTO?> result = await _httpService.PostAsync<LoginResponseDTO>(_apiSettings.LoginEndpoint, loginRequest);
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
