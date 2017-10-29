using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ANOUC.Models
{
  public class ANOUCContext : IdentityDbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Annoucement> Annoucements { get; set; }
    public DbSet<AnnoucementCategory> AnnoucementCategory { get; set; }
    //public DbSet<User> Users { get; set; }

    public ANOUCContext() : base("DefaultConnection") {}

    public static ANOUCContext Create() => new ANOUCContext();

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // disable pluralizing convention
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      // disable cascade delete
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

      // create connections between tables
      modelBuilder.Entity<Annoucement>()
        .HasRequired(x => x.User)
        .WithMany(x => x.Annoucements)
        .HasForeignKey(x => x.UserId)
        .WillCascadeOnDelete(true);
    }
  }
}

