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

namespace ChernabogApp.Pages.Guides.Bestiary
{
    public class EditModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public EditModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
            Categories = new SelectList(context.MonsterCategory, nameof(MonsterCategory.Id), nameof(MonsterCategory.Name));
        }

        [BindProperty]
        public Monster Monster { get; set; } = default!;
        public SelectList Categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            if (id == null || _context.Monster == null)
            {
                return NotFound();
            }

            var monster =  await _context.Monster.FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }
            
            Monster = monster;
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

            _context.Attach(Monster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonsterExists(Monster.Id))
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

        private bool MonsterExists(uint id)
        {
          return (_context.Monster?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
