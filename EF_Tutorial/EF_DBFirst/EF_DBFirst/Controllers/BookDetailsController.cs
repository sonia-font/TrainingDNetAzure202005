using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstEFProject.Models;

namespace FirstEFProject.Controllers
{
    public class BookDetailsController : Controller
    {
        private LibraryDBEntities db = new LibraryDBEntities();

        // GET: BookDetails
        public ActionResult Index()
        {
            return View(db.BookDetails.ToList());
        }

        // GET: BookDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDetail bookDetail = db.BookDetails.Find(id);
            if (bookDetail == null)
            {
                return HttpNotFound();
            }
            return View(bookDetail);
        }

        // GET: BookDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookName,Price,Category,AuthorName,Edition,BookCondition,Available")] BookDetail bookDetail)
        {
            if (ModelState.IsValid)
            {
                db.BookDetails.Add(bookDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookDetail);
        }

        // GET: BookDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDetail bookDetail = db.BookDetails.Find(id);
            if (bookDetail == null)
            {
                return HttpNotFound();
            }
            return View(bookDetail);
        }

        // POST: BookDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookName,Price,Category,AuthorName,Edition,BookCondition,Available")] BookDetail bookDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookDetail);
        }

        // GET: BookDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookDetail bookDetail = db.BookDetails.Find(id);
            if (bookDetail == null)
            {
                return HttpNotFound();
            }
            return View(bookDetail);
        }

        // POST: BookDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookDetail bookDetail = db.BookDetails.Find(id);
            db.BookDetails.Remove(bookDetail);
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
