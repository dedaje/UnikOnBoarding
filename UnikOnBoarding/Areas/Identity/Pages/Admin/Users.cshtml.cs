using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unik.WebApp.UserContext;

namespace UnikOnBoarding.Areas.Identity.Pages.Admin
{
    public class UsersModel : PageModel
    {
        private readonly WebAppUserDbContext _userDb;

        [BindProperty] public IEnumerable<ApplicationUser> Users { get; set; } = Enumerable.Empty<ApplicationUser>();

        public UsersModel(WebAppUserDbContext userDb)
        {
            _userDb = userDb;
        }

        public void OnGet()
        {
            Users = _userDb.Users.ToList();
        }
    }
}
