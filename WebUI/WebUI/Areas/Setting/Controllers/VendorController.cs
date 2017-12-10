using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.DAL.Data;

namespace WebUI.Areas.Setting.Controllers
{
    public class VendorController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Setting/Vendor
        public ActionResult Index()
        {
            var sMA_Lookup_Vendor = db.SMA_Lookup_Vendor.Include(s => s.SMA_Lookup_Contact).Include(s => s.SMA_Lookup_User);
            return View(sMA_Lookup_Vendor.ToList());
        }

        // GET: Setting/Vendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Vendor sMA_Lookup_Vendor = db.SMA_Lookup_Vendor.Find(id);
            if (sMA_Lookup_Vendor == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Vendor);
        }

        // GET: Setting/Vendor/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title");
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            return View();
        }

        // POST: Setting/Vendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorId,VendorNumber,VendorName,ContactId,DiscountRate,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Vendor sMA_Lookup_Vendor)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Lookup_Vendor.Add(sMA_Lookup_Vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_Vendor.ContactId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Vendor.EnterUserId);
            return View(sMA_Lookup_Vendor);
        }

        // GET: Setting/Vendor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Vendor sMA_Lookup_Vendor = db.SMA_Lookup_Vendor.Find(id);
            if (sMA_Lookup_Vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_Vendor.ContactId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Vendor.EnterUserId);
            return View(sMA_Lookup_Vendor);
        }

        // POST: Setting/Vendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorId,VendorNumber,VendorName,ContactId,DiscountRate,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Vendor sMA_Lookup_Vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Lookup_Vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_Vendor.ContactId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Vendor.EnterUserId);
            return View(sMA_Lookup_Vendor);
        }

        // GET: Setting/Vendor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Vendor sMA_Lookup_Vendor = db.SMA_Lookup_Vendor.Find(id);
            if (sMA_Lookup_Vendor == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Vendor);
        }

        // POST: Setting/Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Lookup_Vendor sMA_Lookup_Vendor = db.SMA_Lookup_Vendor.Find(id);
            db.SMA_Lookup_Vendor.Remove(sMA_Lookup_Vendor);
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
