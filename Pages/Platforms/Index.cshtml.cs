using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_prodramare.Data;
using Proiect_Medii_de_prodramare.Models;

namespace Proiect_Medii_de_prodramare.Pages.Platforms
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext _context;

        public IndexModel(Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext context)
        {
            _context = context;
        }

        public IList<Platform> Platform { get; set; } = default!;

        public PlatformIndexData PlatformData { get; set; }
        public int PlatformID { get; set; }
        public int GameID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            PlatformData = new PlatformIndexData();
            PlatformData.Platforms = await _context.Platform
            .Include(i => i.Games)
            .OrderBy(i => i.PlatformName)
            .ToListAsync();
            if (id != null)
            {
                PlatformID = id.Value;
                Platform platform = PlatformData.Platforms
                .Where(i => i.ID == id.Value).Single();
                PlatformData.Games = platform.Games;
            }
        }
    }
}
