using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebApplication.Models;

namespace MVCWebApplication.Controllers
{
    public class CourseController : Controller
    {
        private GolfDb db = new GolfDb();
        // GET: Course
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public JsonResult GetDropDown()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            var lm = from r in db.Courses
                     select r.CourseName;
            return Json(lm);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cards/Create
        [Authorize]
        public ActionResult Create()
        {
            Course course = new Course();
            return View(course);
        }

        // POST: Cards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseName,h1lat,h1ln ,h2lat,h2ln ,h3lat,h3ln ,h4lat,h4ln ,h5lat,h5ln ,h6lat,h6ln ,h7lat,h7ln ,h8lat,h8ln ,h9lat,h9ln ,h10lat,h10ln ,h11lat,h11ln ,h12lat,h12ln ,h13lat,h13ln ,h14lat,h14ln ,h15lat,h15ln ,h16lat,h16ln ,h17lat,h17ln ,h18lat,h18ln ")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
