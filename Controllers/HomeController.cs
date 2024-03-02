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
        [HttpGet]
        public IActionResult Index()
        {
           //var items = _repo.Items.ToList();

            /*  if (items == null || items.Count == 0)
              {
                  ViewData["Message"] = "No items found in the database.";
                  return View();
              }

              return View(items);*/
            var items = _repo.Items.Select(t => _repo.GetItemById(t.ItemId)).ToList();
          //  return View(tasksWithCategories);

            return View(items);

        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _repo.Categories;

            var newTask = new Item();
         

            return View("Add", newTask);
        }

        [HttpPost]
        public IActionResult Add(Item newtask)
        {
            _repo.Add(newtask);
            return RedirectToAction("Index", newtask);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var recordToUpdate = _repo.Items.FirstOrDefault(t => t.ItemId == id);
            ViewBag.Categories = _repo.Categories;
            return View("Add", recordToUpdate);
        }

        [HttpPost]
        public IActionResult Update(Item item)
        {
            _repo.Update(item);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Items.FirstOrDefault(t => t.ItemId == id);
            ViewBag.Categories = _repo.Categories;
            return View("Delete", recordToDelete);

        }

        [HttpPost]
        public IActionResult Delete(Item item)
        {
            _repo.Delete(item);
            return RedirectToAction("Index");
        }

    }
}
