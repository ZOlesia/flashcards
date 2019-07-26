using System.Linq;
using flashcards.Data;
using flashcards.Models;
using flashcards.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flashcards.Controllers
{
    public class CategoryController: Controller
    {

        private DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("/categories")]
        public IActionResult Categories()
        {
            ViewBag.allCategories = _context.Categories.ToList();
            return View("categories");
        }

        [HttpPost]
        [Route("/new/category")]
        public IActionResult NewCategory(CategoryViewModel model)
        {
            var type = _context.Categories.SingleOrDefault(c => c.Name == model.Name);
            ViewBag.allCategories = _context.Categories.ToList();

            if(ModelState.IsValid)
            {
                if(type != null)
                {
                    TempData["error"] = "This category already exists";
                    return View("categories");
                }
                

                Category newCategory = new Category
                {
                    Name = model.Name,
                    CreatorId = (int)HttpContext.Session.GetInt32("userId")
                };

                _context.Categories.Add(newCategory);
                _context.SaveChanges();

                return RedirectToAction("Categories");
            }

            return View("categories");
        }

        [HttpGet]
        [Route("/category/delete/{id}")]
        public IActionResult Delete(int id)
        {
            _context.Categories.Remove(_context.Categories.Where(c => c.Id == id).SingleOrDefault());
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        

        public bool isLoggedIn()
        {
            return HttpContext.Session.GetInt32("userId") == null ? false : true;
        }
    }
}