using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ANOUC.Data;

namespace ANOUC.Controllers
{
  public class AnnoucementController : Controller
  {
    private ANOUCContext _db = new ANOUCContext();

    // GET: Annoucement
    public ActionResult Index()
    {
      var annoucement = _db.Annoucements.AsEnumerable();
      return View(annoucement);
    }

    // GET: Annoucement/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      Annoucement annoucement = _db.Annoucements.Find(id);
      if (annoucement == null)
      {
        return HttpNotFound();
      }

      return View(annoucement);
    }

    // GET: Annoucement/Create
    public ActionResult Create()
    {
      ViewBag.UsersIds = new SelectList(_db.Users, "Id", "FullName");
      return View();
    }

    // POST: Annoucement/Create
    [HttpPost]
    public ActionResult Create(
      [Bind(Include="Id,Content,Title,AddedDate,UserId")]
      Annoucement newAnnoucement)
    {
      if (ModelState.IsValid)
      {
        _db.Annoucements.Add(newAnnoucement);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.UsersIds = new SelectList(_db.Users, "Id", "FullName");
      return View(newAnnoucement);
    }

    // GET: Annoucement/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      Annoucement annoucement = _db.Annoucements.Find(id);
      if (annoucement == null)
      {
        return HttpNotFound();
      }

      ViewBag.UsersIds = new SelectList(_db.Users, "Id", "FullName");
      return View(annoucement);
    }

    // POST: Annoucement/Edit/5
    [HttpPost]
    public ActionResult Edit(
      [Bind(Include="Id,Content,Title,AddedDate,UserId")]
      Annoucement editedAnnoucement)
    {
      if (ModelState.IsValid)
      {
        _db.Entry(editedAnnoucement).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.UsersIds = new SelectList(_db.Users, "Id", "FullName");
      return View(editedAnnoucement);
    }

    // GET: Annoucement/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      Annoucement annoucement = _db.Annoucements.Find(id);
      if (annoucement == null)
        return HttpNotFound();

      return View(annoucement);
    }

    // POST: Annoucement/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      Annoucement annoucement = _db.Annoucements.Find(id);
      if (annoucement == null)
        return HttpNotFound();

      _db.Annoucements.Remove(annoucement);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        _db.Dispose();
      base.Dispose(disposing);
    }
  }
}
