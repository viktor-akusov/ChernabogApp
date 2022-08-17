using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.Characters
{
    public class DetailsModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public DetailsModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

      public Character Character { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }
            else 
            {
                Character = character;
            }
            return Page();
        }
    }
}
