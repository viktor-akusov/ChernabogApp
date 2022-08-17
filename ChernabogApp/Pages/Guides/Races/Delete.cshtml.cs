using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.Guides.Races
{
    public class DeleteModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public DeleteModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Race Race { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Race == null)
            {
                return NotFound();
            }

            var race = await _context.Race.FirstOrDefaultAsync(m => m.Id == id);

            if (race == null)
            {
                return NotFound();
            }
            else 
            {
                Race = race;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Race == null)
            {
                return NotFound();
            }
            var race = await _context.Race.FindAsync(id);

            if (race != null)
            {
                Race = race;
                _context.Race.Remove(Race);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
