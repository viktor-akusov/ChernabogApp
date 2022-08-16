using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChernabogApp.Pages.Guides.Bestiary
{
    public class IndexModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;

        public IndexModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
            Categories = new SelectList(context.MonsterCategory, nameof(MonsterCategory.Id), nameof(MonsterCategory.Name));
            CurrentFilter = "";
            SelectedCategory = null;
        }

        public IList<Monster> Monster { get;set; } = default!;
        public IList<MonsterCategory> MonsterCategories { get; set; } = default!;
        public MonsterCategory MonsterCategory { get; set; } = default!;
        public string CurrentFilter { get; set; }
        public int? SelectedCategory { get; set; }
        public SelectList Categories { get; set; } = default!;

        public async Task OnGetAsync(string searchString, int? categoryId)
        {
            if (_context.Monster != null)
            {
                CurrentFilter = searchString;

                SelectedCategory = categoryId;

                IQueryable<Monster> monstersIQ = from m in _context.Monster
                                                 select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    monstersIQ = monstersIQ.Where(m => m.Name.ToUpper().Contains(searchString.ToUpper())
                                           || m.Description.ToUpper().Contains(searchString.ToUpper()));
                }
                if (SelectedCategory is not null)
                {
                    monstersIQ = monstersIQ.Where(m => m.CategoryId.Equals(SelectedCategory));
                }
                Monster = await monstersIQ.ToListAsync();
                if (_context.MonsterCategory != null)
                {
                    MonsterCategories = await _context.MonsterCategory.ToListAsync();
                }
            }
        }
    }
}
