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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext _context;

        public IndexModel(Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext context)
        {
            _context = context;
        }

        public IList<Shopping> Shopping { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Shopping != null)
            {
                Shopping = await _context.Shopping
                .Include(s => s.Customer)
                .Include(s => s.Game).ToListAsync();
            }
        }
    }
}
