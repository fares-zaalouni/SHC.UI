using SHC.UI.Shared.Common;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.Shared.DTOs.Responses;
using SHC.UI.Shared.Models.Records;
using SHC.UI.Shared.Security;
using System.Text;
using System.Text.Json;


namespace SHC.UI.Shared.Services
{
    public class PatientService : IPatientService
    {
        private IAuthenticatedApiClient _authenticatedApiClient;
        private readonly ApiSettings _apiSettings;

        public PatientService(IAuthenticatedApiClient authenticatedApiClient)
        {
            _authenticatedApiClient = authenticatedApiClient;
            _apiSettings = ConfigProvider.ApiSettings;
        }

        public async Task<Result<RegisterPatientResponseDTO>> RegisterPatient(RegisterPatientRequestDTO registerPatientDTO)
        {
            var result = await _authenticatedApiClient.PostAsync<RegisterPatientResponseDTO>(_apiSettings.RegisterPatientEndpoint, registerPatientDTO);
            return result.StatusCode switch
            {
                System.Net.HttpStatusCode.OK => Result<RegisterPatientResponseDTO>.Success(result.Content!),
                System.Net.HttpStatusCode.InternalServerError => Result<RegisterPatientResponseDTO>.Failure(new ErrorDetail(ErrorType.Server, "Server Issue.")),
                System.Net.HttpStatusCode.Unauthorized => Result<RegisterPatientResponseDTO>.Failure(new ErrorDetail(ErrorType.Unauthorized, "Session Expired, redirectin to login")),
                _ => Result<RegisterPatientResponseDTO>.Failure(new ErrorDetail(ErrorType.Unexpected, "Some unexpected issue occured, please try again later."))
            };
        }
    }
}
