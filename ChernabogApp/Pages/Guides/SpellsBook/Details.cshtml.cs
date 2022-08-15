using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ChernabogApp.Pages.SpellsBook
{
    public class DetailsModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public DetailsModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

      public Spell Spell { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Spell == null)
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
    }
}
