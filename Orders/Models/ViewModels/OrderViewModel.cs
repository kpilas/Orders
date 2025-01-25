using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Orders.Models.Domains
{
    public class OrderCreateViewModel
    {
        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        public List<SelectListItem> Products { get; set; } = new List<SelectListItem>();
    }
}

