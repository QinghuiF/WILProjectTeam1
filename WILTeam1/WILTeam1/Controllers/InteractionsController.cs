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
    public class InteractionsController : Controller
    {
        private UserModel db = new UserModel();

        // GET: Interactions
        public ActionResult Index()
        {
            var interactions = db.Interactions.Include(i => i.AspNetUser).Include(i => i.Caus);
            return View(interactions.ToList());
        }

        // GET: Interactions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interaction interaction = db.Interactions.Find(id);
            if (interaction == null)
            {
                return HttpNotFound();
            }
            return View(interaction);
        }

        // GET: Interactions/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.CauseId = new SelectList(db.Causes, "Id", "Year");
            return View();
        }

        // POST: Interactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,CauseId,Join_Date,Comment")] Interaction interaction)
        {
            if (ModelState.IsValid)
            {
                db.Interactions.Add(interaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", interaction.UserId);
            ViewBag.CauseId = new SelectList(db.Causes, "Id", "Year", interaction.CauseId);
            return View(interaction);
        }

        // GET: Interactions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interaction interaction = db.Interactions.Find(id);
            if (interaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", interaction.UserId);
            ViewBag.CauseId = new SelectList(db.Causes, "Id", "Year", interaction.CauseId);
            return View(interaction);
        }

        // POST: Interactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,CauseId,Join_Date,Comment")] Interaction interaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", interaction.UserId);
            ViewBag.CauseId = new SelectList(db.Causes, "Id", "Year", interaction.CauseId);
            return View(interaction);
        }

        // GET: Interactions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interaction interaction = db.Interactions.Find(id);
            if (interaction == null)
            {
                return HttpNotFound();
            }
            return View(interaction);
        }

        // POST: Interactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Interaction interaction = db.Interactions.Find(id);
            db.Interactions.Remove(interaction);
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
