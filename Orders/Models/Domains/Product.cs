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

        [Required]
        [Display(Name = "Nazwa")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Opis")]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }


        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
