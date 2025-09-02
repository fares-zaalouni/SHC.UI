
namespace SHC.UI.Shared.Session;

public class Session : IReadOnlySession
{
    public Guid UserId { get; set; }
    public string UserPhoneNumber { get; set; }
    public string AccessToken { get; set; }
    public DateTime Expiration { get; set; }
    public DateTime LastRefresh { get; set; }
    public bool IsActive { get; set; }   

    public Session(Guid userId,string userPhoneNumber, string accessToken, DateTime expiration)
    {
        UserId = userId;
        AccessToken = accessToken;
        Expiration = expiration;
        LastRefresh = DateTime.UtcNow;
        IsActive = true;
        UserPhoneNumber = userPhoneNumber;
    }
}
