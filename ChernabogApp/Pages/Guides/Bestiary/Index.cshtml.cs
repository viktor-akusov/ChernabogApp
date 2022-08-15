using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.Guides.Bestiary
{
    public class IndexModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public IndexModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        public IList<Monster> Monster { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Monster != null)
            {
                Monster = await _context.Monster.ToListAsync();
            }
        }
    }
}
