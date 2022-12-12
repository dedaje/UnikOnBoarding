using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.UserProjects
{
    public class IndexModel : PageModel
    {
        private readonly IUnikService _unikService;

        public IndexModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public List<UserProjectsIndexViewModel> UserProjectsModel { get; set; } = new();
        [BindProperty] public string? _userId { get; set; }

        public async Task OnGet()
        {
            _userId = _unikService.GetUser(User.Identity?.Name ?? string.Empty).Result.UserId;

            if (_userId == null) NotFound();
        }

        public void OnPost()
        {

        }
    }
}
