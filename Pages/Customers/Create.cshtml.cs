using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MagazinAranjamenteFlorale.Data;
using MagazinAranjamenteFlorale.Models;

namespace MagazinAranjamenteFlorale.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext _context;

        public CreateModel(MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
