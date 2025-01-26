using System.ComponentModel.DataAnnotations;

namespace Orders.Models.Domains
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Klient")]
        public string CustomerId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Produkt")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        [Display(Name = "Zrealizowane")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Suma")]
        public decimal TotalValue { get; set; }


        public ApplicationUser Customer { get; set; }
        public Product Product { get; set; }
    }

}

