using RBACSample.Domains.Enums;

namespace RBACSample.Domains.Dtos;

public class UserDto
{
    public string Username { get; set; } = default!;
    public SecureString PasswordHash { get; set; } = default!;
    public UserRole Role { get; set; } = default!;
    public string Email { get; set; } = default!;
}