using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ANOUC.Models
{
  public class Annoucement
  {
    [Display(Name = "Id")] // using System.ComponentModel.DataAnnotations;
    public int Id { get; set; }

    [Display(Name = "Annoucement content")]
    [MaxLength(500)]
    public string Content { get; set; }

    [Display(Name = "Annoucement title")]
    [MaxLength(72)]
    public string Title { get; set; }

    [Display(Name = "Added time")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime AddedDate { get; set; }

    public string UserId { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<AnnoucementCategory> AnnoucementCategory { get; set; }
      = new HashSet<AnnoucementCategory>();

    public Annoucement() {}
  }
}
