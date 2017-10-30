using System;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ANOUC.Data
{
  public interface IANOUCDataManager
  {
    IEnumerable<Annoucement> GetAnnoucements(bool noTracking = true);
    Annoucement GetAnnoucement(int id);
    bool SaveAnnoucementChanges(Annoucement editedAnnoucement);
    bool AddAnnoucement(Annoucement newAnnoucement);
    bool RemoveAnnoucement(Annoucement annoucementToRemove);
    IEnumerable<IdentityUser> GetUsers(bool noTracking = true);
    void Dispose();
  }
}
