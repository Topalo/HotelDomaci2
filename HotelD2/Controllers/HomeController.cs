using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelD2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Softver za hotelske sobe";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nas kontaktni info.";

            return View();
        }
    }
}