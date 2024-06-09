using RBACSample.Domains.Dtos;

namespace RBACSample.Applications.Services;

public interface IAuthenticationService
{
    Task<bool> VerifyUser(UserDto user);
}