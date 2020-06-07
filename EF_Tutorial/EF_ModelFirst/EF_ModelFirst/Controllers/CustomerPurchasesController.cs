using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelFirst;

namespace ModelFirst.Controllers
{
    public class CustomerPurchasesController : Controller
    {
        private CustomerModelContainer db = new CustomerModelContainer();

        // GET: CustomerPurchases
        public ActionResult Index()
        {
            var customerPurchases = db.CustomerPurchases.Include(c => c.CustomerProfile);
            return View(customerPurchases.ToList());
        }

        // GET: CustomerPurchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPurchase customerPurchase = db.CustomerPurchases.Find(id);
            if (customerPurchase == null)
            {
                return HttpNotFound();
            }
            return View(customerPurchase);
        }

        // GET: CustomerPurchases/Create
        public ActionResult Create()
        {
            ViewBag.CustomerProfileCustId = new SelectList(db.CustomerProfiles, "CustId", "CustName");
            return View();
        }

        // POST: CustomerPurchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustId,Product,Price,PurchaseDate,CustomerProfileCustId")] CustomerPurchase customerPurchase)
        {
            if (ModelState.IsValid)
            {
                db.CustomerPurchases.Add(customerPurchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerProfileCustId = new SelectList(db.CustomerProfiles, "CustId", "CustName", customerPurchase.CustomerProfileCustId);
            return View(customerPurchase);
        }

        // GET: CustomerPurchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPurchase customerPurchase = db.CustomerPurchases.Find(id);
            if (customerPurchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerProfileCustId = new SelectList(db.CustomerProfiles, "CustId", "CustName", customerPurchase.CustomerProfileCustId);
            return View(customerPurchase);
        }

        // POST: CustomerPurchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustId,Product,Price,PurchaseDate,CustomerProfileCustId")] CustomerPurchase customerPurchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerPurchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerProfileCustId = new SelectList(db.CustomerProfiles, "CustId", "CustName", customerPurchase.CustomerProfileCustId);
            return View(customerPurchase);
        }

        // GET: CustomerPurchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPurchase customerPurchase = db.CustomerPurchases.Find(id);
            if (customerPurchase == null)
            {
                return HttpNotFound();
            }
            return View(customerPurchase);
        }

        // POST: CustomerPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerPurchase customerPurchase = db.CustomerPurchases.Find(id);
            db.CustomerPurchases.Remove(customerPurchase);
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
