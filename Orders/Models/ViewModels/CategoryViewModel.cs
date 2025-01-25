using System.ComponentModel.DataAnnotations;

namespace Orders.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
