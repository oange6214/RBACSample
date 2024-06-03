using System.Security;

namespace RBACSample.Services;

public interface IUserService
{
    Task<bool> RegisterUser(string username, SecureString password);

    Task<bool> VerifyUser(string username, SecureString password);
}