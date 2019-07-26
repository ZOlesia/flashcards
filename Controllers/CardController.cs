using System.Linq;
using flashcards.Data;
using flashcards.Models;
using flashcards.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace flashcards.Controllers
{
    public class CardController: Controller
    {
        private DataContext _context;
        public CardController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/cards")]
        public IActionResult Cards()
        {
            ViewBag.allCategories = _context.Categories.ToList();
            ViewBag.allCards = _context.Cards.OrderBy(c => c.Category.Name).ToList();
            return View("cards");
        }

        [HttpPost]
        [Route("/new/card")]
        public IActionResult NewCard(CardViewModel model)
        {
            if(ModelState.IsValid)
            {
                Card newCard = new Card
                {
                    Question = model.Question,
                    Answer = model.Answer,
                    CreatorId = (int)HttpContext.Session.GetInt32("userId"),
                    CategoryId = model.CategoryId
                };

                _context.Cards.Add(newCard);
                _context.SaveChanges();
                return RedirectToAction("Cards");
            }

            ViewBag.allCategories = _context.Categories.ToList();
            return View("cards");
        }

        [HttpGet]
        [Route("/card/delete/{id}")]
        public IActionResult DeleteCard(int id)
        {
            Card card = _context.Cards.SingleOrDefault(c => c.CardId == id);

            _context.Remove(card);
            _context.SaveChanges();

            return RedirectToAction("Cards");
        }
    }
}