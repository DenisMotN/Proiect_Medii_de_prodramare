using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
    public class CreateModel : GameCategoriesPageModel
    {
        private readonly Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext _context;

        public CreateModel(Proiect_Medii_de_prodramare.Data.Proiect_Medii_de_prodramareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PlatformID"] = new SelectList(_context.Set<Platform>(), "ID", "PlatformName");
            var game = new Game();
            game.GameCategories = new List<GameCategory>();
            PopulateAssignedCategoryData(_context, game);

            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newGame = new Game();

            if (selectedCategories != null)
            {
                newGame.GameCategories = new List<GameCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new GameCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newGame.GameCategories.Add(catToAdd);
                }
            }
            Game.GameCategories = newGame.GameCategories;
            _context.Game.Add(Game);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newGame);
            return Page();
        }
    }
}

