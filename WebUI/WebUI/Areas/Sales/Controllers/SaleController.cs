using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.DAL.Data;

namespace WebUI.Areas.Sales.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private AppDb_SMAEntities db = new AppDb_SMAEntities();

        // GET: Sales/Sale
        public ActionResult Index()
        {
            var sMA_Sale = db.SMA_Sale.Include(s => s.SMA_Lookup_Customer).Include(s => s.SMA_Lookup_Designer).Include(s => s.SMA_Lookup_SalesRep).Include(s => s.SMA_Lookup_User);
            return View(sMA_Sale.ToList());
        }

        // GET: Sales/Sale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale sMA_Sale = db.SMA_Sale.Find(id);
            if (sMA_Sale == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Sale);
        }

        // GET: Sales/Sale/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.SMA_Lookup_Customer, "CustomerId", "CustomerNumber");
            ViewBag.DesignerId = new SelectList(db.SMA_Lookup_Designer, "DesignerId", "DesignerNumber");
            ViewBag.SalesRepId = new SelectList(db.SMA_Lookup_SalesRep, "SalesRepId", "SalesRepNo");
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            return View();
        }

        // POST: Sales/Sale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleId,CustomerId,DesignerId,SalesRepId,InvYear,InvMonth,TransationDate,InvoiceNumber,DeliveryDate,Status,EnterUserId,EnterDate")] SMA_Sale sMA_Sale)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Sale.Add(sMA_Sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.SMA_Lookup_Customer, "CustomerId", "CustomerNumber", sMA_Sale.CustomerId);
            ViewBag.DesignerId = new SelectList(db.SMA_Lookup_Designer, "DesignerId", "DesignerNumber", sMA_Sale.DesignerId);
            ViewBag.SalesRepId = new SelectList(db.SMA_Lookup_SalesRep, "SalesRepId", "SalesRepNo", sMA_Sale.SalesRepId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Sale.EnterUserId);
            return View(sMA_Sale);
        }

        // GET: Sales/Sale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale sMA_Sale = db.SMA_Sale.Find(id);
            if (sMA_Sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.SMA_Lookup_Customer, "CustomerId", "CustomerNumber", sMA_Sale.CustomerId);
            ViewBag.DesignerId = new SelectList(db.SMA_Lookup_Designer, "DesignerId", "DesignerNumber", sMA_Sale.DesignerId);
            ViewBag.SalesRepId = new SelectList(db.SMA_Lookup_SalesRep, "SalesRepId", "SalesRepNo", sMA_Sale.SalesRepId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Sale.EnterUserId);
            return View(sMA_Sale);
        }

        // POST: Sales/Sale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleId,CustomerId,DesignerId,SalesRepId,InvYear,InvMonth,TransationDate,InvoiceNumber,DeliveryDate,Status,EnterUserId,EnterDate")] SMA_Sale sMA_Sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.SMA_Lookup_Customer, "CustomerId", "CustomerNumber", sMA_Sale.CustomerId);
            ViewBag.DesignerId = new SelectList(db.SMA_Lookup_Designer, "DesignerId", "DesignerNumber", sMA_Sale.DesignerId);
            ViewBag.SalesRepId = new SelectList(db.SMA_Lookup_SalesRep, "SalesRepId", "SalesRepNo", sMA_Sale.SalesRepId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Sale.EnterUserId);
            return View(sMA_Sale);
        }

        // GET: Sales/Sale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale sMA_Sale = db.SMA_Sale.Find(id);
            if (sMA_Sale == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Sale);
        }

        // POST: Sales/Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Sale sMA_Sale = db.SMA_Sale.Find(id);
            db.SMA_Sale.Remove(sMA_Sale);
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
