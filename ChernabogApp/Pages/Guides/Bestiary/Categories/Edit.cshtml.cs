using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.Guides.Bestiary.Categories
{
    public class EditModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public EditModel(ChernabogApp.Data.ChernabogAppContext context)
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

            var monstercategory =  await _context.MonsterCategory.FirstOrDefaultAsync(m => m.Id == id);
            if (monstercategory == null)
            {
                return NotFound();
            }
            MonsterCategory = monstercategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MonsterCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonsterCategoryExists(MonsterCategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MonsterCategoryExists(int id)
        {
          return (_context.MonsterCategory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
