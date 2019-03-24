using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicBrainzSchoolProject.Models;

namespace MusicBrainzSchoolProject.Controllers
{
    public class VotesController : Controller
    {
        private ProjectMusicTopEntities1 db = new ProjectMusicTopEntities1();

        // GET: Votes
        public ActionResult Index()
        {
            var votes = db.Votes.Include(v => v.Albums).Include(v => v.Albums1).Include(v => v.Albums2).Include(v => v.Category).Include(v => v.AspNetUsers);
            return View(votes.ToList());
        }

        // GET: Votes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Votes votes = db.Votes.Find(id);
            if (votes == null)
            {
                return HttpNotFound();
            }
            return View(votes);
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            ViewBag.Album1_ID = new SelectList(db.Albums, "ID", "MBID");
            ViewBag.Album2_ID = new SelectList(db.Albums, "ID", "MBID");
            ViewBag.Album3_ID = new SelectList(db.Albums, "ID", "MBID");
            ViewBag.Category_ID = new SelectList(db.Category, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "ID", "Oauth_provider");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,Category_ID,Album1_ID,Album2_ID,Album3_ID")] Votes votes)
        {
            if (ModelState.IsValid)
            {
                db.Votes.Add(votes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Album1_ID = new SelectList(db.Albums, "ID", "MBID", votes.Album1_ID);
            ViewBag.Album2_ID = new SelectList(db.Albums, "ID", "MBID", votes.Album2_ID);
            ViewBag.Album3_ID = new SelectList(db.Albums, "ID", "MBID", votes.Album3_ID);
            ViewBag.Category_ID = new SelectList(db.Category, "ID", "Name", votes.Category_ID);
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "ID", "Oauth_provider", votes.User_ID);
            return View(votes);
        }

        // GET: Votes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Votes votes = db.Votes.Find(id);
            if (votes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Album1_ID = new SelectList(db.Albums, "ID", "MBID", votes.Album1_ID);
            ViewBag.Album2_ID = new SelectList(db.Albums, "ID", "MBID", votes.Album2_ID);
            ViewBag.Album3_ID = new SelectList(db.Albums, "ID", "MBID", votes.Album3_ID);
            ViewBag.Category_ID = new SelectList(db.Category, "ID", "Name", votes.Category_ID);
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "ID", "Oauth_provider", votes.User_ID);
            return View(votes);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,Category_ID,Album1_ID,Album2_ID,Album3_ID")] Votes votes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(votes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Album1_ID = new SelectList(db.Albums, "ID", "MBID", votes.Album1_ID);
            ViewBag.Album2_ID = new SelectList(db.Albums, "ID", "MBID", votes.Album2_ID);
            ViewBag.Album3_ID = new SelectList(db.Albums, "ID", "MBID", votes.Album3_ID);
            ViewBag.Category_ID = new SelectList(db.Category, "ID", "Name", votes.Category_ID);
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "ID", "Oauth_provider", votes.User_ID);
            return View(votes);
        }

        // GET: Votes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Votes votes = db.Votes.Find(id);
            if (votes == null)
            {
                return HttpNotFound();
            }
            return View(votes);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Votes votes = db.Votes.Find(id);
            db.Votes.Remove(votes);
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
