

using SHC.UI.Shared.Common;
using SHC.UI.Shared.DTOs.Requests;
using SHC.UI.Shared.DTOs.Responses;

namespace SHC.UI.Shared.Services;

public interface IPatientService
{
    Task<Result<RegisterPatientResponseDTO>> RegisterPatient(RegisterPatientRequestDTO registerPatientDTO);

}
