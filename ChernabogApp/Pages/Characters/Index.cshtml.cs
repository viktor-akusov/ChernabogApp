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
    public class IndexModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public IndexModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        public IList<Character> Character { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Character != null)
            {
                Character = await _context.Character
                .Include(c => c.CharClass)
                .Include(c => c.Race).ToListAsync();
            }
        }
    }
}
