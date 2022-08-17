using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.Guides.CharClasses
{
    public class DetailsModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public DetailsModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

      public CharClass CharClass { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CharClass == null)
            {
                return NotFound();
            }

            var charclass = await _context.CharClass.FirstOrDefaultAsync(m => m.Id == id);
            if (charclass == null)
            {
                return NotFound();
            }
            else 
            {
                CharClass = charclass;
            }
            return Page();
        }
    }
}
