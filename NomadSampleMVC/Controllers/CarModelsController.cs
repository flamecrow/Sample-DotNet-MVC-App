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
    public class CarModelsController : Controller
    {
        private CarContext db = new CarContext();

        // GET: CarModels
        public ActionResult Index()
        {
            var carModels = db.CarModels.Include(c => c.CarMake).Include(c => c.CarType);
            return View(carModels.ToList());
        }

        // GET: CarModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {
            ViewBag.CarMakeID = new SelectList(db.CarMakes, "CarMakeID", "Make");
            ViewBag.CarTypeID = new SelectList(db.CarTypes, "ID", "Type");
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarModelID,CarMakeID,CarTypeID,Model,Color")] CarModel carModel,
             HttpPostedFileBase upload)
        {
            if (upload == null)
            {
                ModelState.AddModelError("FileURL", "Please upload an image.");
            }

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {

                    //carImage.CarModel = carModel;
                    var entry = db.CarImages.FirstOrDefault(e => e.CarModelID == carModel.CarModelID);
                    if (entry != null)
                    {
                        entry.FileName = System.IO.Path.GetFileName(upload.FileName);
                        entry.ContentType = upload.ContentType;
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            entry.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        db.Entry(entry).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        var carImage = new CarImage
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            carImage.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        carImage.CarModel = carModel;
                        db.CarImages.Add(carImage);
                    }
                }
                db.CarModels.Add(carModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarMakeID = new SelectList(db.CarMakes, "CarMakeID", "Make", carModel.CarMakeID);
            ViewBag.CarTypeID = new SelectList(db.CarTypes, "ID", "Type", carModel.CarTypeID);
            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            CarImage carImage = db.CarImages.FirstOrDefault(s => s.CarModelID == carModel.CarModelID);
            if (carImage != null)
            {
                ViewBag.CarImage = carImage.FileName;
                ViewBag.CarImageBytes = carImage.Content;
                ViewBag.CarImageType = carImage.ContentType;
            }
            ViewBag.CarMakeID = new SelectList(db.CarMakes, "CarMakeID", "Make", carModel.CarMakeID);
            ViewBag.CarTypeID = new SelectList(db.CarTypes, "ID", "Type", carModel.CarTypeID);
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarModelID,CarMakeID,CarTypeID,Model,Color")] CarModel carModel,
             HttpPostedFileBase upload)
        {
            if (upload == null)
            {
                ModelState.AddModelError("FileURL", "Please upload an image.");
            }

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {

                    //carImage.CarModel = carModel;
                    var entry = db.CarImages.FirstOrDefault(e => e.CarModelID == carModel.CarModelID);
                    if (entry != null)
                    {
                        entry.FileName = System.IO.Path.GetFileName(upload.FileName);
                        entry.ContentType = upload.ContentType;
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            entry.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        db.Entry(entry).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        var carImage = new CarImage
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            carImage.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        carImage.CarModel = carModel;
                        db.CarImages.Add(carImage);
                    }
                }
                db.Entry(carModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarMakeID = new SelectList(db.CarMakes, "CarMakeID", "Make", carModel.CarMakeID);
            ViewBag.CarTypeID = new SelectList(db.CarTypes, "ID", "Type", carModel.CarTypeID);
            return View(carModel);
        }

        // GET: CarModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModel carModel = db.CarModels.Find(id);
            db.CarModels.Remove(carModel);
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
