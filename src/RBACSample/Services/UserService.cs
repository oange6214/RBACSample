using RBACSample.Entities;
using RBACSample.Helper;
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

    public async Task<bool> RegisterUser(string username, SecureString password)
    {
        if (string.IsNullOrEmpty(username) || password.Length == 0)
        {
            throw new ArgumentException("Username and password cannot be empty.");
        }

        var user = await _userRepository.GetUserByUsername(username);
        if (user != null)
        {
            return false; // User already exists
        }

        var hashedPassword = PasswordHasher.HashPassword(password);
        await _userRepository.CreateUser(new TbLoginrole
        {
            Username = username,
            PasswordHash = hashedPassword
        });

        return true; // User registered successfully
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