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
    public class ContactController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Setting/Contact
        public ActionResult Index()
        {
            var sMA_Lookup_Contact = db.SMA_Lookup_Contact.Where(s => s.IsActive != false).Include(s => s.SMA_Lookup_Address).Include(s => s.SMA_Lookup_Address1).Include(s => s.SMA_Lookup_User);
            return View(sMA_Lookup_Contact.ToList());
        }

        // GET: Setting/Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Contact sMA_Lookup_Contact = db.SMA_Lookup_Contact.Find(id);
            if (sMA_Lookup_Contact == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Contact);
        }

        // GET: Setting/Contact/Create
        public ActionResult Create()
        {
            ViewBag.PrimaryAddressId = new SelectList(db.SMA_Lookup_Address, "AddressId", "Address");
            ViewBag.SecondaryAddressId = new SelectList(db.SMA_Lookup_Address, "AddressId", "Address");
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            return View();
        }

        // POST: Setting/Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,Title,FirstName,LastName,PrimaryAddressTypeId,PrimaryAddressId,SecondaryAddressTypeId,SecondaryAddressId,PrimaryPhone,SecondaryPhone,EmailAddress,IMAddress,WebSite,NativeLauguage,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Contact sMA_Lookup_Contact)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Lookup_Contact.Add(sMA_Lookup_Contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrimaryAddressId = new SelectList(db.SMA_Lookup_Address, "AddressId", "Address", sMA_Lookup_Contact.PrimaryAddressId);
            ViewBag.SecondaryAddressId = new SelectList(db.SMA_Lookup_Address, "AddressId", "Address", sMA_Lookup_Contact.SecondaryAddressId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Contact.EnterUserId);
            return View(sMA_Lookup_Contact);
        }

        // GET: Setting/Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Contact sMA_Lookup_Contact = db.SMA_Lookup_Contact.Find(id);
            if (sMA_Lookup_Contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrimaryAddressId = new SelectList(db.SMA_Lookup_Address, "AddressId", "Address", sMA_Lookup_Contact.PrimaryAddressId);
            ViewBag.SecondaryAddressId = new SelectList(db.SMA_Lookup_Address, "AddressId", "Address", sMA_Lookup_Contact.SecondaryAddressId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Contact.EnterUserId);
            return View(sMA_Lookup_Contact);
        }

        // POST: Setting/Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,Title,FirstName,LastName,PrimaryAddressTypeId,PrimaryAddressId,SecondaryAddressTypeId,SecondaryAddressId,PrimaryPhone,SecondaryPhone,EmailAddress,IMAddress,WebSite,NativeLauguage,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Contact sMA_Lookup_Contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Lookup_Contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrimaryAddressId = new SelectList(db.SMA_Lookup_Address, "AddressId", "Address", sMA_Lookup_Contact.PrimaryAddressId);
            ViewBag.SecondaryAddressId = new SelectList(db.SMA_Lookup_Address, "AddressId", "Address", sMA_Lookup_Contact.SecondaryAddressId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Contact.EnterUserId);
            return View(sMA_Lookup_Contact);
        }

        // GET: Setting/Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Contact sMA_Lookup_Contact = db.SMA_Lookup_Contact.Find(id);
            if (sMA_Lookup_Contact == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Contact);
        }

        // POST: Setting/Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Lookup_Contact sMA_Lookup_Contact = db.SMA_Lookup_Contact.Find(id);
            sMA_Lookup_Contact.IsActive = false;
            sMA_Lookup_Contact.InActiveDT = DateTime.Now;
            CustomIdentity iden = (CustomIdentity)HttpContext.User.Identity;
            sMA_Lookup_Contact.InActiveBy = iden.UserId;
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
