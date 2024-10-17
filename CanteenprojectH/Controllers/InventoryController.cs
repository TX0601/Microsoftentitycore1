using CanteenprojectH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CanteenprojectH.Controllers
{
    public class InventoryController : Controller
    {
        private readonly CanteenDbContext _context;

        public InventoryController(CanteenDbContext context)
        {
            _context = context;
        }

        // GET: Inventory/AddStock
        [HttpGet]
        public IActionResult AddStock()
        {
            // Fetch the products from the database
            var products = _context.Products.ToList();  // Check if this returns the expected product list

            // Ensure that 'products' contains valid data
            if (products == null || products.Count == 0)
            {
                // Handle the case when no products are found
                ViewBag.Products = new List<SelectListItem>();
                return View();
            }

            // Convert the list of products to SelectListItems
            ViewBag.Products = products;

            return View();
        }




        // POST: Inventory/AddStock
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStock(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                _context.Inventory.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to the index or appropriate view
            }

            ViewBag.Products = _context.Products.ToList(); // Re-populate if validation fails
            return View(inventory);
        }
    }
}