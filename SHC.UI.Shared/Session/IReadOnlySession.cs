using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Session;

public interface IReadOnlySession
{
    Guid UserId { get; }
    string AccessToken { get; }
    DateTime Expiration { get; }
    DateTime LastRefresh { get; }
    string UserPhoneNumber { get; }
    bool IsActive { get; }
}
