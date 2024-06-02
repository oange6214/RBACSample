using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RBACSample.Entities;

[Table("tb_loginrole")]
public partial class TbLoginrole
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(50)]
    public string PasswordHash { get; set; } = null!;

    [Column("type")]
    [StringLength(50)]
    public string Type { get; set; } = null!;
}