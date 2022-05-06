using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employment.Models;

namespace Employment.Controllers
{
    public class SCREEN1Controller : Controller
    {
        private Medical_clinicEntities2 db = new Medical_clinicEntities2();

        // GET: SCREEN1
        public ActionResult Index()
        {
            return View(db.SCREEN1.ToList());
        }

        // GET: SCREEN1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN1 sCREEN1 = db.SCREEN1.Find(id);
            if (sCREEN1 == null)
            {
                return HttpNotFound();
            }
            return View(sCREEN1);
        }

        // GET: SCREEN1/Create
        public ActionResult Create()
        {
            if (Session["userid"] != null)
            {
                ViewBag.userid = Session["userid"];
            }
            ViewBag.screenList = db.SCREEN1.ToList();
            var screen1 = new SCREEN1();
            screen1.EntryDate = DateTime.Now;
            return View(screen1);
        }

        // POST: SCREEN1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeName,EntryDate,EmploymentDate,Salary,IsTheEmployeeVaxx,Age,Position,Admin")] SCREEN1 sCREEN1)
        {
            if (ModelState.IsValid)
            {
                db.SCREEN1.Add(sCREEN1);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(sCREEN1);
        }

        // GET: SCREEN1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN1 sCREEN1 = db.SCREEN1.Find(Convert.ToInt32(id));
            if (Session["userid"] != null)
            {
                ViewBag.userid = Session["userid"];
            }
            if (sCREEN1 == null)
            {
                return HttpNotFound();
            }
            return View(sCREEN1);
        }

        // POST: SCREEN1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeName,EntryDate,EmploymentDate,Salary,IsTheEmployeeVaxx,Age,Position,Admin")] SCREEN1 sCREEN1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCREEN1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sCREEN1);
        }

        // GET: SCREEN1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN1 sCREEN1 = db.SCREEN1.Find(Convert.ToInt32(id));
            if (sCREEN1 == null)
            {
                return HttpNotFound();
            }
            return View(sCREEN1);
        }

        // POST: SCREEN1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SCREEN1 sCREEN1 = db.SCREEN1.Find(Convert.ToInt32(id));
            db.SCREEN1.Remove(sCREEN1);
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
