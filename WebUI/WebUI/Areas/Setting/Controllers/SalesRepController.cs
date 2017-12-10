﻿using System;
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
    public class SalesRepController : Controller
    {
        private AppDb_SMAEntities db = UserDataAccessor.GetDBContext();

        // GET: Setting/SalesRep
        public ActionResult Index()
        {
            var sMA_Lookup_SalesRep = db.SMA_Lookup_SalesRep.Include(s => s.SMA_Lookup_Contact).Include(s => s.SMA_Lookup_User).Include(s => s.SMA_Lookup_User_Role).Include(s => s.SMA_Lookup_User1);
            return View(sMA_Lookup_SalesRep.ToList());
        }

        // GET: Setting/SalesRep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_SalesRep sMA_Lookup_SalesRep = db.SMA_Lookup_SalesRep.Find(id);
            if (sMA_Lookup_SalesRep == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_SalesRep);
        }

        // GET: Setting/SalesRep/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title");
            ViewBag.UserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            ViewBag.RoleId = new SelectList(db.SMA_Lookup_User_Role, "RoleId", "RoleName");
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName");
            return View();
        }

        // POST: Setting/SalesRep/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesRepId,SalesRepNo,UserId,FirstName,LastName,RoleId,ContactId,EnterUserId,EnterDate,IsActive")] SMA_Lookup_SalesRep sMA_Lookup_SalesRep)
        {
            if (ModelState.IsValid)
            {
                db.SMA_Lookup_SalesRep.Add(sMA_Lookup_SalesRep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_SalesRep.ContactId);
            ViewBag.UserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_SalesRep.UserId);
            ViewBag.RoleId = new SelectList(db.SMA_Lookup_User_Role, "RoleId", "RoleName", sMA_Lookup_SalesRep.RoleId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_SalesRep.EnterUserId);
            return View(sMA_Lookup_SalesRep);
        }

        // GET: Setting/SalesRep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_SalesRep sMA_Lookup_SalesRep = db.SMA_Lookup_SalesRep.Find(id);
            if (sMA_Lookup_SalesRep == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_SalesRep.ContactId);
            ViewBag.UserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_SalesRep.UserId);
            ViewBag.RoleId = new SelectList(db.SMA_Lookup_User_Role, "RoleId", "RoleName", sMA_Lookup_SalesRep.RoleId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_SalesRep.EnterUserId);
            return View(sMA_Lookup_SalesRep);
        }

        // POST: Setting/SalesRep/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesRepId,SalesRepNo,UserId,FirstName,LastName,RoleId,ContactId,EnterUserId,EnterDate,IsActive")] SMA_Lookup_SalesRep sMA_Lookup_SalesRep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMA_Lookup_SalesRep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.SMA_Lookup_Contact, "ContactId", "Title", sMA_Lookup_SalesRep.ContactId);
            ViewBag.UserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_SalesRep.UserId);
            ViewBag.RoleId = new SelectList(db.SMA_Lookup_User_Role, "RoleId", "RoleName", sMA_Lookup_SalesRep.RoleId);
            ViewBag.EnterUserId = new SelectList(db.SMA_Lookup_User, "UserId", "FirstName", sMA_Lookup_SalesRep.EnterUserId);
            return View(sMA_Lookup_SalesRep);
        }

        // GET: Setting/SalesRep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMA_Lookup_SalesRep sMA_Lookup_SalesRep = db.SMA_Lookup_SalesRep.Find(id);
            if (sMA_Lookup_SalesRep == null)
            {
                return HttpNotFound();
            }
            return View(sMA_Lookup_SalesRep);
        }

        // POST: Setting/SalesRep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMA_Lookup_SalesRep sMA_Lookup_SalesRep = db.SMA_Lookup_SalesRep.Find(id);
            db.SMA_Lookup_SalesRep.Remove(sMA_Lookup_SalesRep);
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
