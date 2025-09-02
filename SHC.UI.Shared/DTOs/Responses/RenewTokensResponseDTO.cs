using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.DTOs.Responses;

public class RenewTokensResponseDTO
{
    public AccessTokenDTO AccessToken { get; set; }
    public RefreshTokenDTO RefreshToken { get; set; }
    public RenewTokensResponseDTO(AccessTokenDTO accessToken, RefreshTokenDTO refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}
