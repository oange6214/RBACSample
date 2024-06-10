using RBACSample.Domains.Dtos;
using RBACSample.Domains.Entities;
using RBACSample.Infrastructures.Repository;
using RBACSample.Shared.Helpers;

namespace RBACSample.Applications.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> RegisterUser(UserDto request)
    {
        if (string.IsNullOrEmpty(request.Username) || request.PasswordHash.Length == 0)
        {
            throw new ArgumentException("Username and password cannot be empty.");
        }

        var user = await _userRepository.GetUserByUsername(request.Username);
        if (user != null)
        {
            return false;
        }

        await _userRepository.CreateUser(new UserEntity
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = PasswordHasher.HashPassword(request.PasswordHash),
            RoleId = (int)request.Role
        });

        return true;
    }
}