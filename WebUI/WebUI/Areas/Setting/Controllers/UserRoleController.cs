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
    public class UserRoleController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Setting/UserRole
        public ActionResult Index()
        {
            return View(db.SMA_Lookup_User_Role.Where(s => s.IsActive != false).ToList());
        }

        // GET: Setting/UserRole/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_User_Role sMA_Lookup_User_Role = db.SMA_Lookup_User_Role.Find(id);
            if (sMA_Lookup_User_Role == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_User_Role);
        }

        // GET: Setting/UserRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setting/UserRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,RoleName,IsActive")] SMA_Lookup_User_Role sMA_Lookup_User_Role)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Lookup_User_Role.Add(sMA_Lookup_User_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMA_Lookup_User_Role);
        }

        // GET: Setting/UserRole/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_User_Role sMA_Lookup_User_Role = db.SMA_Lookup_User_Role.Find(id);
            if (sMA_Lookup_User_Role == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_User_Role);
        }

        // POST: Setting/UserRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,RoleName,IsActive")] SMA_Lookup_User_Role sMA_Lookup_User_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Lookup_User_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMA_Lookup_User_Role);
        }

        // GET: Setting/UserRole/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_User_Role sMA_Lookup_User_Role = db.SMA_Lookup_User_Role.Find(id);
            if (sMA_Lookup_User_Role == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_User_Role);
        }

        // POST: Setting/UserRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Lookup_User_Role sMA_Lookup_User_Role = db.SMA_Lookup_User_Role.Find(id);
            sMA_Lookup_User_Role.IsActive = false;
            sMA_Lookup_User_Role.InActiveDT = DateTime.Now;
            CustomIdentity iden = (CustomIdentity)HttpContext.User.Identity;
            sMA_Lookup_User_Role.InActiveBy = iden.UserId;
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
