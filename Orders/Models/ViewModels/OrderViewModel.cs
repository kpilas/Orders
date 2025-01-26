using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Orders.Models.Domains
{
    public class OrderCreateViewModel
    {
        [Required(ErrorMessage = "Pole Produkt jest wymagane.")]
        [Display(Name = "Produkt")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Pole Ilość jest wymagane.")]
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        public List<SelectListItem> Products { get; set; } = new List<SelectListItem>();
    }
}

