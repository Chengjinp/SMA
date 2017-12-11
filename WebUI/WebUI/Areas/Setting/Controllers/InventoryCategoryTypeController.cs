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
    public class InventoryCategoryTypeController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Setting/InventoryCategoryType
        public ActionResult Index()
        {
            var sMA_Inventory_Category_Type = db.SMA_Inventory_Category_Type.Where(s => s.IsActive != false).Include(s => s.SMA_Inventory_Category);
            return View(sMA_Inventory_Category_Type.ToList());
        }

        // GET: Setting/InventoryCategoryType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Inventory_Category_Type sMA_Inventory_Category_Type = db.SMA_Inventory_Category_Type.Find(id);
            if (sMA_Inventory_Category_Type == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Inventory_Category_Type);
        }

        // GET: Setting/InventoryCategoryType/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.SMA_Inventory_Category, "CategoryId", "Name");
            return View();
        }

        // POST: Setting/InventoryCategoryType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,CategoryId,Name,Description,IsActive")] SMA_Inventory_Category_Type sMA_Inventory_Category_Type)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Inventory_Category_Type.Add(sMA_Inventory_Category_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.SMA_Inventory_Category, "CategoryId", "Name", sMA_Inventory_Category_Type.CategoryId);
            return View(sMA_Inventory_Category_Type);
        }

        // GET: Setting/InventoryCategoryType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Inventory_Category_Type sMA_Inventory_Category_Type = db.SMA_Inventory_Category_Type.Find(id);
            if (sMA_Inventory_Category_Type == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.SMA_Inventory_Category, "CategoryId", "Name", sMA_Inventory_Category_Type.CategoryId);
            return View(sMA_Inventory_Category_Type);
        }

        // POST: Setting/InventoryCategoryType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,CategoryId,Name,Description,IsActive")] SMA_Inventory_Category_Type sMA_Inventory_Category_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Inventory_Category_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.SMA_Inventory_Category, "CategoryId", "Name", sMA_Inventory_Category_Type.CategoryId);
            return View(sMA_Inventory_Category_Type);
        }

        // GET: Setting/InventoryCategoryType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Inventory_Category_Type sMA_Inventory_Category_Type = db.SMA_Inventory_Category_Type.Find(id);
            if (sMA_Inventory_Category_Type == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Inventory_Category_Type);
        }

        // POST: Setting/InventoryCategoryType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Inventory_Category_Type sMA_Inventory_Category_Type = db.SMA_Inventory_Category_Type.Find(id);
            sMA_Inventory_Category_Type.IsActive = false;
            sMA_Inventory_Category_Type.InActiveDT = DateTime.Now;
            CustomIdentity iden = (CustomIdentity)HttpContext.User.Identity;
            sMA_Inventory_Category_Type.InActiveBy = iden.UserId;
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
