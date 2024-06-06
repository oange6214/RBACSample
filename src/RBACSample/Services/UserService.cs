using RBACSample.Entities;
using RBACSample.Helper;
using RBACSample.Models;
using RBACSample.Repository;
using System.Security;

namespace RBACSample.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Name) || user.Password.Length == 0)
        {
            throw new ArgumentException("Username and password cannot be empty.");
        }

        var newUser = await _userRepository.GetUserByUsername(user.Name);
        if (newUser != null)
        {
            return false;
        }

        await _userRepository.CreateUser(new TbLoginrole
        {
            Username = user.Name,
            PasswordHash = PasswordHasher.HashPassword(user.Password)
        });

        return true;
    }
}