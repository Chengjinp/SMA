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
    public class CustomerController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Setting/Customer
        public ActionResult Index()
        {
            var sMA_Lookup_Customer = db.SMA_Lookup_Customer.Where(s => s.IsActive != false).Include(s => s.SMA_Lookup_Contact).Include(s => s.SMA_Lookup_User);
            return View(sMA_Lookup_Customer.ToList());
        }

        // GET: Setting/Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Customer sMA_Lookup_Customer = db.SMA_Lookup_Customer.Find(id);
            if (sMA_Lookup_Customer == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Customer);
        }

        // GET: Setting/Customer/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title");
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            return View();
        }

        // POST: Setting/Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerNumber,CustomerName,SalesRepId,ContactId,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Customer sMA_Lookup_Customer)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Lookup_Customer.Add(sMA_Lookup_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_Customer.ContactId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Customer.EnterUserId);
            return View(sMA_Lookup_Customer);
        }

        // GET: Setting/Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Customer sMA_Lookup_Customer = db.SMA_Lookup_Customer.Find(id);
            if (sMA_Lookup_Customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_Customer.ContactId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Customer.EnterUserId);
            return View(sMA_Lookup_Customer);
        }

        // POST: Setting/Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerNumber,CustomerName,SalesRepId,ContactId,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Customer sMA_Lookup_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Lookup_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_Customer.ContactId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Customer.EnterUserId);
            return View(sMA_Lookup_Customer);
        }

        // GET: Setting/Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Customer sMA_Lookup_Customer = db.SMA_Lookup_Customer.Find(id);
            if (sMA_Lookup_Customer == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Customer);
        }

        // POST: Setting/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Lookup_Customer sMA_Lookup_Customer = db.SMA_Lookup_Customer.Find(id);
            sMA_Lookup_Customer.IsActive = false;
            sMA_Lookup_Customer.InActiveDT = DateTime.Now;
            CustomIdentity iden = (CustomIdentity)HttpContext.User.Identity;
            sMA_Lookup_Customer.InActiveBy = iden.UserId;
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
