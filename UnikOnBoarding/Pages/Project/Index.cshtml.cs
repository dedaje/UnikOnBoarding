using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.Project
{
    public class IndexModel : PageModel
    {
        private readonly IUnikService _unikService;

        public IndexModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public List<ProjectIndexViewModel> IndexViewModel { get; set; } = new();
        [BindProperty] public string? _userId { get; set; }

        public async Task OnGet()
        {
            var businessModel = await _unikService.GetAllProjects();

            _userId = _unikService.GetUser(User.Identity?.Name ?? string.Empty).Result.UserId;

            if (businessModel == null) return;

            businessModel?.ToList().ForEach(dto => IndexViewModel.Add(new ProjectIndexViewModel
            {
                Id = dto.Id,
                ProjectName = dto.ProjectName,
                DateCreated = dto.DateCreated,
                RowVersion = dto.RowVersion,
            }));
        }
    }
}
