using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Annoucement/Edit/5
    [HttpPost]
      public ActionResult Edit(int id, FormCollection collection)
      {
        try
        {
          // TODO: Add update logic here

          return RedirectToAction("Index");
        }
        catch
        {
          return View();
        }
      }

    // GET: Annoucement/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Annoucement/Delete/5
    [HttpPost]
      public ActionResult Delete(int id, FormCollection collection)
      {
        try
        {
          // TODO: Add delete logic here

          return RedirectToAction("Index");
        }
        catch
        {
          return View();
        }
      }
  }
}
