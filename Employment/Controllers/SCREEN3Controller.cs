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
    public class SCREEN3Controller : Controller
    {
        private Medical_clinicEntities2 db = new Medical_clinicEntities2();

        // GET: SCREEN3
        public ActionResult Index()
        {
            var sCREEN3 = db.SCREEN3.Include(s => s.SCREEN1).Include(s => s.SCREEN2);
            return View(sCREEN3.ToList());
        }

        // GET: SCREEN3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN3 sCREEN3 = db.SCREEN3.Find(id);
            if (sCREEN3 == null)
            {
                return HttpNotFound();
            }
            return View(sCREEN3);
        }

        // GET: SCREEN3/Create
        public ActionResult Create()
        {
            ViewBag.Screen1_ID = new SelectList(db.SCREEN1, "ID", "EmployeeName");
            ViewBag.Screen2_ID = new SelectList(db.SCREEN2, "EmployeeID", "ProjectName");
            return View();
        }

        // POST: SCREEN3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Screen1_ID,Screen2_ID,Status,Date")] SCREEN3 sCREEN3)
        {
            if (ModelState.IsValid)
            {
                db.SCREEN3.Add(sCREEN3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Screen1_ID = new SelectList(db.SCREEN1, "ID", "EmployeeName", sCREEN3.Screen1_ID);
            ViewBag.Screen2_ID = new SelectList(db.SCREEN2, "EmployeeID", "ProjectName", sCREEN3.Screen2_ID);
            return View(sCREEN3);
        }

        // GET: SCREEN3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN3 sCREEN3 = db.SCREEN3.Find(id);
            if (sCREEN3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Screen1_ID = new SelectList(db.SCREEN1, "ID", "EmployeeName", sCREEN3.Screen1_ID);
            ViewBag.Screen2_ID = new SelectList(db.SCREEN2, "EmployeeID", "ProjectName", sCREEN3.Screen2_ID);
            return View(sCREEN3);
        }

        // POST: SCREEN3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Screen1_ID,Screen2_ID,Status,Date")] SCREEN3 sCREEN3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCREEN3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Screen1_ID = new SelectList(db.SCREEN1, "ID", "EmployeeName", sCREEN3.Screen1_ID);
            ViewBag.Screen2_ID = new SelectList(db.SCREEN2, "EmployeeID", "ProjectName", sCREEN3.Screen2_ID);
            return View(sCREEN3);
        }

        // GET: SCREEN3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN3 sCREEN3 = db.SCREEN3.Find(id);
            if (sCREEN3 == null)
            {
                return HttpNotFound();
            }
            return View(sCREEN3);
        }

        // POST: SCREEN3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCREEN3 sCREEN3 = db.SCREEN3.Find(id);
            db.SCREEN3.Remove(sCREEN3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Complete([Bind(Include = "Id,Screen1_ID,Screen2_ID,Status,Date")] SCREEN3 sCREEN3)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        sCREEN3.Status = "Incomplete";
        //        db.Entry(sCREEN3).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
          
        //    return View(sCREEN3);
        //}
        public ActionResult Complete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN3 sCREEN3 = db.SCREEN3.Find(id);
            sCREEN3.Status = "Incomplete";
            db.Entry(sCREEN3).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public ActionResult InComplete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN3 sCREEN3 = db.SCREEN3.Find(id);
            sCREEN3.Status = "Complete";
            db.Entry(sCREEN3).State = EntityState.Modified;
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
