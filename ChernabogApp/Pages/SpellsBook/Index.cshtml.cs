using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Data;
using ChernabogApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ChernabogApp.Pages.SpellsBook
{
    public class IndexModel : PageModel
    {
        private readonly ChernabogApp.Data.ChernabogAppContext _context;
        public string NameSort { get; set; }
        public string PointsSort { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }

        public string SpellLevelFilter { get; set; }

        public string SpellKindFilter { get; set; }

        public string SpellSphereFilter { get; set; }

        public string SpellTimeFilter { get; set; }

        public IList<Spell> Spell { get; set; } = default!;

        public IndexModel(ChernabogApp.Data.ChernabogAppContext context)
        {
            _context = context;
            NameSort = "name_asc";
            PointsSort = "points_asc";
            CurrentFilter = "";
            SpellLevelFilter = "";
            SpellKindFilter = "";
            SortOrder = "name_asc";
            SpellSphereFilter = "";
            SpellTimeFilter = "";
        }

        public async Task OnGetAsync(string sortOrder, string searchString, string spellLevel, string spellKind, string spellSphere, string spellTime)
        {
            if (_context.Spell != null)
            {
                NameSort = sortOrder == "name_asc" ? "name_desc" : "name_asc";
                PointsSort = sortOrder == "points_asc" ? "points_desc" : "points_asc";
                SortOrder = sortOrder;

                SpellLevelFilter = spellLevel;

                SpellKindFilter = spellKind;

                SpellSphereFilter = spellSphere;

                SpellTimeFilter = spellTime;

                CurrentFilter = searchString;

                IQueryable<Spell> spellsIQ = from s in _context.Spell
                                                 select s;

                if (!String.IsNullOrEmpty(searchString))
                {
                    spellsIQ = spellsIQ.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())
                                           || s.Description.ToUpper().Contains(searchString.ToUpper()));
                }

                switch (SpellLevelFilter)
                {
                    case "Minor":
                        spellsIQ = spellsIQ.Where(s => s.Level == SpellLevel.Minor);
                        break;
                    case "Senior":
                        spellsIQ = spellsIQ.Where(s => s.Level == SpellLevel.Senior);
                        break;
                    case "Great":
                        spellsIQ = spellsIQ.Where(s => s.Level == SpellLevel.Great);
                        break;
                    case "Legendary":
                        spellsIQ = spellsIQ.Where(s => s.Level == SpellLevel.Legendary);
                        break;
                    default:
                        break;
                }

                switch (SpellKindFilter)
                {
                    case "Wizard":
                        spellsIQ = spellsIQ.Where(s => s.Kind == SpellKind.Wizard);
                        break;
                    case "Cleric":
                        spellsIQ = spellsIQ.Where(s => s.Kind == SpellKind.Cleric);
                        break;
                    default:
                        break;
                }

                switch (SpellSphereFilter)
                {
                    case "Healing":
                        spellsIQ = spellsIQ.Where(s => s.Sphere == SpellSphere.Healing);
                        break;
                    case "Death":
                        spellsIQ = spellsIQ.Where(s => s.Sphere == SpellSphere.Death);
                        break;
                    case "Animals":
                        spellsIQ = spellsIQ.Where(s => s.Sphere == SpellSphere.Animals);
                        break;
                    case "Passion":
                        spellsIQ = spellsIQ.Where(s => s.Sphere == SpellSphere.Passion);
                        break;
                    case "Spirits":
                        spellsIQ = spellsIQ.Where(s => s.Sphere == SpellSphere.Spirits);
                        break;
                    case "Sun":
                        spellsIQ = spellsIQ.Where(s => s.Sphere == SpellSphere.Sun);
                        break;
                    case "War":
                        spellsIQ = spellsIQ.Where(s => s.Sphere == SpellSphere.War);
                        break;
                    case "Water":
                        spellsIQ = spellsIQ.Where(s => s.Sphere == SpellSphere.Water);
                        break;
                    default:
                        break;
                }

                switch (SpellTimeFilter)
                {
                    case "Instant":
                        spellsIQ = spellsIQ.Where(s => s.Time == SpellTime.Instant);
                        break;                           
                    case "MainAction":                      
                        spellsIQ = spellsIQ.Where(s => s.Time == SpellTime.MainAction);
                        break;                           
                    case "Running":                      
                        spellsIQ = spellsIQ.Where(s => s.Time == SpellTime.Running);
                        break;                           
                    case "FiveMinutes":                      
                        spellsIQ = spellsIQ.Where(s => s.Time == SpellTime.FiveMinutes);
                        break;
                    case "TenMinutes":
                        spellsIQ = spellsIQ.Where(s => s.Time == SpellTime.TenMinutes);
                        break;
                    case "OneHour":
                        spellsIQ = spellsIQ.Where(s => s.Time == SpellTime.OneHour);
                        break;
                    case "SixHours":
                        spellsIQ = spellsIQ.Where(s => s.Time == SpellTime.SixHours);
                        break;
                    case "OneDay":
                        spellsIQ = spellsIQ.Where(s => s.Time == SpellTime.OneDay);
                        break;
                    default:
                        break;
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        spellsIQ = spellsIQ.OrderByDescending(s => s.Name);
                        break;
                    case "name_asc":
                        spellsIQ = spellsIQ.OrderBy(s => s.Name);
                        break;
                    case "points_desc":
                        spellsIQ = spellsIQ.OrderByDescending(s => s.Points);
                        break;
                    case "points_asc":
                        spellsIQ = spellsIQ.OrderBy(s => s.Points);
                        break;
                    default:
                        spellsIQ = spellsIQ.OrderBy(s => s.Name);
                        break;
                }

                Spell = await spellsIQ.AsNoTracking().ToListAsync();
            }
        }
    }
}
