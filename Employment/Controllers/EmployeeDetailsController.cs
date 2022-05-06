using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Employment.Models;
using System.Configuration;

namespace Employment.Controllers
{
    public class EmployeeDetailsController : Controller
    {     
        // GET: Admin
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;


        string connection = ConfigurationManager.ConnectionStrings["Medical_clinicEntities"].ConnectionString;
        // GET: Admin
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = connection;
        }
        [HttpPost]
        public ActionResult Details(SCREEN1 screen1 )
        {
            connectionString();
            con.Open();
            cmd.Connection = con;

            var Details = new SCREEN1();
            Details.EntryDate = DateTime.Now;
         
            cmd.CommandText = "Select * from SCREEN1 where EmployeeName ='" + screen1.EmployeeName + "' and EntryDate ='" + screen1.EntryDate + "' and EmploymentDate ='" + screen1.EmploymentDate + "' and Salary='" + screen1.Salary + "' and IsTheEnplyeeVaxxed = '" + screen1.IsTheEmployeeVaxx + "' and Age= '" + screen1.Age + "' and Position ='" + screen1.Position + "'  and Admin ='" + screen1.Admin + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ViewBag.Notification = "This account has already existed";
                con.Close();
                return View("SCREEN1");
            }
            else
            {
                con.Close();
                //return View("Error");
                return RedirectToAction("Index", "Home");

            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
    }
}
