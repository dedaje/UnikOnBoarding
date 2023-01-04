using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnikOnBoarding.Infrastructure.Contract;

namespace UnikOnBoarding.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly ITaskService _taskService;

        public IndexModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty] public List<TaskIndexViewModel> IndexViewModel { get; set; } = new();

        public async Task OnGet(int projectId)
        {
            var businessModel = await _taskService.GetAllTasks(projectId);

            businessModel?.ToList().ForEach(dto => IndexViewModel.Add(new TaskIndexViewModel
            {
                Id = dto.Id,
                TaskName = dto.TaskName,
                TaskDescription = dto.TaskDescription,
                DateCreated = dto.DateCreated,
                ProjectsId = dto.ProjectsId,
                Section = dto.Section,
                UsersId = dto.UsersId,
                RowVersion = dto.RowVersion,
            }));
        }
    }
}
