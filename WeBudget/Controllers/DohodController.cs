using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;
using WeBudget.Service;
using WeBudget.Service.FileService;

namespace WeBudget.Controllers
{
    public class CarController : Controller
    {
        CarFileService Carservice = new CarFileService();

        [HttpGet]
        public ActionResult EditCar(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
           
            if (Carservice.findCarById(id) != null)
            {
                return View(Carservice.findCarById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditCar(Car Car)
        {
            Carservice.Edit(Car);
            return RedirectToAction("Cars");
        }

        [HttpGet]
        public ActionResult CreateCar()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCar(Car Car)
        {
            Carservice.Create(Car);
            return RedirectToAction("Cars");
        }

        public ActionResult DeleteCar(int id)
        {
            Carservice.Delete(id);
            return RedirectToAction("Cars");
        }

        public ActionResult Cars()

        {
            return View(Carservice.getList());
        }
        protected override void Dispose(bool disposing)
        {
            Carservice.Dispose();
            base.Dispose(disposing);
        }
    }
}