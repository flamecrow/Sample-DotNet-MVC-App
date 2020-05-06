using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NomadSampleMVC.DAL;
using NomadSampleMVC.Models;

namespace NomadSampleMVC.Controllers
{
    public class CarMakesController : Controller
    {
        private CarContext db = new CarContext();

        // GET: CarMakes
        public ActionResult Index()
        {
            return View(db.CarMakes.ToList());
        }

        // GET: CarMakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMake carMake = db.CarMakes.Find(id);
            if (carMake == null)
            {
                return HttpNotFound();
            }
            return View(carMake);
        }

        // GET: CarMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarMakeID,Name")] CarMake carMake)
        {
            if (ModelState.IsValid)
            {
                db.CarMakes.Add(carMake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carMake);
        }

        // GET: CarMakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMake carMake = db.CarMakes.Find(id);
            if (carMake == null)
            {
                return HttpNotFound();
            }
            return View(carMake);
        }

        // POST: CarMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarMakeID,Name")] CarMake carMake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carMake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carMake);
        }

        // GET: CarMakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMake carMake = db.CarMakes.Find(id);
            if (carMake == null)
            {
                return HttpNotFound();
            }
            return View(carMake);
        }

        // POST: CarMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarMake carMake = db.CarMakes.Find(id);
            db.CarMakes.Remove(carMake);
            db.SaveChanges();
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
