using GpsTest.WebClient.Models;
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace GpsTest.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View(new List<LatLong>());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file == null)
                ModelState.AddModelError(string.Empty, "No file was uploaded");

            if (ModelState.IsValid)
            {
                var ctx = new CsvContext();
                var reader = new StreamReader(file.InputStream);
                var latlongs = ctx.Read<LatLong>(reader);

                return View(latlongs);
            }
            else
            {
                return View(new List<LatLong>());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
