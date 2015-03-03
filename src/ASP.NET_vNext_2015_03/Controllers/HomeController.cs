using System;
using Microsoft.AspNet.Mvc;

namespace ASP.NET_vNext_2015_03.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
                
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}