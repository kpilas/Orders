using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orders.Data;
using Orders.Models.Domains;

namespace Orders.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Where(o => o.CustomerId == user.Id)
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var products = await _context.Products.ToListAsync();

            var model = new OrderCreateViewModel
            {
                Products = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }

                var product = await _context.Products.FindAsync(model.ProductId);
                if (product == null)
                {
                    return NotFound();
                }

                var order = new Order
                {
                    CustomerId = user.Id,
                    Date = DateTime.Now,
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    TotalValue = model.Quantity * product.Price,
                    IsCompleted = false
                };

                _context.Add(order);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var products = await _context.Products.ToListAsync();
            model.Products = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsCompleted(int orderId)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return NotFound();
            }

            order.IsCompleted = true;

            _context.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
