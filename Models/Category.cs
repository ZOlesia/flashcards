using System;
using System.Collections.Generic;

namespace flashcards.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Card> Cards { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public Category()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.Cards = new List<Card>();
        }
    }
}