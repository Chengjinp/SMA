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
    public class SaleDetailTypeController : Controller
    {
        private AppDb_SMAEntities db = new AppDb_SMAEntities();

        // GET: Setting/SaleDetailType
        public ActionResult Index()
        {
            return View(db.SMA_Sale_Detail_Type.ToList());
        }

        // GET: Setting/SaleDetailType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale_Detail_Type sMA_Sale_Detail_Type = db.SMA_Sale_Detail_Type.Find(id);
            if (sMA_Sale_Detail_Type == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Sale_Detail_Type);
        }

        // GET: Setting/SaleDetailType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setting/SaleDetailType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,TypeName,IsActive")] SMA_Sale_Detail_Type sMA_Sale_Detail_Type)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Sale_Detail_Type.Add(sMA_Sale_Detail_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMA_Sale_Detail_Type);
        }

        // GET: Setting/SaleDetailType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale_Detail_Type sMA_Sale_Detail_Type = db.SMA_Sale_Detail_Type.Find(id);
            if (sMA_Sale_Detail_Type == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Sale_Detail_Type);
        }

        // POST: Setting/SaleDetailType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,TypeName,IsActive")] SMA_Sale_Detail_Type sMA_Sale_Detail_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Sale_Detail_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMA_Sale_Detail_Type);
        }

        // GET: Setting/SaleDetailType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale_Detail_Type sMA_Sale_Detail_Type = db.SMA_Sale_Detail_Type.Find(id);
            if (sMA_Sale_Detail_Type == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Sale_Detail_Type);
        }

        // POST: Setting/SaleDetailType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Sale_Detail_Type sMA_Sale_Detail_Type = db.SMA_Sale_Detail_Type.Find(id);
            db.SMA_Sale_Detail_Type.Remove(sMA_Sale_Detail_Type);
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
