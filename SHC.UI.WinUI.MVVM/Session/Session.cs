
namespace SHC.UI.WinUI.MVVM.Session;

public class Session
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
    public bool IsAuthenticated => !string.IsNullOrEmpty(AccessToken) && Expiration > DateTime.UtcNow;
    public void Clear()
    {
        AccessToken = null;
        Expiration = DateTime.MinValue;
    }
}
