using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelWebApp.HotelService;

namespace HotelWebApp.Controllers
{
    public class TestController : Controller
    {
        private HotelClient tes = new HotelClient();
        public ActionResult Index()
        {
            ViewBag.list = tes.findByID(5);
            return View();
        }
    }
}