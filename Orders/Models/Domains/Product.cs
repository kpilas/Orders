using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Orders.Models.Domains
{
    public class Product
    {
        public Product()
        {
            Orders = new Collection<Order>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }


        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
