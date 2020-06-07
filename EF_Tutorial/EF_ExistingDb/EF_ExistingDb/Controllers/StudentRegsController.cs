using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EF_ExistingDb;
using EF_ExistingDb.Models;

namespace EF_ExistingDb.Controllers
{
    public class StudentRegsController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: StudentRegs
        public ActionResult Index()
        {
            return View(db.StudentRegs.ToList());
        }

        // GET: StudentRegs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentReg studentReg = db.StudentRegs.Find(id);
            if (studentReg == null)
            {
                return HttpNotFound();
            }
            return View(studentReg);
        }

        // GET: StudentRegs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentRegs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,City,Address")] StudentReg studentReg)
        {
            if (ModelState.IsValid)
            {
                db.StudentRegs.Add(studentReg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentReg);
        }

        // GET: StudentRegs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentReg studentReg = db.StudentRegs.Find(id);
            if (studentReg == null)
            {
                return HttpNotFound();
            }
            return View(studentReg);
        }

        // POST: StudentRegs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,City,Address")] StudentReg studentReg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentReg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentReg);
        }

        // GET: StudentRegs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentReg studentReg = db.StudentRegs.Find(id);
            if (studentReg == null)
            {
                return HttpNotFound();
            }
            return View(studentReg);
        }

        // POST: StudentRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentReg studentReg = db.StudentRegs.Find(id);
            db.StudentRegs.Remove(studentReg);
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
