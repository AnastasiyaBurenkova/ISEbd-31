using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;
using WeBudget.Service;
using WeBudget.Service.Abstract;
using WeBudget.Service.FileService;

namespace WeBudget.Controllers
{
    public class CarController : Controller
    {
       String store = ConfigurationManager.AppSettings.Get("Store");
       ICrossroad Carservice;
      

        public CarController() {
            if (store == "db")
            {
              Carservice = new CarService();
            }

            if (store == "file")
            {
              Carservice = new CarFileService();
            }
        }

        [HttpGet]
        public ActionResult EditCar(int? id)
        {

            if (Carservice.findById(id) != null)
            {
                return View(Carservice.findById(id));
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
    }
}