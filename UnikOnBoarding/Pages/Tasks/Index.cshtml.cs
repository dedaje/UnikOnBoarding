using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly IUnikService _unikService;

        public IndexModel(IUnikService unikService)
        {
            _unikService = unikService;
        }

        [BindProperty] public List<TaskIndexViewModel> IndexViewModel { get; set; } = new();

        public async Task OnGet(int projectId)
        {
            var businessModel = await _unikService.GetAllTasksByUser(projectId, User.Identity?.Name ?? string.Empty); // User.Identity?.Name ?? String.Empty*

            businessModel?.ToList().ForEach(dto => IndexViewModel.Add(new TaskIndexViewModel
            {
                TaskId = dto.TaskId,
                TaskName = dto.TaskName,
                TaskDescription = dto.TaskDescription,
                DateCreated = dto.DateCreated,
                ProjectId = dto.ProjectId,
                RoleId = dto.RoleId,
                UserId = dto.UserId,
                RowVersion = dto.RowVersion,
            }));
        }
    }
}
