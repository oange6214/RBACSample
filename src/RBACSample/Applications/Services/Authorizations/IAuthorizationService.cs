using RBACSample.Domains.Dtos;

namespace RBACSample.Applications.Services;

public interface IAuthorizationService
{
    Task<bool> AuthorizeUser(UserResouceDto request);
}