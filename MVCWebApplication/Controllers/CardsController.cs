using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebApplication.Models;
using Newtonsoft.Json;

namespace MVCWebApplication.Controllers
{
    public class CardsController : Controller
    {
        private GolfDb db = new GolfDb();

        // GET: Cards
        public ActionResult Index()
        {
            
            return View(db.Cards.OrderByDescending(x => x.gDate).ToList());
        }

        // GET: Cards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // GET: Cards/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CoursesList = db.Courses.Select(i => new SelectListItem() { Text = i.CourseName, Value = i.CourseName });
            Card card = new Card();
            card.Name = User.Identity.Name;
            card.gDate = DateTime.Now;
            return View(card);
        }

        // POST: Cards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ccID,Name,CourseName,Team,gDate,h1,h2,h3,h4,h5,h6,h7,h8,h9,h10,h11,h12,h13,h14,h15,h16,h17,h18")] Card card)
        {
            if (ModelState.IsValid)
            {
                db.Cards.Add(card);
                card.gDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(card);
        }

        // GET: Cards/EditCard/5
        public ActionResult EditCard(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }


        // POST: Cards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ccID,Name,CourseName,Team,gDate,h1,h2,h3,h4,h5,h6,h7,h8,h9,h10,h11,h12,h13,h14,h15,h16,h17,h18")] Card card)
        {
            if (ModelState.IsValid)
            {
               
                Card dbCardObjct = new Card { Id = card.Id };
                db.Cards.Attach(dbCardObjct);
                dbCardObjct.Name = card.Name;
                dbCardObjct.CourseName = card.CourseName;
                dbCardObjct.Team = card.Team;
                dbCardObjct.ccID = card.ccID;
                dbCardObjct.h1 = card.h1;
                dbCardObjct.h2 = card.h2;
                dbCardObjct.h3 = card.h3;
                dbCardObjct.h4 = card.h4;
                dbCardObjct.h5 = card.h5;
                dbCardObjct.h6 = card.h6;
                dbCardObjct.h7 = card.h7;
                dbCardObjct.h8 = card.h8;
                dbCardObjct.h9 = card.h9;
                dbCardObjct.h10 = card.h10;
                dbCardObjct.h11 = card.h11;
                dbCardObjct.h12 = card.h12;
                dbCardObjct.h13 = card.h13;
                dbCardObjct.h14 = card.h14;
                dbCardObjct.h15 = card.h15;
                dbCardObjct.h16 = card.h16;
                dbCardObjct.h17 = card.h17;
                dbCardObjct.h18 = card.h18;
                dbCardObjct.gDate = card.gDate;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(card);
        }

        // POST: Cards/EditCard/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCard([Bind(Include = "Id,ccID,Name,CourseName,Team,gDate,h1,h2,h3,h4,h5,h6,h7,h8,h9,h10,h11,h12,h13,h14,h15,h16,h17,h18")] Card card)
        {
            if (ModelState.IsValid)
            {

                Card dbCardObjct = new Card { Id = card.Id };
                db.Cards.Attach(dbCardObjct);
                dbCardObjct.Name = card.Name;
                dbCardObjct.CourseName = card.CourseName;
                dbCardObjct.Team = card.Team;
                dbCardObjct.ccID = card.ccID;
                dbCardObjct.h1 = card.h1;
                dbCardObjct.h2 = card.h2;
                dbCardObjct.h3 = card.h3;
                dbCardObjct.h4 = card.h4;
                dbCardObjct.h5 = card.h5;
                dbCardObjct.h6 = card.h6;
                dbCardObjct.h7 = card.h7;
                dbCardObjct.h8 = card.h8;
                dbCardObjct.h9 = card.h9;
                dbCardObjct.h10 = card.h10;
                dbCardObjct.h11 = card.h11;
                dbCardObjct.h12 = card.h12;
                dbCardObjct.h13 = card.h13;
                dbCardObjct.h14 = card.h14;
                dbCardObjct.h15 = card.h15;
                dbCardObjct.h16 = card.h16;
                dbCardObjct.h17 = card.h17;
                dbCardObjct.h18 = card.h18;
                dbCardObjct.gDate = card.gDate;
                
                db.SaveChanges();
                return RedirectToAction("Index", "Cards");
            }
            return View(card);
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Card card = db.Cards.Find(id);
            db.Cards.Remove(card);
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
