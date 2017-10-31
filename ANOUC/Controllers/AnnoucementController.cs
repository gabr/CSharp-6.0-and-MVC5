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
    private IANOUCDataManager _db;

    public AnnoucementController() { }

    public AnnoucementController(IANOUCDataManager dataManager)
    {
      _db = dataManager;
    }

    // GET: Annoucement
    public ActionResult Index()
    {
      return View(_db.GetAnnoucements());
    }

    // GET: Annoucement
    public ActionResult Partial()
    {
      return PartialView("Index", _db.GetAnnoucements());
    }

    // GET: Annoucement/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      Annoucement annoucement = _db.GetAnnoucement(id.Value);
      if (annoucement == null)
        return HttpNotFound();

      return View(annoucement);
    }

    // GET: Annoucement/Create
    public ActionResult Create()
    {
      ViewBag.UsersIds = new SelectList(_db.GetUsers(), "Id", "FullName");
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
        if (_db.AddAnnoucement(newAnnoucement))
          return RedirectToAction("Index");
        else
          throw new Exception("Error while saving Annoucement: " + newAnnoucement);
      }

      ViewBag.UsersIds = new SelectList(_db.GetUsers(), "Id", "FullName");
      return View(newAnnoucement);
    }

    // GET: Annoucement/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      Annoucement annoucement = _db.GetAnnoucement(id.Value);
      if (annoucement == null)
        return HttpNotFound();

      ViewBag.UsersIds = new SelectList(_db.GetUsers(), "Id", "FullName");
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
        if (_db.SaveAnnoucementChanges(editedAnnoucement))
          return RedirectToAction("Index");
        else
          throw new Exception("Error while saving changes in Annoucement: " + editedAnnoucement);
      }

      ViewBag.UsersIds = new SelectList(_db.GetUsers(), "Id", "FullName");
      return View(editedAnnoucement);
    }

    // GET: Annoucement/Delete/5
    public ActionResult Delete(int? id, bool? error)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      Annoucement annoucement = _db.GetAnnoucement(id.Value);
      if (annoucement == null)
        return HttpNotFound();

      if (error.HasValue && error.Value == true)
        ViewBag.Error = true;

      return View(annoucement);
    }

    // POST: Annoucement/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int? id)
    {
      try
      {
        if (id == null)
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        Annoucement annoucement = _db.GetAnnoucement(id.Value);
        if (annoucement == null)
          return HttpNotFound();

        if (_db.RemoveAnnoucement(annoucement))
          return RedirectToAction("Index");
        else
          throw new Exception("Error while removing Annoucement: " + annoucement);
      }
      catch(Exception)
      {
        return RedirectToAction("Delete", new { id = id, error = true });
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        _db?.Dispose();
      base.Dispose(disposing);
    }
  }
}
