using RBACSample.Entities;
using RBACSample.Models;

namespace RBACSample.Services;

public interface IUserSessionService
{
    void SetCurrentUser(User user);

    User GetCurrentUser();

    void ClearCurrentUser();
}