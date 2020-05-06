using NomadSampleMVC.DAL;
using NomadSampleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;

namespace NomadSampleMVC.Controllers
{
    public class HomeController : Controller
    {
        private CarContext db = new CarContext();

        // GET: CarModels

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ModelSortParm = sortOrder == "model_name_dsc" ? "model_name_asc" : "model_name_dsc";
            ViewBag.MakeSortParm = sortOrder == "make_name_dsc" ? "make_name_asc" : "make_name_dsc";
            ViewBag.TypeSortParm = sortOrder == "type_name_dsc" ? "type_name_asc" : "type_name_dsc";
            ViewBag.ColorSortParm = sortOrder == "color_name_dsc" ? "color_name_asc" : "color_name_dsc";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var cars = from s in db.CarModels select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.CarMake.Make.Contains(searchString)
                                       || s.CarType.Type.Contains(searchString)
                                       || s.Model.Contains(searchString)
                                       || s.Color.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "model_name_asc":
                    cars = cars.OrderBy(s => s.Model);
                    break;
                case "model_name_dsc":
                    cars = cars.OrderByDescending(s => s.Model);
                    break;
                case "make_name_asc":
                    cars = cars.OrderBy(s => s.CarMake.Make);
                    break;
                case "make_name_dsc":
                    cars = cars.OrderByDescending(s => s.CarMake.Make);
                    break;
                case "type_name_asc":
                    cars = cars.OrderBy(s => s.CarType.Type);
                    break;
                case "type_name_dsc":
                    cars = cars.OrderByDescending(s => s.CarType.Type);
                    break;
                case "color_name_asc":
                    cars = cars.OrderBy(s => s.Color);
                    break;
                case "color_name_dsc":
                    cars = cars.OrderByDescending(s => s.Color);
                    break;
                default:
                    cars = cars.OrderBy(s => s.CarMake.Make);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(cars.ToPagedList(pageNumber, pageSize));
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

        public ActionResult CarImage(int? id)
        {
            CarImage carImage = db.CarImages.FirstOrDefault(s => s.CarModelID == id);
            return PartialView(carImage);
        }
    }
}