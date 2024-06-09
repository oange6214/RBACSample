using RBACSample.Domains.Dtos;

namespace RBACSample.Applications.Services;

public class UserSessionService : IUserSessionService
{
    private UserDto _currentUser = null!;

    public void SetCurrentUser(UserDto user)
    {
        _currentUser = user;
    }

    public UserDto GetCurrentUser()
    {
        return _currentUser;
    }

    public void ClearCurrentUser()
    {
        _currentUser = new UserDto();
    }
}