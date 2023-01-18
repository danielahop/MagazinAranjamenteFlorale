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

namespace MagazinAranjamenteFlorale.Pages.Offers
{
    public class EditModel : PageModel
    {
        private readonly MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext _context;

        public EditModel(MagazinAranjamenteFlorale.Data.MagazinAranjamenteFloraleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Offer Offer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Offer == null)
            {
                return NotFound();
            }

            var offer =  await _context.Offer
                .Include(p => p.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (offer == null)
            {
                return NotFound();
            }
            Offer = offer;
            ViewData["Product"] = new SelectList(_context.Product, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerToUpdate = await _context.Offer
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (offerToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Offer>(
                offerToUpdate,
                "Offer",
                i => i.EndDate,
                i => i.Discount,
                i => i.Name,
                i => i.ProductID
                ))
            {
                _context.Offer.Update(offerToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["Product"] = new SelectList(_context.Product, "ID", "Name");
            return Page();
        }

        private bool OfferExists(int id)
        {
          return _context.Offer.Any(e => e.ID == id);
        }
    }
}
