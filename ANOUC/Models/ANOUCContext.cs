using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ANOUC.Models
{
  public class ANOUCContext : IdentityDbContext
  {
    public ANOUCContext() : base("DefaultConnection") {}

    public static ANOUCContext Create() => new ANOUCContext();
  }
}

