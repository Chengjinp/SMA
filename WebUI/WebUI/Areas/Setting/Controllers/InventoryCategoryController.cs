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
    public class InventoryCategoryController : Controller
    {
        private AppDb_SMAEntities db = new AppDb_SMAEntities();

        // GET: Setting/InventoryCategory
        public ActionResult Index()
        {
            return View(db.SMA_Inventory_Category.ToList());
        }

        // GET: Setting/InventoryCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Inventory_Category sMA_Inventory_Category = db.SMA_Inventory_Category.Find(id);
            if (sMA_Inventory_Category == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Inventory_Category);
        }

        // GET: Setting/InventoryCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setting/InventoryCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Name,Description,IsActive")] SMA_Inventory_Category sMA_Inventory_Category)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Inventory_Category.Add(sMA_Inventory_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMA_Inventory_Category);
        }

        // GET: Setting/InventoryCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Inventory_Category sMA_Inventory_Category = db.SMA_Inventory_Category.Find(id);
            if (sMA_Inventory_Category == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Inventory_Category);
        }

        // POST: Setting/InventoryCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Name,Description,IsActive")] SMA_Inventory_Category sMA_Inventory_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Inventory_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMA_Inventory_Category);
        }

        // GET: Setting/InventoryCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Inventory_Category sMA_Inventory_Category = db.SMA_Inventory_Category.Find(id);
            if (sMA_Inventory_Category == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Inventory_Category);
        }

        // POST: Setting/InventoryCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Inventory_Category sMA_Inventory_Category = db.SMA_Inventory_Category.Find(id);
            db.SMA_Inventory_Category.Remove(sMA_Inventory_Category);
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
