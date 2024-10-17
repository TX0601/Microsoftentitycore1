using CanteenprojectH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CanteenprojectH.Controllers
{
    public class ReportsController : Controller
    {



        private readonly CanteenDbContext _context;

        public ReportsController(CanteenDbContext context)
        {
            _context = context;
        }

        // Monthly Sales Report
        public async Task<IActionResult> MonthlySalesReport(int month, int year)
        {
            var salesReport = await _context.Sales
                .Where(s => s.SaleDate.Month == month && s.SaleDate.Year == year)
                .Select(s => new SalesReport
                {
                    SaleId = s.SaleId,
                    UserId = s.UserId,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    TotalAmount = s.TotalAmount,
                    PaymentType = s.PaymentType,
                    SaleDate = s.SaleDate,
                    ProductName = _context.Products.Where(p => p.ProductId == s.ProductId).Select(p => p.Name).FirstOrDefault(),
                    UserName = _context.Users.Where(u => u.UserId == s.UserId).Select(u => u.UserName).FirstOrDefault()
                })
                .ToListAsync();

            return View(salesReport);
        }

        // Monthly Inventory Report
        public async Task<IActionResult> MonthlyInventoryReport(int month, int year)
        {
            var inventoryReport = await _context.Inventory
                .Where(i => i.StockDate.Month == month && i.StockDate.Year == year)
                .Select(i => new InventoryReport
                {
                    InventoryId = i.InventoryId,
                    ProductId = i.ProductId,
                    ProductName = _context.Products.Where(p => p.ProductId == i.ProductId).Select(p => p.Name).FirstOrDefault(),
                    StockIn = i.StockIn,
                    StockOut = i.StockOut,
                    StockDate = i.StockDate
                })
                .ToListAsync();

            return View(inventoryReport);
        }

        // Monthly Payment Report
        public async Task<IActionResult> MonthlyPaymentReport(int month, int year)
        {
            var paymentReport = await _context.Sales
                .Where(s => s.SaleDate.Month == month && s.SaleDate.Year == year)
                .Select(s => new PaymentReport
                {
                    PaymentId = s.SaleId, // Assuming SaleId as OrderId
                    OrderId = s.SaleId,
                    PaymentType = s.PaymentType,
                    Amount = s.TotalAmount,
                    PaymentDate = s.SaleDate
                })
                .ToListAsync();

            return View(paymentReport);
        }
    }
}
