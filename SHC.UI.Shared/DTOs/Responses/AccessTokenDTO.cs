using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.DTOs.Responses;

public record AccessTokenDTO
{
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
}
