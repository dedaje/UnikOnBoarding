using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.Project
{
    public class IndexModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;

        public IndexModel(IProjectService projectService, IUserService userService)
        {
            _projectService = projectService;
            _userService = userService;
        }

        [BindProperty] public List<ProjectIndexViewModel> IndexViewModel { get; set; } = new();
        [BindProperty] public string? _userId { get; set; }

        public async Task OnGet()
        {
            var businessModel = await _projectService.GetAllProjects();

            _userId = _userService.GetUser(User.Identity?.Name ?? string.Empty).Result.UserId;

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
