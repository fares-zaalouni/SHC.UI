using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.DTOs.Responses;

public record LoginResponseDTO
{
    public AccessTokenDTO AccessToken { get; set; }
    public RefreshTokenDTO RefreshToken { get; set; }
    public Guid UserId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public LoginResponseDTO(Guid userId, string firstName, string lastName, AccessTokenDTO accessToken, RefreshTokenDTO refreshToken)
    {
        UserId = userId;
        Firstname = firstName;
        Lastname = lastName;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}
