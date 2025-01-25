using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Orders.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
