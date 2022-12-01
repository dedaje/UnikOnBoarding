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

        public async Task OnGet()
        {
            var businessModel = await _unikService.GetAllUserProjects(User.Identity?.Name ?? string.Empty); // User.Identity?.Name ?? String.Empty*

            businessModel?.ToList().ForEach(dto => IndexViewModel.Add(new TaskIndexViewModel
            {
                TaskId = dto.TaskId,
                ProjectId = dto.ProjectId,
                DateAdded = dto.DateAdded,
                TaskName = dto.ProjectName,
                UserId = dto.UserId,
                RowVersion = dto.RowVersion,
            }));
        }
    }
}
