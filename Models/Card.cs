using System;

namespace flashcards.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Card() {

            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;

        }
    }
}