using System.ComponentModel.DataAnnotations;

namespace flashcards.ViewModels
{
    public class CardViewModel
    {
        [Required(ErrorMessage = "This field is mandatory")]
        public string Question { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public string Answer { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}