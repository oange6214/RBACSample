using RBACSample.Domains.Dtos;

namespace RBACSample.Applications.Services;

public interface IUserService
{
    Task<bool> RegisterUser(UserDto user);
}