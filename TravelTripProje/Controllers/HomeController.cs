using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;
namespace TravelTripProje.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {

            var degerler = c.Blogs.Take(4).ToList();
            return View(degerler);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public PartialViewResult PartialPhoto()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult PartialTopTen()
        {
            var degerler = c.Blogs.Take(10).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult PartialBestPlace()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(6).ToList();
            return PartialView(degerler);
        }
    }
}