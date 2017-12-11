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
    public class DesignerController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Setting/Designer
        public ActionResult Index()
        {
            var sMA_Lookup_Designer = db.SMA_Lookup_Designer.Where(s => s.IsActive != false).Include(s => s.SMA_Lookup_Contact).Include(s => s.SMA_Lookup_User);
            return View(sMA_Lookup_Designer.ToList());
        }

        // GET: Setting/Designer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Designer sMA_Lookup_Designer = db.SMA_Lookup_Designer.Find(id);
            if (sMA_Lookup_Designer == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Designer);
        }

        // GET: Setting/Designer/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title");
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            return View();
        }

        // POST: Setting/Designer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesignerId,DesignerNumber,FirstName,LastName,DiscountRate,ContactId,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Designer sMA_Lookup_Designer)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Lookup_Designer.Add(sMA_Lookup_Designer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_Designer.ContactId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Designer.EnterUserId);
            return View(sMA_Lookup_Designer);
        }

        // GET: Setting/Designer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Designer sMA_Lookup_Designer = db.SMA_Lookup_Designer.Find(id);
            if (sMA_Lookup_Designer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_Designer.ContactId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Designer.EnterUserId);
            return View(sMA_Lookup_Designer);
        }

        // POST: Setting/Designer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesignerId,DesignerNumber,FirstName,LastName,DiscountRate,ContactId,EnterUserId,EnterDate,IsActive")] SMA_Lookup_Designer sMA_Lookup_Designer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Lookup_Designer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_Designer.ContactId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_Designer.EnterUserId);
            return View(sMA_Lookup_Designer);
        }

        // GET: Setting/Designer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_Designer sMA_Lookup_Designer = db.SMA_Lookup_Designer.Find(id);
            if (sMA_Lookup_Designer == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_Designer);
        }

        // POST: Setting/Designer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Lookup_Designer sMA_Lookup_Designer = db.SMA_Lookup_Designer.Find(id);
            sMA_Lookup_Designer.IsActive = false;
            sMA_Lookup_Designer.InActiveDT = DateTime.Now;
            CustomIdentity iden = (CustomIdentity)HttpContext.User.Identity;
            sMA_Lookup_Designer.InActiveBy = iden.UserId;
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
