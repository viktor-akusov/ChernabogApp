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
    public class DetailsModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public DetailsModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

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
    }
}
