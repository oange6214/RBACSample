using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RBACSample.Domains.Entities;

[Table("users")]
public partial class UserEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = default!;

    [Column("password_hash")]
    [StringLength(128)]
    public string PasswordHash { get; set; } = default!;

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = default!;

    [Column("role_id")]
    public int RoldId { get; set; } = default!;

    public RoleEntity Role { get; set; } = default!;
}