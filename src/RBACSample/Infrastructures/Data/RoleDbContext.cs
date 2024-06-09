using RBACSample.Domains.Entities;

namespace RBACSample.Infrastructures.Data;

public partial class RoleDbContext : DbContext
{
    public RoleDbContext(DbContextOptions<RoleDbContext> options)
            : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ResourceEntity> Resources { get; set; }
}