using System.ComponentModel.DataAnnotations;

namespace flashcards.ViewModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "At least 2 charachters")]
        [MinLength(2)]
        public string Name { get; set; }
    }
}