using _4Quantrant.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _4Quantrant.Controllers
{
    public class HomeController : Controller
    {
        private ITodoRepository _repo;
        public HomeController(ITodoRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var firstItem = _repo.Items.FirstOrDefault();

            if (firstItem == null)
            {
                // Handle the case when the database is empty
                ViewData["Message"] = "No items found in the database.";
                return View();
            }

            return View(firstItem);
        }

    }
}
