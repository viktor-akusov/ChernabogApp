using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChernabogApp.Data;
using ChernabogApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ChernabogApp.Pages.Guides.Bestiary
{
    [Authorize(Roles = "Admin, Editor")]
    public class CreateModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public CreateModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
            Categories = new SelectList(context.MonsterCategory, nameof(MonsterCategory.Id), nameof(MonsterCategory.Name));
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Monster Monster { get; set; } = default!;
        public SelectList Categories { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Monster == null || Monster == null)
            {
                return Page();
            }

            _context.Monster.Add(Monster);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
