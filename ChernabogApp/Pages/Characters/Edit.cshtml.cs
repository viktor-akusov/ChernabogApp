using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.Characters
{
    public class EditModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public EditModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Character Character { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character =  await _context.Character.FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }
            Character = character;
           ViewData["CharClassId"] = new SelectList(_context.CharClass, "Id", "Description");
           ViewData["RaceId"] = new SelectList(_context.Race, "Id", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(Character.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CharacterExists(int id)
        {
          return (_context.Character?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
