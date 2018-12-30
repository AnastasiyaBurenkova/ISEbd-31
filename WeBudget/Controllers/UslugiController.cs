using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeCrossroad.Models;
using WeCrossroad.Service;
using WeCrossroad.Service.Abstract;
using WeCrossroad.Service.FileService;

namespace WeCrossroad.Controllers
{
    public class UslugiController : Controller
    {
        String store = ConfigurationManager.AppSettings.Get("Store");
        ICrossroad Uslugiservice;


        public UslugiController()
        {
            if (store == "db")
            {
                Uslugiservice = new UslugiService();
            }

            if (store == "file")
            {
                Uslugiservice = new UslugiFileService();
            }
        }
      

        [HttpGet]
        public ActionResult EditUslugi(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            if (Uslugiservice.findById(id) != null)
            {
                return View(Uslugiservice.findById(id));
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
       
    }
}