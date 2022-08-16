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
    public class DetailsModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public DetailsModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        public Monster Monster { get; set; } = default!;
        public MonsterCategory MonsterCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null || _context.Monster == null)
            {
                return NotFound();
            }

            var monster = await _context.Monster.FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }
            else 
            {
                Monster = monster;
            }
            if(monster.CategoryId is null)
            {
                return Page();
            }
            var category = await _context.MonsterCategory.FirstOrDefaultAsync(c => c.Id == monster.CategoryId);
            if (category is not null)
            {
                MonsterCategory = category;
            }
            return Page();
        }
    }
}
