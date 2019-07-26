using System.Linq;
using flashcards.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flashcards.Controllers
{
    public class DashboardController: Controller
    {
        private DataContext _context;

        public DashboardController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("/home")]
        public IActionResult UserDashboard() 
        {
            if(!isLoggedIn()) 
                return RedirectToAction("Index", "Home");
                
            ViewBag.user = _context.Users.SingleOrDefault(x => x.UserId == HttpContext.Session.GetInt32("userId"));
            ViewBag.types = _context.Categories.Where(c => c.CreatorId == HttpContext.Session.GetInt32("userId")).ToList();
            return View("dashboard");
        }

        [HttpGet]
        [Route("/practicing")]
        public IActionResult Practice()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("practicing");
        }

        public bool isLoggedIn()
        {
            return HttpContext.Session.GetInt32("userId") == null ? false : true;
        }
    }
}