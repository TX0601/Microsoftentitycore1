using CanteenprojectH.Models;
using Microsoft.AspNetCore.Mvc;

namespace CanteenprojectH.Controllers
{
    public class AdminController : Controller
    {
        private readonly CanteenDbContext _context;
        public AdminController(CanteenDbContext context)
        {
            _context = context;
        }

        public IActionResult AdminDashboard()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid) {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("AdminDashboard");
            }
            return View(product);

        }

        public IActionResult ViewSalesReport()
        {
            var sales = _context.Sales.ToList();
            return View(sales);
        }

        public IActionResult ViewInventoryReport()
        {
            var inventory = _context.Inventory.ToList();
            return View(inventory);
        }
    }
}