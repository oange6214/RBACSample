﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RBACSample.Domains.Entities;

[Table("roles")]
public partial class RoleEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = default!;

    [Column("description")]
    [StringLength(500)]
    public string? Description { get; set; } = default!;

    public ICollection<UserEntity> Users { get; set; } = [];

    public ICollection<RoleResourceEntity> RoleResources { get; set; } = [];
}