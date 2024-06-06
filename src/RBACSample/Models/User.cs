using RBACSample.Enums;
using System.Security;

namespace RBACSample.Models;

public class User
{
    public string Name { get; set; } = string.Empty;
    public SecureString Password { get; set; }
    public UserRole Role { get; set; }
}