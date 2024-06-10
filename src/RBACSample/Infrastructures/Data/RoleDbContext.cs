using RBACSample.Domains.Entities;

namespace RBACSample.Infrastructures.Data;

public partial class RoleDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ResourceEntity> Resources { get; set; }
    public DbSet<RoleResourceEntity> RoleResources { get; set; }

    public RoleDbContext(DbContextOptions<RoleDbContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 配置 UserEntity
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasOne(e => e.Role)
                  .WithMany(r => r.Users)
                  .HasForeignKey(e => e.RoleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // 配置 RoleEntity
        modelBuilder.Entity<RoleEntity>(entity =>
        {
            entity.HasMany(r => r.RoleResources)
                  .WithOne(rr => rr.Role)
                  .HasForeignKey(rr => rr.RoleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // 配置 ResourceEntity
        modelBuilder.Entity<ResourceEntity>(entity =>
        {
            entity.HasMany(r => r.RoleResources)
                  .WithOne(rr => rr.Resource)
                  .HasForeignKey(rr => rr.ResourceId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // 配置 RoleResourceEntity
        modelBuilder.Entity<RoleResourceEntity>(entity =>
        {
            entity.HasKey(rr => rr.Id);
            entity.HasOne(rr => rr.Role)
                  .WithMany(r => r.RoleResources)
                  .HasForeignKey(rr => rr.RoleId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(rr => rr.Resource)
                  .WithMany(r => r.RoleResources)
                  .HasForeignKey(rr => rr.ResourceId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}