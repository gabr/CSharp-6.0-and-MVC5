using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Infrastructure;

namespace ANOUC.Data
{
  public interface IANOUCContext
  {
    DbSet<Category> Categories { get; set; }
    DbSet<Annoucement> Annoucements { get; set; }
    DbSet<AnnoucementCategory> AnnoucementCategory { get; set; }
    DbSet<User> Users { get; set; }

    DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    int SaveChanges();
    void Dispose();
  }
}

