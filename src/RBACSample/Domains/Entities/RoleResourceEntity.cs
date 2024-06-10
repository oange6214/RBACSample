using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RBACSample.Domains.Entities;

[Table("role_resources")]
public partial class RoleResourceEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; } = default!;

    [ForeignKey(nameof(RoleId))]
    public RoleEntity Role { get; set; } = default!;

    [Column("resource_id")]
    public int ResourceId { get; set; } = default!;

    [ForeignKey(nameof(ResourceId))]
    public ResourceEntity Resource { get; set; } = default!;
}