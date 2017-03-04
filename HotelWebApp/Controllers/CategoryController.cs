using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelWebApp.Hotel;

namespace HotelWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private HotelClient client = new HotelClient();
        // GET: Category
        public ActionResult Index()
        {
            ViewBag.Category = client.FindCategory().ToList();
            ViewBag.Item = client.SelectAllItems().ToList();
            return View();
        }
    }
}