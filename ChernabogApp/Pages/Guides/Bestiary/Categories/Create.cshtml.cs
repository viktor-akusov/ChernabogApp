using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChernabogApp.Data;
using ChernabogApp.Models;

namespace ChernabogApp.Pages.Guides.Bestiary.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public CreateModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MonsterCategory MonsterCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MonsterCategory == null || MonsterCategory == null)
            {
                return Page();
            }

            _context.MonsterCategory.Add(MonsterCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
