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
    public class UslugiController : Controller
    {
        UslugiFileService Uslugiservice = new UslugiFileService();

        [HttpGet]
        public ActionResult EditUslugi(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            if (Uslugiservice.findUslugiById(id) != null)
            {
                return View(Uslugiservice.findUslugiById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditUslugi(Uslugi Uslugi)

        {
            Uslugiservice.Edit(Uslugi);
            return RedirectToAction("Uslugis");
        }

        [HttpGet]
        public ActionResult CreateUslugi()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUslugi(Uslugi Uslugi)
        {
            Uslugiservice.Create(Uslugi);
            return RedirectToAction("Uslugis");
        }


        public ActionResult DeleteUslugi(int id)
        {
            Uslugiservice.Delete(id);
            return RedirectToAction("Uslugis");
        }


        public ActionResult Uslugis()
        {          
             return View(Uslugiservice.getList());
           
        }
        protected override void Dispose(bool disposing)
        {
            Uslugiservice.Dispose();
            base.Dispose(disposing);
        }
    }
}