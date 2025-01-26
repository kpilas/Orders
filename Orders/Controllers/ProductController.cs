using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orders.Models.Domains;
using Orders.Models.ViewModels;
using Orders.Data;
using Microsoft.AspNetCore.Authorization;

namespace Orders.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                Categories = _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    CategoryId = model.CategoryId,
                    Description = model.Description
                    
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            model.Categories = _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

