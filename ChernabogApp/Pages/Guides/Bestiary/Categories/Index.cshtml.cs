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

namespace ChernabogApp.Pages.Guides.Bestiary.Categories
{
    [Authorize(Roles = "Admin, Editor")]
    public class IndexModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public IndexModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        public IList<MonsterCategory> MonsterCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MonsterCategory != null)
            {
                MonsterCategory = await _context.MonsterCategory.ToListAsync();
            }
        }
    }
}
