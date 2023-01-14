using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_prodramare.Data;
using Proiect_Medii_de_prodramare.Models;

namespace Proiect_Medii_de_prodramare.Pages.Shoppings
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext _context;

        public DeleteModel(Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Shopping Shopping { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shopping == null)
            {
                return NotFound();
            }

            var shopping = await _context.Shopping.FirstOrDefaultAsync(m => m.ID == id);

            if (shopping == null)
            {
                return NotFound();
            }
            else 
            {
                Shopping = shopping;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Shopping == null)
            {
                return NotFound();
            }
            var shopping = await _context.Shopping.FindAsync(id);

            if (shopping != null)
            {
                Shopping = shopping;
                _context.Shopping.Remove(Shopping);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
