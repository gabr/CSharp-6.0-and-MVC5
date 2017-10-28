using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ANOUC.Models
{
  public class Category
  {
    [Display(Name = "Category Id")]
    public int Id { get; set; }

    [Display(Name = "Category name")]
    public string Name { get; set; }

    [Display(Name = "Parent Id")]
    public int ParentId { get; set; }

    #region SEO
    [Display(Name = "Google title")]
    [MaxLength(72)]
    public string MetaTitle { get; set; }

    [Display(Name = "Site description in Google")]
    [MaxLength(160)]
    public string MetaDescription { get; set; }

    [Display(Name = "Google keywords")]
    [MaxLength(160)]
    public string MetaWords { get; set; }

    [Display(Name = "Site content")]
    [MaxLength(500)]
    public string Content { get; set; }

    #endregion

    public virtual ICollection<AnnoucementCategory> AnnoucementCategory { get; set; }
      = new HashSet<AnnoucementCategory>();

    public Category() {}
  }
}
