using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ANOUC.Data.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<ANOUC.Data.ANOUCContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
      AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(ANOUC.Data.ANOUCContext context)
    {
      SeedRoles();
      SeedUsers();
      SeedAnnoucements();
      SeedCategories();
      SeedAnnoucementsCategories();

      void SeedRoles()
      {
        var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(
          new RoleStore<IdentityRole>());

        if (!roleManager.RoleExists("Admin"))
        {
          var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
          {
            Name = "Admin"
          };

          roleManager.Create(role);
        }
      }

      void SeedUsers()
      {
        var store = new UserStore<User>(context);
        var manager = new UserManager<User>(store);

        if (!context.Users.Any(u => u.UserName == "Admin"))
        {
          var user = new User() { UserName = "Admin" };
          var adminresult = manager.Create(user, "123456");

          if (adminresult.Succeeded)
            manager.AddToRole(user.Id, "Admin");
        }
      }

      void SeedAnnoucements()
      {
        string idUser = context.Set<User>()
          .Where(u => u.UserName == "Admin")
          .FirstOrDefault().Id;

        for (int i = 1; i <= 10; i++)
        {
          var ann = new Annoucement()
          {
            Id = i,
            UserId = idUser,
            Content = $"Annoucement content: {i}",
            Title = $"Annoucement title: {i}",
            AddedDate = DateTime.Now
          };

          context.Set<Annoucement>().AddOrUpdate(ann);
        }

        context.SaveChanges();
      }

      void SeedCategories()
      {
        for (int i = 1; i <= 10; i++)
        {
          var cat = new Category()
          {
            Id = i,
            Name = $"Category {i}",
            Content = $"Category content {i}",
            ParentId = 1,
            MetaTitle = $"Category title {i}",
            MetaDescription = $"Category description {i}",
            MetaWords = $"Category keywords {i}"
          };

          context.Set<Category>().AddOrUpdate(cat);
        }

        context.SaveChanges();
      }

      void SeedAnnoucementsCategories()
      {
        var annoucements = context.Set<Annoucement>().Take(10).ToArray();
        var categories = context.Set<Category>().Take(10).ToArray();

        for (int i = 0; i < 10; i++)
        {
          var atoc = new AnnoucementCategory()
          {
            Id = i + 1,
            AnnoucementId = annoucements[i].Id,
            CategoryId = categories[i].Id
          };

          context.Set<AnnoucementCategory>().AddOrUpdate(atoc);
        }

        context.SaveChanges();
      }
    }
  }
}
