using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_de_prodramare.Data;
using Proiect_Medii_de_prodramare.Models;

namespace Proiect_Medii_de_prodramare.Pages.Games
{
    [Authorize(Roles = "Admin")]

    public class EditModel : GameCategoriesPageModel
    {
        private readonly Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext _context;

        public EditModel(Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }
            Game = await _context.Game
                .Include(b => b.Platform)
                .Include(b => b.GameCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            var game = await _context.Game.FirstOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Game);

            Game = game;
            ViewData["PlatformID"] = new SelectList(_context.Set<Platform>(), "ID",
 "PlatformName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.


        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2

            var gameToUpdate = await _context.Game
                               .Include(i => i.Platform)
                               .Include(i => i.GameCategories)
                               .ThenInclude(i => i.Category)
                               .FirstOrDefaultAsync(s => s.ID == id);
            
            if (gameToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2

            if (await TryUpdateModelAsync<Game>(
            gameToUpdate,
            "Game",
            i => i.Name, i => i.Price, i => i.ReleaseDate, i => i.PlatformID))
            {
                UpdateGameCategories(_context, selectedCategories, gameToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateGameCategories(_context, selectedCategories, gameToUpdate);
            PopulateAssignedCategoryData(_context, gameToUpdate);
            return Page();

        }
    }
}
