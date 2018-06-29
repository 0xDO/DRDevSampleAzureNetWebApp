using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DRDevSampleAzureNetWebApp.Models;

namespace DRDevSampleAzureNetWebApp.Controllers
{
  /// <summary>
  /// The Planet controller
  /// </summary>
  /// <seealso cref="System.Web.Mvc.Controller" />
  public class PlanetController : Controller {
    private readonly IPlanetRepository repository;

    public PlanetController(IPlanetRepository repository) {
      this.repository = repository;
    }

    // GET: Planets
    public ActionResult Index() {
      return View(repository.Planets.ToList());
    }

    // GET: Planets/Details/5
    public ActionResult Details(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var planetDetails = repository.GetPlanet(id);
      if (planetDetails == null) {
        return HttpNotFound();
      }
      return View(planetDetails);
    }

    // GET: Planets/Create
    public ActionResult Create() {
      return View();
    }

    // POST: Planets/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Name,DistanceToSun,Comment")] PlanetDetails planetDetails) {
      if (ModelState.IsValid) {
        repository.InsertOrUpdate(planetDetails);
        repository.Save();
        return RedirectToAction("Index");
      }

      return View(planetDetails);
    }

    // GET: Planets/Edit/5
    public ActionResult Edit(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      PlanetDetails planetDetails = repository.GetPlanet(id);
      if (planetDetails == null) {
        return HttpNotFound();
      }
      return View(planetDetails);
    }

    // POST: Planets/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Name,DistanceToSun,Comment")] PlanetDetails planetDetails) {
      if (ModelState.IsValid) {
        repository.InsertOrUpdate(planetDetails);
        repository.Save();
        return RedirectToAction("Index");
      }
      return View(planetDetails);
    }

    // GET: Planets/Delete/5
    public ActionResult Delete(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var planetDetails = repository.GetPlanet(id);
      if (planetDetails == null) {
        return HttpNotFound();
      }
      return View(planetDetails);
    }

    // POST: Planets/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id) {
      repository.Delete(id);
      repository.Save();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing) {
      if (disposing) {
        repository.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
