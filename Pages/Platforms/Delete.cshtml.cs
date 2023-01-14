using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_prodramare.Data;
using Proiect_Medii_de_prodramare.Models;

namespace Proiect_Medii_de_prodramare.Pages.Platforms
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext _context;

        public DeleteModel(Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Platform Platform { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Platform == null)
            {
                return NotFound();
            }

            var platform = await _context.Platform.FirstOrDefaultAsync(m => m.ID == id);

            if (platform == null)
            {
                return NotFound();
            }
            else 
            {
                Platform = platform;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Platform == null)
            {
                return NotFound();
            }
            var platform = await _context.Platform.FindAsync(id);

            if (platform != null)
            {
                Platform = platform;
                _context.Platform.Remove(Platform);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
