using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_prodramare.Data;
using Proiect_Medii_de_prodramare.Models;

namespace Proiect_Medii_de_prodramare.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext _context;

        public IndexModel(Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get; set; } = default!;

        public GameData GameD { get; set; }
        public int GameID { get; set; }
        public int CategoryID { get; set; }

        public string NameSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string
searchString)
        {
            GameD = new GameData();

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            CurrentFilter = searchString;

            GameD.Games = await _context.Game
            .Include(b => b.Platform)
            .Include(b => b.GameCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                GameD.Games = GameD.Games.Where(s => s.Name.Contains(searchString));
            }

            if (id != null)
            {
                GameID = id.Value;
                Game game = GameD.Games
                .Where(i => i.ID == id.Value).Single();
                GameD.Categories = game.GameCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "title_desc":
                    GameD.Games = GameD.Games.OrderByDescending(s =>
                   s.Name);
                    break;

            }
        }
    }
}

