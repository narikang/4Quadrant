using _4Quantrant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        /* ViewBag.Items = _repo.Items
               .ToList();

           return View();*/
        public IActionResult Index()
        {
           var items = _repo.Items;

             if (items == null || items.Count == 0)
             {
                 ViewData["Message"] = "No items found in the database.";
                 return View();
             }

             return View(items);
          
        }
        public IActionResult Add()
        {
            return View();
        }

    }
}
