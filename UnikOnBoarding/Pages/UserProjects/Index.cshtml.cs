using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.UserProjects
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty] public List<UserProjectsIndexViewModel> UserProjectsModel { get; set; } = new();
        [BindProperty] public string? _userId { get; set; }

        public async Task OnGet()
        {
            _userId = _userService.GetUser(User.Identity?.Name ?? string.Empty).Result.UserId;

            if (_userId == null) NotFound();
        }

        public void OnPost()
        {

        }
    }
}
