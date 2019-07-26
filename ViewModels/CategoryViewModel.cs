using System.ComponentModel.DataAnnotations;

namespace flashcards.ViewModels
{
    public class CategoryViewModel
    {

        [Required(ErrorMessage = "At least 2 charachters")]
        [MinLength(2)]
        public string Name { get; set; }
    }
}