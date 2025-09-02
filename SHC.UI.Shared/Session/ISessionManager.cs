

namespace SHC.UI.Shared.Session;

public interface ISessionManager
{
    void StartSession(Guid userId, string userPhoneNumber, string accessToken, DateTime expiration);
    void RefreshSession(string accessToken, DateTime expiration);
    void EndSession();
    bool IsSessionExpired();
    IReadOnlySession GetCurrentSession();
    void ClearSession();
}
