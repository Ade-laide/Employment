using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Employment.Models;

namespace Employment.Controllers
{
    public class HomeController : Controller
    {        Medical_clinicEntities2 db = new Medical_clinicEntities2();  
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

            [HttpGet]

            public ActionResult Admin()
            {
                if (Session["userid"] != null)
                {
                var Admin = new SCREEN1();
                Admin.EntryDate = DateTime.Now;
                return RedirectToAction("Details", "EmployeeDetails");
                }
                return RedirectToAction("Login", "LoginRegister");
            }

            [HttpPost]
            public ActionResult Admin(SCREEN1 Admin)
            {
                if (ModelState.IsValid)
                {
                    db.SCREEN1.Add(Admin);
                    db.SaveChanges();
                    TempData["msg"] = "Data Save Successfully";
                    return View();
                }
                TempData["msg"] = "There is a problem to create ";
                return View();
            }
        }
    }

