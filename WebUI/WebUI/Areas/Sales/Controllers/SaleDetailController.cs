using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.DAL.Data;

namespace WebUI.Areas.Sales.Controllers
{
    [Authorize]
    public class SaleDetailController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Sales/SaleDetail
        public ActionResult Index()
        {
            var sMA_Sale_Detail = db.SMA_Sale_Detail.Where(s => s.IsActive != false).Include(s => s.SMA_Lookup_User).Include(s => s.SMA_Sale).Include(s => s.SMA_Sale_Detail_Type);
            return View(sMA_Sale_Detail.ToList());
        }

        // GET: Sales/SaleDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale_Detail sMA_Sale_Detail = db.SMA_Sale_Detail.Find(id);
            if (sMA_Sale_Detail == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Sale_Detail);
        }

        // GET: Sales/SaleDetail/Create
        public ActionResult Create()
        {
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            ViewBag.SaleId = new SelectList(db.SMA_Sale, "SaleId", "InvoiceNumber");
            ViewBag.DetailType = new SelectList(db.SMA_Sale_Detail_Type, "TypeId", "TypeName");
            return View();
        }

        // POST: Sales/SaleDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleDetailId,SaleId,DetailType,Amount,EnterUserId,EnterDate,IsActive")] SMA_Sale_Detail sMA_Sale_Detail)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Sale_Detail.Add(sMA_Sale_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Sale_Detail.EnterUserId);
            ViewBag.SaleId = new SelectList(db.SMA_Sale, "SaleId", "InvoiceNumber", sMA_Sale_Detail.SaleId);
            ViewBag.DetailType = new SelectList(db.SMA_Sale_Detail_Type, "TypeId", "TypeName", sMA_Sale_Detail.DetailType);
            return View(sMA_Sale_Detail);
        }

        // GET: Sales/SaleDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale_Detail sMA_Sale_Detail = db.SMA_Sale_Detail.Find(id);
            if (sMA_Sale_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Sale_Detail.EnterUserId);
            ViewBag.SaleId = new SelectList(db.SMA_Sale, "SaleId", "InvoiceNumber", sMA_Sale_Detail.SaleId);
            ViewBag.DetailType = new SelectList(db.SMA_Sale_Detail_Type, "TypeId", "TypeName", sMA_Sale_Detail.DetailType);
            return View(sMA_Sale_Detail);
        }

        // POST: Sales/SaleDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleDetailId,SaleId,DetailType,Amount,EnterUserId,EnterDate,IsActive")] SMA_Sale_Detail sMA_Sale_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Sale_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Sale_Detail.EnterUserId);
            ViewBag.SaleId = new SelectList(db.SMA_Sale, "SaleId", "InvoiceNumber", sMA_Sale_Detail.SaleId);
            ViewBag.DetailType = new SelectList(db.SMA_Sale_Detail_Type, "TypeId", "TypeName", sMA_Sale_Detail.DetailType);
            return View(sMA_Sale_Detail);
        }

        // GET: Sales/SaleDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Sale_Detail sMA_Sale_Detail = db.SMA_Sale_Detail.Find(id);
            if (sMA_Sale_Detail == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Sale_Detail);
        }

        // POST: Sales/SaleDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Sale_Detail sMA_Sale_Detail = db.SMA_Sale_Detail.Find(id);
            sMA_Sale_Detail.IsActive = false;
            sMA_Sale_Detail.InActiveDT = DateTime.Now;
            CustomIdentity iden = (CustomIdentity)HttpContext.User.Identity;
            sMA_Sale_Detail.InActiveBy = iden.UserId;
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
