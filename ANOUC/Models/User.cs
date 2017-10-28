using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ANOUC.Models
{
  public class User : IdentityUser
  {
    [Display(Name = "User name")]
    public string Name { get; set; }

    [Display(Name = "User surname")]
    public string Surname { get; set; }

    [NotMapped]
    [Display(Name = "Mr/Mrs")]
    public string FullName { get { return $"{Name} {Surname}"; } }

    public virtual ICollection<Annoucement> Annoucements { get; private set; }
      = new HashSet<Annoucement>();

    public User() {}

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
    {
      var userIdentity = await manager.CreateIdentityAsync(this,
        DefaultAuthenticationTypes.ApplicationCookie);

      // Add custom user claims here
      return userIdentity;
    }
  }
}
