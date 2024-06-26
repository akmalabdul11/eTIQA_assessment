using System.Reflection.Emit;
using EFreelancer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFreelancer.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityUser<int>>().ToTable("UserLogins").Property(p => p.Id).HasColumnName("UserId");
        builder.Entity<IdentityRole<int>>().ToTable("UserRoleTypes").Property(rt => rt.Id).HasColumnName("UserRoleTypeId");
        builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").Property(p => p.UserId).HasColumnName("UserId");
        builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims").Property(p => p.Id).HasColumnName("UserClaimId");
        builder.Entity<IdentityRoleClaim<int>>().ToTable("UserRoleClaims").Property(p => p.Id).HasColumnName("UserRoleClaimId");
        builder.Entity<IdentityUserLogin<int>>().ToTable("User3rdPartyLogin").Property(p => p.UserId).HasColumnName("UserId");
        builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").Property(p => p.UserId).HasColumnName("UserId");

        builder.Entity<Freelancers>()
       .HasKey(f => f.FreelancerId);

        builder.Entity<Freelancers>()
        .Property(f => f.FreelancerId)
        .ValueGeneratedOnAdd(); // Ensure the FreelancerId is auto-generated


    }

    public DbSet<AdminStaffs> AdminStaffs { get; set; }
    public DbSet<Freelancers> Freelancers { get; set; }
    public DbSet<Exceptions> Exceptions { get; set; }

}