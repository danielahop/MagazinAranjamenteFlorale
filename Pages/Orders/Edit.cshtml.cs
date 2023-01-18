using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinAranjamenteFlorale.Data;
using MagazinAranjamenteFlorale.Models;
using System.Security.Policy;

namespace MagazinAranjamenteFlorale.Pages.Orders
{
    public class EditModel : OrderProductPageModel
    {
        private readonly MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext _context;

        public EditModel(MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order =  await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts).ThenInclude(o => o.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;

            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerName");
            PopulateProducts(_context, order);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedProducts)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderToUpdate = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderProducts).ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (orderToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Order>(
                orderToUpdate,
                "Order",
                i => i.OrderDate,
                i => i.CustomerID))
            {
                UpdateOrderProducts(_context, orderToUpdate, selectedProducts);
                _context.Order.Update(orderToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerName");
            PopulateProducts(_context, orderToUpdate);
            return Page();
        }

        private bool OrderExists(int id)
        {
          return _context.Order.Any(e => e.ID == id);
        }
    }
}
