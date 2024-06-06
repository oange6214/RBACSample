using RBACSample.Models;

namespace RBACSample.Services;

public class UserSessionService : IUserSessionService
{
    private User _currentUser = null!;

    public void SetCurrentUser(User user)
    {
        _currentUser = user;
    }

    public User GetCurrentUser()
    {
        return _currentUser;
    }

    public void ClearCurrentUser()
    {
        _currentUser = null;
    }
}