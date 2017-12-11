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
    public class SaleInventoryController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Sales/SaleInventory
        public ActionResult Index()
        {
            var sMA_Sale_Inventory_Xrf = db.SMA_Sale_Inventory_Xrf.Where(s => s.IsActive != false).Include(s => s.SMA_Inventory).Include(s => s.SMA_Lookup_User).Include(s => s.SMA_Sale);
            return View(sMA_Sale_Inventory_Xrf.ToList());
        }

        // GET: Sales/SaleInventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale_Inventory_Xrf sMA_Sale_Inventory_Xrf = db.SMA_Sale_Inventory_Xrf.Find(id);
            if (sMA_Sale_Inventory_Xrf == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Sale_Inventory_Xrf);
        }

        // GET: Sales/SaleInventory/Create
        public ActionResult Create()
        {
            ViewBag.ProductionId = new SelectList(db.SMA_Inventory, "ProductionId", "Name");
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            ViewBag.SaleId = new SelectList(db.SMA_Sale, "SaleId", "InvoiceNumber");
            return View();
        }

        // POST: Sales/SaleInventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "xrfId,SaleId,ProductionId,EnterUserId,EnterDate")] SMA_Sale_Inventory_Xrf sMA_Sale_Inventory_Xrf)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Sale_Inventory_Xrf.Add(sMA_Sale_Inventory_Xrf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductionId = new SelectList(db.SMA_Inventory, "ProductionId", "Name", sMA_Sale_Inventory_Xrf.ProductionId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Sale_Inventory_Xrf.EnterUserId);
            ViewBag.SaleId = new SelectList(db.SMA_Sale, "SaleId", "InvoiceNumber", sMA_Sale_Inventory_Xrf.SaleId);
            return View(sMA_Sale_Inventory_Xrf);
        }

        // GET: Sales/SaleInventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale_Inventory_Xrf sMA_Sale_Inventory_Xrf = db.SMA_Sale_Inventory_Xrf.Find(id);
            if (sMA_Sale_Inventory_Xrf == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductionId = new SelectList(db.SMA_Inventory, "ProductionId", "Name", sMA_Sale_Inventory_Xrf.ProductionId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Sale_Inventory_Xrf.EnterUserId);
            ViewBag.SaleId = new SelectList(db.SMA_Sale, "SaleId", "InvoiceNumber", sMA_Sale_Inventory_Xrf.SaleId);
            return View(sMA_Sale_Inventory_Xrf);
        }

        // POST: Sales/SaleInventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "xrfId,SaleId,ProductionId,EnterUserId,EnterDate")] SMA_Sale_Inventory_Xrf sMA_Sale_Inventory_Xrf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Sale_Inventory_Xrf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductionId = new SelectList(db.SMA_Inventory, "ProductionId", "Name", sMA_Sale_Inventory_Xrf.ProductionId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Sale_Inventory_Xrf.EnterUserId);
            ViewBag.SaleId = new SelectList(db.SMA_Sale, "SaleId", "InvoiceNumber", sMA_Sale_Inventory_Xrf.SaleId);
            return View(sMA_Sale_Inventory_Xrf);
        }

        // GET: Sales/SaleInventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale_Inventory_Xrf sMA_Sale_Inventory_Xrf = db.SMA_Sale_Inventory_Xrf.Find(id);
            if (sMA_Sale_Inventory_Xrf == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Sale_Inventory_Xrf);
        }

        // POST: Sales/SaleInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Sale_Inventory_Xrf sMA_Sale_Inventory_Xrf = db.SMA_Sale_Inventory_Xrf.Find(id);
            sMA_Sale_Inventory_Xrf.IsActive = false;
            sMA_Sale_Inventory_Xrf.InActiveDT = DateTime.Now;
            CustomIdentity iden = (CustomIdentity)HttpContext.User.Identity;
            sMA_Sale_Inventory_Xrf.InActiveBy = iden.UserId;
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
