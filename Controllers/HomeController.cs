using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using flashcards.Models;
using flashcards.Data;
using flashcards.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace flashcards.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult Register(RegisterViewModel user)
        {
            var email = _context.Users.SingleOrDefault(e => e.Email == user.Email);

            if(ModelState.IsValid)
            {
                if(email != null)
                {
                    TempData["error"] = "You've been here already";
                    return View("Index");
                }

                User newUser = new User{
                    Email = user.Email,
                    Password = user.Password
                };

                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();

                HttpContext.Session.SetInt32("userId", newUser.UserId);
                return RedirectToAction("UserDashboard", "Dashboard");
            }
            return View("Index");
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(e => e.Email == email);

            if(user == null)
            {
                TempData["login_error"] = "Please check your username otherwie go to register";
                return View("Index");
            }

            if(user != null && password != null)
            {
                var hasher = new PasswordHasher<User>();
                if(0 != hasher.VerifyHashedPassword(user, user.Password, password))
                {
                    HttpContext.Session.SetInt32("userId", user.UserId);
                    return RedirectToAction("UserDashboard", "Dashboard");
                }
            }

            TempData["psw_error"] = "Password is incorrect";
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
