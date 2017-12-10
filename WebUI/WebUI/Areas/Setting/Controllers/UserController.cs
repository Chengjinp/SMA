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
    public class UserController : Controller
    {
        private AppDb_SMAEntities db = new AppDb_SMAEntities();

        // GET: Setting/User
        public ActionResult Index()
        {
            var sMA_Lookup_User = db.SMA_Lookup_User.Include(s => s.SMA_Lookup_User_Role);
            return View(sMA_Lookup_User.ToList());
        }

        // GET: Setting/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_User sMA_Lookup_User = db.SMA_Lookup_User.Find(id);
            if (sMA_Lookup_User == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_User);
        }

        // GET: Setting/User/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.SMA_Lookup_User_Role, "RoleId", "RoleName");
            return View();
        }

        // POST: Setting/User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,LoginName,PasswordHash,ContactId,RoleId,EnterUserId,EnterDate,IsActive")] SMA_Lookup_User sMA_Lookup_User)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Lookup_User.Add(sMA_Lookup_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.SMA_Lookup_User_Role, "RoleId", "RoleName", sMA_Lookup_User.RoleId);
            return View(sMA_Lookup_User);
        }

        // GET: Setting/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_User sMA_Lookup_User = db.SMA_Lookup_User.Find(id);
            if (sMA_Lookup_User == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.SMA_Lookup_User_Role, "RoleId", "RoleName", sMA_Lookup_User.RoleId);
            return View(sMA_Lookup_User);
        }

        // POST: Setting/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,LoginName,PasswordHash,ContactId,RoleId,EnterUserId,EnterDate,IsActive")] SMA_Lookup_User sMA_Lookup_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Lookup_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.SMA_Lookup_User_Role, "RoleId", "RoleName", sMA_Lookup_User.RoleId);
            return View(sMA_Lookup_User);
        }

        // GET: Setting/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_User sMA_Lookup_User = db.SMA_Lookup_User.Find(id);
            if (sMA_Lookup_User == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_User);
        }

        // POST: Setting/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Lookup_User sMA_Lookup_User = db.SMA_Lookup_User.Find(id);
            db.SMA_Lookup_User.Remove(sMA_Lookup_User);
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
