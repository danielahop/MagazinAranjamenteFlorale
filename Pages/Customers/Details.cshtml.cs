using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MagazinAranjamenteFlorale.Data;
using MagazinAranjamenteFlorale.Models;

namespace MagazinAranjamenteFlorale.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext _context;

        public DetailsModel(MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext context)
        {
            _context = context;
        }

      public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
