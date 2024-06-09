using RBACSample.Domains.Dtos;

namespace RBACSample.Applications.Services;

public interface IUserSessionService
{
    void SetCurrentUser(UserDto user);

    UserDto GetCurrentUser();

    void ClearCurrentUser();
}