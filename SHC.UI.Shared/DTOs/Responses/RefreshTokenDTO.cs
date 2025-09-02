using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.DTOs.Responses;

public class RefreshTokenDTO
{
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
}
