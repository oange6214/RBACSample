using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RBACSample.Domains.Entities;

[Table("resources")]
public partial class ResourceEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = default!;

    [Column("url")]
    [StringLength(255)]
    public string Url { get; set; } = default!;
}