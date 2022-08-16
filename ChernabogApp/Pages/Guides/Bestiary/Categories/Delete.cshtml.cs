using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.Guides.Bestiary.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public DeleteModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MonsterCategory MonsterCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MonsterCategory == null)
            {
                return NotFound();
            }

            var monstercategory = await _context.MonsterCategory.FirstOrDefaultAsync(m => m.Id == id);

            if (monstercategory == null)
            {
                return NotFound();
            }
            else 
            {
                MonsterCategory = monstercategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MonsterCategory == null)
            {
                return NotFound();
            }
            var monstercategory = await _context.MonsterCategory.FindAsync(id);

            if (monstercategory != null)
            {
                MonsterCategory = monstercategory;
                _context.MonsterCategory.Remove(MonsterCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
