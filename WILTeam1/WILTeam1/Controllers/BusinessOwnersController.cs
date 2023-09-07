using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WILTeam1.Models;

namespace WILTeam1.Controllers
{
    public class BusinessOwnersController : Controller
    {
        private BusinessModel db = new BusinessModel();

        // GET: BusinessOwners
        public ActionResult Index()
        {
            return View(db.BusinessOwners.ToList());
        }

        // GET: BusinessOwners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessOwner businessOwner = db.BusinessOwners.Find(id);
            if (businessOwner == null)
            {
                return HttpNotFound();
            }
            return View(businessOwner);
        }

        // GET: BusinessOwners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] BusinessOwner businessOwner)
        {
            if (ModelState.IsValid)
            {
                db.BusinessOwners.Add(businessOwner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessOwner);
        }

        // GET: BusinessOwners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessOwner businessOwner = db.BusinessOwners.Find(id);
            if (businessOwner == null)
            {
                return HttpNotFound();
            }
            return View(businessOwner);
        }

        // POST: BusinessOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] BusinessOwner businessOwner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessOwner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessOwner);
        }

        // GET: BusinessOwners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessOwner businessOwner = db.BusinessOwners.Find(id);
            if (businessOwner == null)
            {
                return HttpNotFound();
            }
            return View(businessOwner);
        }

        // POST: BusinessOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessOwner businessOwner = db.BusinessOwners.Find(id);
            db.BusinessOwners.Remove(businessOwner);
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
