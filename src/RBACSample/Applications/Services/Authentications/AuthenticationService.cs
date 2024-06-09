using RBACSample.Domains.Dtos;
using RBACSample.Infrastructures.Repository;
using RBACSample.Shared.Helpers;

namespace RBACSample.Applications.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> VerifyUser(UserDto request)
    {
        var user = await _userRepository.GetUserByUsername(request.Username);
        if (user == null)
        {
            return false;
        }

        return PasswordHasher.VerifyPassword(request.PasswordHash, user.PasswordHash);
    }
}