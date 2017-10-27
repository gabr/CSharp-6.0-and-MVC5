using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ANOUC.Models
{
  public class User// : IUser
  {
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "User name")]
    public string Name { get; set; }

    public User() {}
  }
}
