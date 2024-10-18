using MVCWebApplication.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace MVCWebApplication.Controllers
{
    public class HomeController : Controller
    {
        GolfDb db = new GolfDb();
        public ActionResult Index()
        {
            //Fetch course coordinates
            var coords = from cards in db.Cards
                         where DateTime.Now.Year == ((DateTime)cards.gDate).Year && DateTime.Now.Month == ((DateTime)cards.gDate).Month && DateTime.Now.Day == ((DateTime)cards.gDate).Day
                         join course in db.Courses on cards.CourseName equals course.CourseName
                         select new
                         {
                             CourseName = course.CourseName,
                             lat1 = course.h1lat,
                             ln1 = course.h1ln,
                             lat2 = course.h2lat,
                             ln2 = course.h2ln,
                             lat3 = course.h3lat,
                             ln3 = course.h3ln,
                             lat4 = course.h4lat,
                             ln4 = course.h4ln,
                             lat5 = course.h5lat,
                             ln5 = course.h5ln,
                             lat6 = course.h6lat,
                             ln6 = course.h6ln,
                             lat7 = course.h7lat,
                             ln7 = course.h7ln,
                             lat8 = course.h8lat,
                             ln8 = course.h8ln,
                             lat9 = course.h9lat,
                             ln9 = course.h9ln,
                             lat10 = course.h10lat,
                             ln10 = course.h10ln,
                             lat11 = course.h11lat,
                             ln11 = course.h11ln,
                             lat12 = course.h12lat,
                             ln12 = course.h12ln,
                             lat13 = course.h13lat,
                             ln13 = course.h13ln,
                             lat14 = course.h14lat,
                             ln14 = course.h14ln,
                             lat15 = course.h15lat,
                             ln15 = course.h15ln,
                             lat16 = course.h16lat,
                             ln16 = course.h16ln,
                             lat17 = course.h17lat,
                             ln17 = course.h17ln,
                             lat18 = course.h18lat,
                             ln18 = course.h18ln
                         };

            // Fetch drives from the Drives table and serialize them as JSON
            var drives = from d in db.Drives
                         select d;

            //Fetch the best score
            var players = (from r in db.Cards
                           where r.Id != 1 && r.Id != 2 && r.Id != 31 && r.h9 != 0
                           select new { Name = r.Team, Grass = r.CourseName, pSum = r.h1 + r.h2 + r.h3 + r.h4 + r.h5 + r.h6 + r.h7 + r.h8 + r.h9 + r.h10 + r.h11 + r.h12 + r.h13 + r.h14 + r.h15 + r.h16 + r.h17 + r.h18, r.Id, r.ccID, r.gDate }).Distinct();
            //from players get their best score and the card id for their best score              
            var pMinCard = from p in players
                           group p by new { p.Name, p.ccID, p.Grass } into grp
                           let MinCard = grp.Min(g => g.pSum)
                           let fp = grp.FirstOrDefault(gt2 => gt2.pSum == MinCard).Id
                           from p in grp
                           where p.pSum == MinCard && p.pSum != 0 && p.Id == fp
                           select p;

            //get the current course name
            var courseName = (from m in db.Cards where DateTime.Now.Year == ((DateTime)m.gDate).Year && DateTime.Now.Month == ((DateTime)m.gDate).Month && DateTime.Now.Day == ((DateTime)m.gDate).Day select m.CourseName).FirstOrDefault();
            var teamName = (from n in db.Cards where DateTime.Now.Year == ((DateTime)n.gDate).Year && DateTime.Now.Month == ((DateTime)n.gDate).Month && DateTime.Now.Day == ((DateTime)n.gDate).Day select n.Team).FirstOrDefault();
            var courseId = (from v in db.Cards where DateTime.Now.Year == ((DateTime)v.gDate).Year && DateTime.Now.Month == ((DateTime)v.gDate).Month && DateTime.Now.Day == ((DateTime)v.gDate).Day select v.ccID).FirstOrDefault();
            //join to best score and card Id to get full card data to display. Orders by course ID and best score ascending               
            var score = (from r in db.Cards
                         where r.CourseName == courseName && r.Team == teamName && r.ccID == courseId
                         orderby r.Name, (r.h1 + r.h2 + r.h3 + r.h4 + r.h5 + r.h6 + r.h7 + r.h8 + r.h9 + r.h10 + r.h11 + r.h12 + r.h13 + r.h14 + r.h15 + r.h16 + r.h17 + r.h18) ascending
                         join p in pMinCard on r.Id equals p.Id
                         select r).Distinct();

            var cardsAll = db.Cards.Where(c => c.h9 != 0 && c.CourseName == courseName && c.Team == teamName && c.ccID == courseId);
            //get the minimum score per hole
            var minCard = (from c in cardsAll
                           group c by new { c.Team, c.Name, c.CourseName } into g
                           let minH1 = g.Min(c => c.h1)
                           let minH2 = g.Min(c => c.h2)
                           let minH3 = g.Min(c => c.h3)
                           let minH4 = g.Min(c => c.h4)
                           let minH5 = g.Min(c => c.h5)
                           let minH6 = g.Min(c => c.h6)
                           let minH7 = g.Min(c => c.h7)
                           let minH8 = g.Min(c => c.h8)
                           let minH9 = g.Min(c => c.h9)
                           let minH10 = g.Min(c => c.h10)
                           let minH11 = g.Min(c => c.h11)
                           let minH12 = g.Min(c => c.h12)
                           let minH13 = g.Min(c => c.h13)
                           let minH14 = g.Min(c => c.h14)
                           let minH15 = g.Min(c => c.h15)
                           let minH16 = g.Min(c => c.h16)
                           let minH17 = g.Min(c => c.h17)
                           let minH18 = g.Min(c => c.h18)
                           let minHandicap = new[] { minH1, minH2, minH3, minH4, minH5, minH6, minH7, minH8, minH9, minH10, minH11, minH12, minH13, minH14, minH15, minH16, minH17, minH18 }.Min()
                           select new
                           {
                               Name = g.Key.Team,
                               Grass = g.Key.CourseName,
                               H1 = minH1,
                               H2 = minH2,
                               H3 = minH3,
                               H4 = minH4,
                               H5 = minH5,
                               H6 = minH6,
                               H7 = minH7,
                               H8 = minH8,
                               H9 = minH9,
                               H10 = minH10,
                               H11 = minH11,
                               H12 = minH12,
                               H13 = minH13,
                               H14 = minH14,
                               H15 = minH15,
                               H16 = minH16,
                               H17 = minH17,
                               H18 = minH18,
                               CcID = g.FirstOrDefault().ccID
                           }).Distinct();

            var hValues = (from c in db.Cards
                           where c.Id != 1 && c.Id != 2 && c.Id != 31 && c.h9 != 0
                           from h in new[] { new { Column = "h1", Value = c.h1 },
                                 new { Column = "h2", Value = c.h2 },
                                 new { Column = "h3", Value = c.h3 },
                                 new { Column = "h4", Value = c.h4 },
                                 new { Column = "h5", Value = c.h5 },
                                 new { Column = "h6", Value = c.h6 },
                                 new { Column = "h7", Value = c.h7 },
                                 new { Column = "h8", Value = c.h8 },
                                 new { Column = "h9", Value = c.h9 } }
                           group h by new { h.Column, h.Value } into g
                           select new
                           {
                               Column = g.Key.Column,
                               Value = g.Key.Value,
                               Count = g.Count()
                           }).ToList();

            ViewBag.Score = JsonConvert.SerializeObject(score);
            ViewBag.CourseCoords = JsonConvert.SerializeObject(coords);
            ViewBag.Drives = JsonConvert.SerializeObject(drives);
            ViewBag.MinCard  = JsonConvert.SerializeObject(minCard);
            ViewBag.Values = JsonConvert.SerializeObject(hValues);

            var model = from r in db.Cards
                        where DateTime.Now.Year == ((DateTime)r.gDate).Year && DateTime.Now.Month == ((DateTime)r.gDate).Month && DateTime.Now.Day == ((DateTime)r.gDate).Day
                        orderby (r.h1 + r.h2 + r.h3 + r.h4 + r.h5 + r.h6 + r.h7 + r.h8 + r.h9 + r.h10 + r.h11 + r.h12 + r.h13 + r.h14 + r.h15 + r.h16 + r.h17 + r.h18) ascending
                        select r;

            return View(model);
        }

        public ActionResult About()
        {
            var model = from r in db.Cards
                        where DateTime.Now.Year == ((DateTime)r.gDate).Year && DateTime.Now.Month == ((DateTime)r.gDate).Month && DateTime.Now.Day == ((DateTime)r.gDate).Day
                        orderby (r.h1 + r.h2 + r.h3 + r.h4 + r.h5 + r.h6 + r.h7 + r.h8 + r.h9 + r.h10 + r.h11 + r.h12 + r.h13 + r.h14 + r.h15 + r.h16 + r.h17 + r.h18) ascending
                        select r;
            return View(model);
        }

        public ActionResult Game()
        {
            var players = (from r in db.Cards
                           where r.Id != 1 && r.Id != 2 && r.Id != 31 && r.h9 != 0
                           select new { Name = r.Team, Grass = r.CourseName, pSum = r.h1 + r.h2 + r.h3 + r.h4 + r.h5 + r.h6 + r.h7 + r.h8 + r.h9 + r.h10 + r.h11 + r.h12 + r.h13 + r.h14 + r.h15 + r.h16 + r.h17 + r.h18, r.Id, r.ccID }).Distinct();
            //from players get their best score and the card id for their best score              
            var pMinCard = from p in players
                           group p by new { p.Name, p.ccID, p.Grass } into grp
                           let MinCard = grp.Min(g => g.pSum)
                           let fp = grp.FirstOrDefault(gt2 => gt2.pSum == MinCard).Id
                           from p in grp
                           where p.pSum == MinCard && p.pSum != 0 && p.Id == fp
                           select p;
            //join to best score and card Id to get full card data to display. Orders by course ID and best score ascending               
            var model = (from r in db.Cards
                         where r.CourseName !=null && r.Team != null
                         orderby r.Name, (r.h1 + r.h2 + r.h3 + r.h4 + r.h5 + r.h6 + r.h7 + r.h8 + r.h9 + r.h10 + r.h11 + r.h12 + r.h13 + r.h14 + r.h15 + r.h16 + r.h17 + r.h18) ascending
                         join p in pMinCard on r.Id equals p.Id
                         select r).Distinct();


            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}