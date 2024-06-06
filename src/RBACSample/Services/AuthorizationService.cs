using RBACSample.Enums;
using RBACSample.Models;
using RBACSample.Repository;

namespace RBACSample.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepository _userRepository;
    private readonly Dictionary<UserRole, List<string>> _rolePermissions;

    public AuthorizationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _rolePermissions = new Dictionary<UserRole, List<string>>
        {
            {
                UserRole.OPERATOR,
                new List<string>
                {
                    "Income",
                    "Expense",
                    "Labour"
                }
            },
            {
                UserRole.ENGINEER,
                new List<string>
                {
                    "Income",
                    "Expense",
                    "Report",
                    "Client",
                    "Labour"
                }
            },
            {
                UserRole.ADMIN,
                new List<string>
                {
                    "Income",
                    "Expense",
                    "Report",
                    "Client",
                    "Invoice",
                    "Labour"
                }
            }
        };
    }

    public async Task<bool> AuthorizeUser(string username, string resource)
    {
        var user = await _userRepository.GetUserByUsername(username);
        if (user == null)
        {
            return false;
        }

        var newUser = new User
        {
            Name = username,
            Role = user.Type switch
            {
                "operator" => UserRole.OPERATOR,
                "engineer" => UserRole.ENGINEER,
                "admin" => UserRole.ADMIN,
                "super" => UserRole.SUPERENGINEER,
            }
        };

        if (_rolePermissions.TryGetValue(newUser.Role, out var allowedActions))
        {
            return allowedActions.Contains(resource);
        }

        return false;
    }
}