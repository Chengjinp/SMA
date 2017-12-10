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
    public class AddressController : Controller
    {
        private AppDb_SMAEntities db = new AppDb_SMAEntities();

        // GET: Setting/Address
        public ActionResult Index()
        {
            var sMA_Lookup_Address = db.SMA_Lookup_Address.Include(s => s.SMA_Lookup_User);
            return View(sMA_Lookup_Address.ToList());
        }

        // GET: Setting/Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Address sMA_Lookup_Address = db.SMA_Lookup_Address.Find(id);
            if (sMA_Lookup_Address == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Address);
        }

        // GET: Setting/Address/Create
        public ActionResult Create()
        {
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            return View();
        }

        // POST: Setting/Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressId,Address,City,Province,PostalCode,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Address sMA_Lookup_Address)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Lookup_Address.Add(sMA_Lookup_Address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Address.EnterUserId);
            return View(sMA_Lookup_Address);
        }

        // GET: Setting/Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Address sMA_Lookup_Address = db.SMA_Lookup_Address.Find(id);
            if (sMA_Lookup_Address == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Address.EnterUserId);
            return View(sMA_Lookup_Address);
        }

        // POST: Setting/Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressId,Address,City,Province,PostalCode,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Address sMA_Lookup_Address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Lookup_Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Address.EnterUserId);
            return View(sMA_Lookup_Address);
        }

        // GET: Setting/Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Address sMA_Lookup_Address = db.SMA_Lookup_Address.Find(id);
            if (sMA_Lookup_Address == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Address);
        }

        // POST: Setting/Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Lookup_Address sMA_Lookup_Address = db.SMA_Lookup_Address.Find(id);
            db.SMA_Lookup_Address.Remove(sMA_Lookup_Address);
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
