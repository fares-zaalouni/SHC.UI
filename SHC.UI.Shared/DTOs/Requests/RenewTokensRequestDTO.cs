using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.DTOs.Requests;

public record RenewTokensRequestDTO(
    Guid UserId,
    Guid DeviceId,
    string PhoneNumber,
    string RefreshToken
);
