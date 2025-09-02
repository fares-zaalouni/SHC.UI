using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHC.UI.Shared.Session;

public class SessionManager : ISessionManager
{
    private Session? _currentSession;

    public void StartSession(Guid userId,string userPhoneNumber, string accessToken, DateTime expiration)
    {
        _currentSession = new Session(userId, userPhoneNumber, accessToken, expiration);
    }
    public void EndSession()
    {
        if(_currentSession == null || !_currentSession.IsActive)
        {
            throw new InvalidOperationException("No active session to end.");
        }
        _currentSession.IsActive = false;
    }

    public bool IsSessionExpired()
    {
        if (_currentSession == null)
            return true;

        return DateTime.UtcNow >= _currentSession.Expiration || !_currentSession.IsActive;
    }

    public void RefreshSession(string accessToken, DateTime expiration)
    {
        if (_currentSession == null || !_currentSession.IsActive)
        {
            throw new InvalidOperationException("No active session to refresh.");
        }

        _currentSession.AccessToken = accessToken;
        _currentSession.Expiration = expiration;
        _currentSession.LastRefresh = DateTime.UtcNow;
    }

    public IReadOnlySession GetCurrentSession()
    {
        if (_currentSession == null)
        {
            throw new InvalidOperationException("No active session.");
        }
        return _currentSession;
    }

    public void ClearSession()
    {
        _currentSession = null;
    }

}
