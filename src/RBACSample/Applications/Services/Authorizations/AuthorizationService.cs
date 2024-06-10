using RBACSample.Domains.Dtos;
using RBACSample.Domains.Enums;
using RBACSample.Infrastructures.Repository;

namespace RBACSample.Applications.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepository _userRepository;
    private readonly Dictionary<UserRole, List<string>> _rolePermissions;

    public AuthorizationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> AuthorizeUser(UserResouceDto request)
    {
        var user = await _userRepository.GetUserWithRoleAndResourcesByUsername(request.Username);
        if (user == null)
        {
            return false;
        }

        var newUser = new UserDto
        {
            Username = request.Username,
            Role = user.RoleId switch
            {
                1 => UserRole.OPERATOR,
                2 => UserRole.ENGINEER,
                3 => UserRole.ADMIN,
                4 => UserRole.SUPERENGINEER,
            }
        };

        return user.Role.RoleResources.Any(x => x.Resource.Name == request.Resource);
    }
}