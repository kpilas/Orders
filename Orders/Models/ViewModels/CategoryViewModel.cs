using System.ComponentModel.DataAnnotations;

namespace Orders.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
    }
}
