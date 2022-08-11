using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.SpellsBook
{
    public class DeleteModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public DeleteModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Spell Spell { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!User.Identity.IsAuthenticated || id == null || _context.Spell == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell.FirstOrDefaultAsync(m => m.Id == id);

            if (spell == null)
            {
                return NotFound();
            }
            else 
            {
                Spell = spell;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Spell == null)
            {
                return NotFound();
            }
            var spell = await _context.Spell.FindAsync(id);

            if (spell != null)
            {
                Spell = spell;
                _context.Spell.Remove(Spell);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
