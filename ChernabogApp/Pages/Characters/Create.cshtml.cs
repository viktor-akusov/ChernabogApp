using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.Characters
{
    public class CreateModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public CreateModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CharClassId"] = new SelectList(_context.CharClass, "Id", "Description");
        ViewData["RaceId"] = new SelectList(_context.Race, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Character Character { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Character == null || Character == null)
            {
                return Page();
            }

            _context.Character.Add(Character);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
