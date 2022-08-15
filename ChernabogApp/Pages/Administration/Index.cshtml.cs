using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChernabogApp.Pages.Administration
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel
            (
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [BindProperty]
        public IList<UserRolesViewModel> model { get; set; } = new List<UserRolesViewModel>();

        public class UserRolesViewModel
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public IEnumerable<string> Roles { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return NotFound();
            }

            var users = await _userManager.Users.ToListAsync();

            foreach (IdentityUser user in users)
            {
                UserRolesViewModel urv = new UserRolesViewModel()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = await _userManager.GetRolesAsync(user)
                };

                model.Add(urv);
            }
            return Page();
        }
    }
}