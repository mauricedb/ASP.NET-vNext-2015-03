using System;
using System.Threading.Tasks;
using ASP.NET_vNext_2015_03.Models;
using Microsoft.AspNet.Mvc;

namespace ASP.NET_vNext_2015_03.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksRepository _repo;

        public HomeController(IBooksRepository repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Books()
        {
            //using (var repo = new BooksRepository())
            //{
            return View(await _repo.GetBooks());

            //}
        }
    }
}