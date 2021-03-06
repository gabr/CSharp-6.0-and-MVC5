using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ANOUC.Data
{
  public class AnnoucementCategory
  {
    public int Id { get; set; }

    public int AnnoucementId { get; set; }
    public Annoucement Annoucement { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public AnnoucementCategory() {}
  }
}
