using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.DAL.Data;

namespace WebUI.Areas.Inventory.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Inventory/Inventory
        public ActionResult Index(string searchString)
        {
            var sMA_Inventory = db.SMA_Inventory.Include(s => s.SMA_Inventory_Category).Include(s => s.SMA_Inventory_Category_Type).Include(s => s.SMA_Lookup_User).Include(s => s.SMA_Lookup_Vendor);
            if (!String.IsNullOrEmpty(searchString))
            {
                sMA_Inventory = sMA_Inventory.Where(s => s.ProductionId.ToString().Contains(searchString) || s.Description.Contains(searchString));
            }
            return View(sMA_Inventory.ToList());
        }

        // GET: Inventory/Inventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Inventory sMA_Inventory = db.SMA_Inventory.Find(id);
            if (sMA_Inventory == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Inventory);
        }

        // GET: Inventory/Inventory/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.SMA_Inventory_Category, "CategoryId", "Name");
            ViewBag.TypeId = new SelectList(db.SMA_Inventory_Category_Type, "TypeId", "Name");
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            ViewBag.VendorId = new SelectList(db.SMA_Lookup_Vendor, "VendorId", "VendorNumber");
            return View();
        }

        // POST: Inventory/Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductionId,CategoryId,TypeId,Name,Description,Image,VendorId,BookValue,WebRef,EnterUserId,EnterDate,IsActive")] SMA_Inventory sMA_Inventory)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Inventory.Add(sMA_Inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.SMA_Inventory_Category, "CategoryId", "Name", sMA_Inventory.CategoryId);
            ViewBag.TypeId = new SelectList(db.SMA_Inventory_Category_Type, "TypeId", "Name", sMA_Inventory.TypeId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Inventory.EnterUserId);
            ViewBag.VendorId = new SelectList(db.SMA_Lookup_Vendor, "VendorId", "VendorNumber", sMA_Inventory.VendorId);
            return View(sMA_Inventory);
        }

        // GET: Inventory/Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Inventory sMA_Inventory = db.SMA_Inventory.Find(id);
            if (sMA_Inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.SMA_Inventory_Category, "CategoryId", "Name", sMA_Inventory.CategoryId);
            ViewBag.TypeId = new SelectList(db.SMA_Inventory_Category_Type, "TypeId", "Name", sMA_Inventory.TypeId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Inventory.EnterUserId);
            ViewBag.VendorId = new SelectList(db.SMA_Lookup_Vendor, "VendorId", "VendorNumber", sMA_Inventory.VendorId);
            return View(sMA_Inventory);
        }

        // POST: Inventory/Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionId,CategoryId,TypeId,Name,Description,Image,VendorId,BookValue,WebRef,EnterUserId,EnterDate,IsActive")] SMA_Inventory sMA_Inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.SMA_Inventory_Category, "CategoryId", "Name", sMA_Inventory.CategoryId);
            ViewBag.TypeId = new SelectList(db.SMA_Inventory_Category_Type, "TypeId", "Name", sMA_Inventory.TypeId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Inventory.EnterUserId);
            ViewBag.VendorId = new SelectList(db.SMA_Lookup_Vendor, "VendorId", "VendorNumber", sMA_Inventory.VendorId);
            return View(sMA_Inventory);
        }

        // GET: Inventory/Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Inventory sMA_Inventory = db.SMA_Inventory.Find(id);
            if (sMA_Inventory == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Inventory);
        }

        // POST: Inventory/Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Inventory sMA_Inventory = db.SMA_Inventory.Find(id);
            sMA_Inventory.IsActive = false;
            sMA_Inventory.InActiveDT = DateTime.Now;
            CustomIdentity iden = (CustomIdentity)HttpContext.User.Identity;
            sMA_Inventory.InActiveBy = iden.UserId;
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
