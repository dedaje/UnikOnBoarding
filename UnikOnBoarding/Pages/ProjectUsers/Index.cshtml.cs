using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;
using UnikOnBoarding.Pages.Project;
using UnikOnBoarding.Pages.ProjectUsers;

namespace UnikOnBoarding.Pages.ProjectUsers
{
    public class IndexModel : PageModel
    {
        private readonly IUnikService _unikService;

        public IndexModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public ProjectIndexViewModel ProjectIndexModel { get; set; } = new();
        [BindProperty] public int? _projectId { get; set; }
        [BindProperty] public string? _projectName { get; set; }
        [BindProperty] public string? _userId { get; set; }
        [BindProperty] public List<ProjectUsersIndexViewModel> ProjectUsersModel { get; set; } = new();

        public async Task OnGet(int? projectId, string? userId)
        {
            _projectId = projectId;
            _projectName = _unikService.GetProject(_projectId).Result.ProjectName;
            _userId = _unikService.GetUser(User.Identity?.Name ?? string.Empty).Result.UserId;
            userId = _userId;

            if (userId == null) NotFound();

            var projectUsers = await _unikService.GetAllProjectUsers(projectId);

            if (projectUsers == null) return;

            projectUsers?.ToList().ForEach(dto => ProjectUsersModel.Add(new ProjectUsersIndexViewModel
            {
                Id = dto.Id,
                ProjectName = dto.ProjectName,
                DateCreated = dto.DateCreated,
                RowVersion = dto.RowVersion,
                UserId = dto.UserId,
            }));
        }
    }
}
