using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Employment.Models;
using System.Web.Security;

namespace Employment.Controllers
{
    public class LoginRegisterController : Controller
    {
        // GET: LoginRegister
        Medical_clinicEntities2 db;
        public LoginRegisterController()
        {
            db = new Medical_clinicEntities2();
        }
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;


        [HttpGet]

        public ActionResult Login()

        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SignUp signUp)
        {

            var ChecksignUp = db.SignUps.Where(x => x.UserName == signUp.UserName && (x.Password == signUp.Password)).Count();

            if (ChecksignUp > 0)
            {
                TempData["msg"] = "User Already Exist";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.SignUps.Add(signUp);
                    db.SaveChanges();
                    return RedirectToAction("Login", "LoginRegister");
                }
            }
            TempData["msg"] = "There is a problem to create user";
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(SignUp signUp)
        {
            var checkUser = db.SignUps.Where(x => x.Password == signUp.Password && (x.LastName==signUp.LastName ||x.UserName == signUp.UserName ||x.Email == signUp.Email || x.UserName == signUp.UserName)).Count();
            if (checkUser > 0)
            {
                var userId = db.SignUps.Where(x => x.Password == signUp.Password || (x.Email == signUp.Email || x.UserName == signUp.UserName)).Select(x => x.UserName).FirstOrDefault();
                Session["userid"] = userId;
               
                return RedirectToAction("Index","Screen1");
            }
            else
            {
                TempData["msg"] = "No User Found Check Your Credentials";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }

}
