using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DRDevSampleAzureNetWebApp.Models;

namespace DRDevSampleAzureNetWebApp.Controllers
{
    public class PlanetControllerAsync : Controller
    {
        private DRDBContext db = new DRDBContext();

        // GET: Planet
        public async Task<ActionResult> Index()
        {
            return View(await db.Planets.ToListAsync());
        }

        // GET: Planet/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanetDetails planetDetails = await db.Planets.FindAsync(id);
            if (planetDetails == null)
            {
                return HttpNotFound();
            }
            return View(planetDetails);
        }

        // GET: Planet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,AstronomicalSymbol,DistanceToSun,EquatorialRadius,EquatorialGravity,Comment")] PlanetDetails planetDetails)
        {
            if (ModelState.IsValid)
            {
                db.Planets.Add(planetDetails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(planetDetails);
        }

        // GET: Planet/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanetDetails planetDetails = await db.Planets.FindAsync(id);
            if (planetDetails == null)
            {
                return HttpNotFound();
            }
            return View(planetDetails);
        }

        // POST: Planet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,AstronomicalSymbol,DistanceToSun,EquatorialRadius,EquatorialGravity,Comment")] PlanetDetails planetDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planetDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(planetDetails);
        }

        // GET: Planet/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanetDetails planetDetails = await db.Planets.FindAsync(id);
            if (planetDetails == null)
            {
                return HttpNotFound();
            }
            return View(planetDetails);
        }

        // POST: Planet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PlanetDetails planetDetails = await db.Planets.FindAsync(id);
            db.Planets.Remove(planetDetails);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
