using RBACSample.Models;

namespace RBACSample.Services;

public interface IUserService
{
    Task<bool> RegisterUser(User user);
}