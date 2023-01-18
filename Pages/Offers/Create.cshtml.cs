using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MagazinAranjamenteFlorale.Data;
using MagazinAranjamenteFlorale.Models;

namespace MagazinAranjamenteFlorale.Pages.Offers
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
            ViewData["Product"] = new SelectList(_context.Product, "ID", "Name");

            return Page();
        }

        [BindProperty]
        public Offer Offer { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var offer = new Offer();
            if (await TryUpdateModelAsync<Offer>(
                offer,
                "Offer",
                i => i.EndDate,
                i => i.Discount,
                i => i.Name,
                i => i.ProductID
                ))
            {
                _context.Offer.Add(Offer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["Product"] = new SelectList(_context.Product, "ID", "Name");

            return Page();
        }
    }
}
