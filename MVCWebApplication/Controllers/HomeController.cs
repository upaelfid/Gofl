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
            var coords = from cards in db.Cards
                         where DateTime.Now.Year == ((DateTime)cards.gDate).Year && DateTime.Now.Month == ((DateTime)cards.gDate).Month && DateTime.Now.Day == ((DateTime)cards.gDate).Day
                         join course in db.Courses on cards.CourseName equals course.CourseName
                         select new { CourseName = course.CourseName,
                             lat1 =course.h1lat, ln1=course.h1ln,
                             lat2 =course.h2lat, ln2=course.h2ln,
                             lat3 =course.h3lat, ln3=course.h3ln,
                             lat4 =course.h4lat, ln4=course.h4ln,
                             lat5 =course.h5lat, ln5=course.h5ln,
                             lat6 =course.h6lat, ln6=course.h6ln,
                             lat7 =course.h7lat, ln7=course.h7ln,
                             lat8 =course.h8lat, ln8=course.h8ln,
                             lat9 =course.h9lat, ln9=course.h9ln,
                             lat10 =course.h10lat, ln10=course.h10ln,
                             lat11 =course.h11lat, ln11=course.h11ln,
                             lat12 =course.h12lat, ln12=course.h12ln,
                             lat13 =course.h13lat, ln13=course.h13ln,
                             lat14 =course.h14lat, ln14=course.h14ln,
                             lat15 =course.h15lat, ln15=course.h15ln,
                             lat16 =course.h16lat, ln16=course.h16ln,
                             lat17 =course.h17lat, ln17=course.h17ln,
                             lat18 =course.h18lat, ln18=course.h18ln
                         };




            ViewBag.CourseCoords = JsonConvert.SerializeObject(coords);

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
                           where r.Id != 1 && r.Id != 2 && r.Id != 31
                           select new { Name = r.Team, Grass = r.CourseName,  pSum = r.h1 + r.h2 + r.h3 + r.h4 + r.h5 + r.h6 + r.h7 + r.h8 + r.h9 + r.h10 + r.h11 + r.h12 + r.h13 + r.h14 + r.h15 + r.h16 + r.h17 + r.h18, r.Id, r.ccID }).Distinct();
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
                          where r.h9 !=0
                         orderby r.Name, (r.h1 + r.h2 + r.h3 + r.h4 + r.h5 + r.h6 + r.h7 + r.h8 + r.h9 + r.h10 + r.h11 + r.h12 + r.h13 + r.h14 + r.h15 + r.h16 + r.h17 + r.h18) ascending
                         join p in pMinCard on r.Id equals p.Id
                         select r).Distinct();


            return View(model);
        }

        public void  Contact(string s)
        {
            
            string pathToLog = Server.MapPath("~/coord-log.txt");

            //List<string> latln = new List<string>();

            //using (var sr = new StreamReader(pathToLog))
            //{
            //    var jsonLatLnTxt = sr.ReadToEnd();
            //    latln = JsonConvert.DeserializeObject<List<string>>(jsonLatLnTxt);
            //}



            //using(var sw = new StreamWriter(pathToLog))
            //{
            //    using(JsonWriter jw = new JsonTextWriter(sw))
            //    {
            //        jw.Formatting = Formatting.Indented;
            //        JsonSerializer serializer = new JsonSerializer();
            //        serializer.Serialize(jw, latln);
            //    }
            //}

            using (FileStream fs = new FileStream(pathToLog, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(s);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if(db !=null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}