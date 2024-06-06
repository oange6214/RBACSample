using RBACSample.Helper;
using RBACSample.Repository;
using System.Security;

namespace RBACSample.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> VerifyUser(string username, SecureString password)
    {
        var user = await _userRepository.GetUserByUsername(username);
        if (user == null)
        {
            return false; // User does not exist
        }

        return PasswordHasher.VerifyPassword(password, user.PasswordHash);
    }
}