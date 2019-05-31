using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: home/Details/5
        public ActionResult Details(int id)
        {
            ViewData["Id"] = id;
            UserHelper.IdFilm = id;
            return View();
        }
    }
}
