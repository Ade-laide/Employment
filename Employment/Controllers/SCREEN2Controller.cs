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

    public class SCREEN2Controller : Controller
    {
        private Medical_clinicEntities2 db = new Medical_clinicEntities2();

        // GET: SCREEN2
        public ActionResult Index()
        {
            var sCREEN2 = db.SCREEN2.Include(s => s.SCREEN1);
            return View(sCREEN2.ToList());
        }

        // GET: SCREEN2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN2 sCREEN2 = db.SCREEN2.Find(id);
            if (sCREEN2 == null)
            {
                return HttpNotFound();
            }
            return View(sCREEN2);
        }

        // GET: SCREEN2/Create
        public ActionResult Create()
        {
            if (Session["userid"] != null)
            {
                ViewBag.userid = Session["userid"];
            }
            ViewBag.ID = new SelectList(db.SCREEN1, "ID", "EmployeeName");
            return View();
        }

        // POST: SCREEN2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,ProjectName,ProjectManager,ProjectStartDate,ProjectEndDate,Department,Admin,ID")] SCREEN2 sCREEN2)
        {
            if (ModelState.IsValid)
            {
                db.SCREEN2.Add(sCREEN2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.SCREEN1, "ID", "EmployeeName", sCREEN2.ID);
            return View(sCREEN2);
        }

        // GET: SCREEN2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN2 sCREEN2 = db.SCREEN2.Find(id);
            if (Session["userid"] != null)
            {
                ViewBag.userid = Session["userid"];
            }
            if (sCREEN2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.SCREEN1, "ID", "EmployeeName", sCREEN2.ID);

            return View(sCREEN2);
        }

        // POST: SCREEN2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,ProjectName,ProjectManager,ProjectStartDate,ProjectEndDate,Department,Admin,ID")] SCREEN2 sCREEN2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sCREEN2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.SCREEN1, "ID", "EmployeeName", sCREEN2.ID);

            return View(sCREEN2);
        }

        // GET: SCREEN2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SCREEN2 sCREEN2 = db.SCREEN2.Find(id);
            if (sCREEN2 == null)
            {
                return HttpNotFound();
            }
            return View(sCREEN2);
        }

        // POST: SCREEN2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SCREEN2 sCREEN2 = db.SCREEN2.Find(id);
            db.SCREEN2.Remove(sCREEN2);
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
