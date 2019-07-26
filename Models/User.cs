using System;
using System.Collections.Generic;

namespace flashcards.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Card> MyCards { get; set; }
        public List<Category> MyCategories { get; set; }

        public User() {
            this.MyCards = new List<Card>();
            this.MyCategories = new List<Category>();
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}