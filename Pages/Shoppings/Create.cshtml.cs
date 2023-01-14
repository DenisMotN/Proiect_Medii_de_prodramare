using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Medii_de_prodramare.Data;
using Proiect_Medii_de_prodramare.Models;

namespace Proiect_Medii_de_prodramare.Pages.Shoppings
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext _context;

        public CreateModel(Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "ID");
        ViewData["GameID"] = new SelectList(_context.Game, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Shopping Shopping { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shopping.Add(Shopping);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
