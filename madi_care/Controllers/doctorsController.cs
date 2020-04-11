using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using madi_care.Models;

namespace madi_care.Controllers
{
    public class doctorsController : Controller
    {
        private medi_careEntities2 db = new medi_careEntities2();

        // GET: doctors
        public ActionResult Index()
        {
            var doctors = db.doctors.Include(d => d.admin);
            return View(doctors.ToList());
        }

        // GET: doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: doctors/Create
        public ActionResult Create()
        {
            ViewBag.aid = new SelectList(db.admins, "aid", "aname");
            return View();
        }

        // POST: doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "did,dname,dphone,daddresss,dgender,dqualification,dmail,dpassword,aid,dage")] doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aid = new SelectList(db.admins, "aid", "aname", doctor.aid);
            return View(doctor);
        }

        // GET: doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.aid = new SelectList(db.admins, "aid", "aname", doctor.aid);
            return View(doctor);
        }

        // POST: doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "did,dname,dphone,daddresss,dgender,dqualification,dmail,dpassword,aid,dage")] doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aid = new SelectList(db.admins, "aid", "aname", doctor.aid);
            return View(doctor);
        }

        // GET: doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doctor doctor = db.doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            doctor doctor = db.doctors.Find(id);
            db.doctors.Remove(doctor);
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
