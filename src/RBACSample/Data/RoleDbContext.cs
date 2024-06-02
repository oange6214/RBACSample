using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RBACSample.Entities;

namespace RBACSample.Data;

public partial class RoleDbContext : DbContext
{
    public RoleDbContext()
    {
    }

    public RoleDbContext(DbContextOptions<RoleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbLoginrole> TbLoginroles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbLoginrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tb_loginrole_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
        });
    }
}