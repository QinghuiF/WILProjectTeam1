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
    public class CausController : Controller
    {
        private UserModel db = new UserModel();

        // GET: Caus
        public ActionResult Index()
        {
            return View(db.Causes.ToList());
        }

        // GET: Caus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caus caus = db.Causes.Find(id);
            if (caus == null)
            {
                return HttpNotFound();
            }
            return View(caus);
        }

        // GET: Caus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Month,Date,Title,Category,Description")] Caus caus)
        {
            if (ModelState.IsValid)
            {
                db.Causes.Add(caus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caus);
        }

        // GET: Caus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caus caus = db.Causes.Find(id);
            if (caus == null)
            {
                return HttpNotFound();
            }
            return View(caus);
        }

        // POST: Caus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Month,Date,Title,Category,Description")] Caus caus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caus);
        }

        // GET: Caus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caus caus = db.Causes.Find(id);
            if (caus == null)
            {
                return HttpNotFound();
            }
            return View(caus);
        }

        // POST: Caus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caus caus = db.Causes.Find(id);
            db.Causes.Remove(caus);
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
