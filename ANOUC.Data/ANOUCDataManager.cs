using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ANOUC.Data
{
  public class ANOUCDataManager : IANOUCDataManager
  {
    private IANOUCContext _db;

    public ANOUCDataManager(IANOUCContext dbContext)
    {
      if (dbContext == null)
        throw new ArgumentNullException(nameof(dbContext));

      _db = dbContext;
    }

    public IEnumerable<Annoucement> GetAnnoucements(bool noTracking = true)
    {
      if (noTracking)
        return _db.Annoucements.AsNoTracking().AsEnumerable();

      return _db.Annoucements.AsEnumerable();
    }

    public Annoucement GetAnnoucement(int id)
    {
      return _db.Annoucements.Find(id);
    }

    public bool SaveAnnoucementChanges(Annoucement editedAnnoucement)
    {
      _db.Entry(editedAnnoucement).State = EntityState.Modified;
      return _db.SaveChanges() > 0;
    }

    public bool AddAnnoucement(Annoucement newAnnoucement)
    {
      if (newAnnoucement == null)
        throw new ArgumentNullException(nameof(newAnnoucement));

      _db.Annoucements.Add(newAnnoucement);
      return _db.SaveChanges() > 0;
    }

    public bool RemoveAnnoucement(Annoucement annoucementToRemove)
    {
      foreach (var atoc in _db.AnnoucementCategory.Where(ac => ac.Annoucement.Id == annoucementToRemove.Id))
        _db.AnnoucementCategory.Remove(atoc);
      _db.Annoucements.Remove(annoucementToRemove);
      return _db.SaveChanges() > 0;
    }

    public IEnumerable<IdentityUser> GetUsers(bool noTracking = true)
    {
      if (noTracking)
        return _db.Users.AsNoTracking().AsEnumerable();

      return _db.Users.AsEnumerable();
    }

    public void Dispose()
    {
      _db.Dispose();
    }
  }
}

