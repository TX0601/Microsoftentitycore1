using CanteenprojectH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CanteenprojectH.Controllers
{
    public class HomeController : Controller
    {
        private readonly CanteenDbContext _context;
        public HomeController(CanteenDbContext context)
        {
            _context = context;
        }

        // Displays the list of products
        [HttpGet]
        public IActionResult AddStock()
        {
            // Fetch the products from the database
            var products = _context.Products.ToList();  

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

        public IActionResult ProductList()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // Adds a product to the cart (POST request)
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);

            // Check if the product exists and if there is sufficient stock
            if (product == null || product.StockLevel < quantity)
            {
                // If product is not found or stock level is insufficient, return an error view.
                return View("Error", "Product not available or insufficient stock.");
            }

            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                ViewBag.Error = "Canteen is closed on Sunday!";
                return RedirectToAction("ProductList");
            }

            // Create a new sale instance with the status set to "Pending"
            var sale = new Sale
            {
                ProductId = productId,
                Quantity = quantity,
                PaymentType = "Cash", // You can modify this to handle dynamic payment types
                TotalAmount = product.Price * quantity,
                UserId = 1, // For now, this is hardcoded. In a real app, use the logged-in user's ID.
                Status = "Pending" // Set the status to "Pending"
            };

            _context.Sales.Add(sale);
            product.StockLevel -= quantity; // Reduce stock level
            _context.SaveChanges(); // Save the transaction and stock update

            return RedirectToAction("Cart");
        }


        // Displays the cart with all added items
        [HttpGet]
        public IActionResult Cart()
        {
            var userId = 1; // Get the logged-in user's ID
            var sales = _context.Sales
                .Include(s => s.Product) // Include the Product data
                .Where(s => s.UserId == userId && s.Status == "Pending") // Only fetch pending sales for the user
                .ToList();

            return View(sales);
        }

        public async Task<IActionResult> AddStock(int productId, int quantity)
        {
            var inventory = new Inventory
            {
                ProductId = productId,
                StockIn = quantity,
                StockDate = DateTime.Now
            };

            _context.Inventory.Add(inventory);

            // Assuming you have logic to update product stock levels as well
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.StockLevel += quantity; // Update product stock level
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("InventoryList");
        }





       
        [HttpPost]
        public IActionResult ProcessPayment(string paymentType)
        {
            // Get the logged-in user's ID (replace with your actual user retrieval method)
            var userId = 1; // This should be dynamically fetched based on the logged-in user

            // Retrieve the sales records for the user
            var sales = _context.Sales.Where(s => s.UserId == userId && s.Status != "Completed").ToList();

            if (sales.Count > 0)
            {
                // Update each sale's status to "Completed"
                foreach (var sale in sales)
                {
                    sale.Status = "Completed";
                }

                // Save the changes to the database
                _context.SaveChanges();
            }

            // Redirect to a confirmation page
            return RedirectToAction("PaymentConfirmation");
        }

        public IActionResult PaymentConfirmation()
        {
            return View();
        }



    }
}
