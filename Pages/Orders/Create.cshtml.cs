using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MagazinAranjamenteFlorale.Data;
using MagazinAranjamenteFlorale.Models;
using System.Security.Policy;
using System.Diagnostics.Eventing.Reader;

namespace MagazinAranjamenteFlorale.Pages.Orders
{
    public class CreateModel : OrderProductPageModel
    {
        private readonly MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext _context;

        public CreateModel(MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerName");

            var order = new Order();
            order.OrderProducts = new List<OrderProduct>();

            PopulateProducts(_context, order);

            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedProducts)
        {
            var order = new Order();
            order.OrderProducts = new List<OrderProduct>();
            if (selectedProducts != null)
            {
                foreach (var prod in selectedProducts)
                {
                    order.OrderProducts.Add(new OrderProduct
                    {
                        ProductID = int.Parse(prod)
                    });
                }
            }

            var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
            .SelectMany(E => E.Errors)
            .Select(E => E.ErrorMessage)
            .ToList();

            if (await TryUpdateModelAsync(
                    order,
                    "Order",
                    i => i.OrderDate,
                    i => i.CustomerID
                    ))
            {
                _context.Order.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerName");
            PopulateProducts(_context, order);
            return Page();
        }
    }
}
