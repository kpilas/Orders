using System.ComponentModel.DataAnnotations;

namespace Orders.Models.Domains
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Client is required.")]
        [Display(Name = "Client")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Product is required.")]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Total value")]
        public decimal TotalValue { get; set; }


        public ApplicationUser Customer { get; set; }
        public Product Product { get; set; }
    }

}

