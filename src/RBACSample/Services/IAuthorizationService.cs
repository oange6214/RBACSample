namespace RBACSample.Services;

public interface IAuthorizationService
{
    Task<bool> AuthorizeUser(string username, string resource);
}